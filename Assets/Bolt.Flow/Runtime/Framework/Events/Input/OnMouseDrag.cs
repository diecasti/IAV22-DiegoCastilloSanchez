using System;

namespace Bolt
{
    /// <summary>
    /// Called when the user has clicked on the GUI element or collider and is still holding down the mouse.
    /// </summary>
    [UnitCategory("Events/Input")]
    public sealed class OnMouseDrag : GameObjectEventUnit<EmptyEventArgs>
    {
        public override Type MessageListenerType => typeof(UnityOnMouseDragMessageListener);
        protected override string hookName => EventHooks.OnMouseDrag;
    }
}