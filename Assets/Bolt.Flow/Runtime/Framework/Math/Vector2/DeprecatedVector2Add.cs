using System;
using Ludiq;
using UnityEngine;

namespace Bolt
{
    /// <summary>
    /// Returns the sum of two 2D vectors.
    /// </summary>
    [UnitCategory("Math/Vector 2")]
    [UnitTitle("Add")]
    [Obsolete("Use the new \"Add (Math/Vector 2)\" unit instead.")]
    [RenamedFrom("Unity.VisualScripting.Vector2Add")]
    public sealed class DeprecatedVector2Add : Add<Vector2>
    {
        protected override Vector2 defaultB => Vector2.zero;

        public override Vector2 Operation(Vector2 a, Vector2 b)
        {
            return a + b;
        }
    }
}
