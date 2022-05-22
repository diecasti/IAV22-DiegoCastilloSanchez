﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace Ludiq
{
    public static class ScriptReferenceResolver
    {
        public enum Mode
        {
            Dialog,
            Console,
            Silent
        }

        public static bool canRun => EditorSettings.serializationMode == SerializationMode.ForceText;

        private static IEnumerable<string> GetAllReplacementPaths()
        {
            var validExtensions = new HashSet<string>() { ".unity", ".asset", ".prefab" };

            return AssetDatabase.GetAllAssetPaths().Select(path => Path.Combine(Paths.project, path)).Where(File.Exists).Where(f => validExtensions.Contains(Path.GetExtension(f)));
        }

        private static IEnumerable<string> GetSelectedReplacementPaths()
        {
            return Selection.assetGUIDs.Select(uo => Path.Combine(Paths.project, AssetDatabase.GUIDToAssetPath(uo))).Where(File.Exists);
        }

        private static readonly HashSet<ScriptReferenceReplacement> replacements = new HashSet<ScriptReferenceReplacement>();

        public static void AddReplacement(ScriptReference previousReference, ScriptReference newReference)
        {
            replacements.Add(new ScriptReferenceReplacement(previousReference, newReference));
        }

        public static void AddReplacement(ScriptReferenceReplacement replacement)
        {
            replacements.Add(replacement);
        }

        public static void AddReplacements(IEnumerable<ScriptReferenceReplacement> replacements)
        {
            ScriptReferenceResolver.replacements.UnionWith(replacements);
        }

        public static void Run(string path, Mode mode)
        {
            Run(new[] { path }, replacements, mode);
        }

        public static void Run(IEnumerable<string> paths, Mode mode)
        {
            Run(paths, replacements, mode);
        }

        public static void Run(IEnumerable<string> paths, IEnumerable<ScriptReferenceReplacement> replacements, Mode mode)
        {
            if (!canRun)
            {
                var message = "Cannot run missing script resolver with the current serialization mode.\nSet the project serialization mode to 'Force Text' and try again.";

                if (mode == Mode.Dialog)
                {
                    EditorUtility.DisplayDialog("Script Reference Resolver", message, "OK");
                }
                else if (mode == Mode.Console)
                {
                    Debug.LogWarning(message);
                }

                return;
            }

            // Doing a naive approach here: replacing the exact string by regex instead of parsing the YAML,
            // since Unity sometimes breaks YAML specifications. This is whitespace dependant, but it should work.

            var newContents = new Dictionary<string, string[]>();

            var _paths = paths.ToArray();
            var pathIndex = 0;

            foreach (var path in _paths)
            {
                if (newContents.ContainsKey(path))
                {
                    // Duplicate path
                    continue;
                }

                var replaced = false;
                var fileContents = new List<string>();

                if (mode == Mode.Dialog)
                {
                    ProgressUtility.DisplayProgressBar("Script Reference Resolver", $"Analyzing '{path}'...", pathIndex++ / (float)_paths.Length);
                }

                foreach (var line in File.ReadAllLines(path))
                {
                    var newLine = line;

                    foreach (var replacement in replacements)
                    {
                        var previousReferenceRegex = new Regex($@"\{{fileID: {replacement.previousReference.fileID}, guid: {replacement.previousReference.guid}, type: 3\}}");

                        newLine = previousReferenceRegex.Replace(newLine, (match) =>
                        {
                            replaced = true;

                            return $@"{{fileID: {replacement.newReference.fileID}, guid: {replacement.newReference.guid}, type: 3}}";
                        });
                    }

                    fileContents.Add(newLine);
                }

                if (replaced)
                {
                    newContents.Add(path, fileContents.ToArray());
                }
            }

            pathIndex = 0;

            if (newContents.Count > 0)
            {
                var pathMaxLength = 40;
                var fileLimit = 15;
                var fileList = newContents.Keys.Select(p => StringUtility.PathEllipsis(PathUtility.FromProject(p), pathMaxLength)).Take(fileLimit).ToLineSeparatedString();

                if (newContents.Count > fileLimit)
                {
                    fileList += "\n...";
                }

                var replace = true;

                if (mode == Mode.Dialog)
                {
                    var message = $"Missing script references have been found in {newContents.Count} file{(newContents.Count > 1 ? "s" : "")}: \n\n{fileList}\n\nProceed with replacement?";

                    replace = EditorUtility.DisplayDialog("Script Reference Resolver", message, "Replace References", "Cancel");
                }

                if (replace)
                {
                    foreach (var newContent in newContents)
                    {
                        if (mode == Mode.Dialog)
                        {
                            ProgressUtility.DisplayProgressBar("Script Reference Resolver", $"Fixing '{newContent.Key}'...", pathIndex++ / (float)_paths.Length);
                        }

                        VersionControlUtility.Unlock(newContent.Key);
                        File.WriteAllLines(newContent.Key, newContent.Value);
                    }

                    if (mode == Mode.Dialog)
                    {
                        EditorUtility.DisplayDialog("Script Reference Resolver", "Script references have been successfully replaced.", "OK");
                    }
                    else if (mode == Mode.Console)
                    {
                        Debug.Log($"Missing script references have been replaced in {newContents.Count} file{(newContents.Count > 1 ? "s" : "")}: \n{fileList}\n");
                    }

                    AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
                }
            }
            else
            {
                var message = "No missing script reference was found.";

                if (mode == Mode.Dialog)
                {
                    EditorUtility.DisplayDialog("Script Reference Resolver", message, "OK");
                }
                else if (mode == Mode.Console)
                {
                    // Debug.Log(message);
                }
            }

            if (mode == Mode.Dialog)
            {
                ProgressUtility.ClearProgressBar();
            }
        }

        [MenuItem("Tools/Bolt/Internal/Fix Missing Scripts", priority = LudiqProduct.DeveloperToolsMenuPriority + 601)]
        public static void Run()
        {
            Run(GetAllReplacementPaths(), replacements, Mode.Dialog);
        }

        [MenuItem("Assets/Fix Missing Scripts")]
        private static void RunContextual()
        {
            if (!CanRunContextual())
            {
                throw new InvalidOperationException();
            }

            Run(GetSelectedReplacementPaths(), replacements, Mode.Dialog);
        }

        [MenuItem("Assets/Fix Missing Scripts", true)]
        private static bool CanRunContextual()
        {
            return canRun && GetSelectedReplacementPaths().Any();
        }

    }
}