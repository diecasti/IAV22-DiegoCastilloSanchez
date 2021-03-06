using System;

namespace Bolt
{
    /// <summary>
    /// Called when the user has released the mouse button.
    /// </summary>
    [UnitCategory("Events/Input")]
    public sealed class OnMouseUp : GameObjectEventUnit<EmptyEventArgs>
    {
        public override Type MessageListenerType => typeof(UnityOnMouseUpMessageListener);
        protected override string hookName => EventHooks.OnMouseUp;
    }
}