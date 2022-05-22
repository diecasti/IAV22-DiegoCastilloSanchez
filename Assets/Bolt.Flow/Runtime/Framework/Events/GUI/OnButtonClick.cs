﻿using System;
using Ludiq;
using UnityEngine.UI;

namespace Bolt
{
    /// <summary>
    /// Called when a user clicks the button and releases it.
    /// </summary>
    [UnitCategory("Events/GUI")]
    [TypeIcon(typeof(Button))]
    [UnitOrder(1)]
    public sealed class OnButtonClick : GameObjectEventUnit<EmptyEventArgs>
    {
        protected override string hookName => EventHooks.OnButtonClick;
        public override Type MessageListenerType => typeof(UnityOnButtonClickMessageListener);
    }
}