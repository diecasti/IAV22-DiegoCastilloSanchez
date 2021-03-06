using System;

namespace Bolt
{
    /// <summary>
    /// Called every frame while the mouse is over the GUI element or collider.
    /// </summary>
    [UnitCategory("Events/Input")]
    public sealed class OnMouseOver : GameObjectEventUnit<EmptyEventArgs>
    {
        public override Type MessageListenerType => typeof(UnityOnMouseOverMessageListener);
        protected override string hookName => EventHooks.OnMouseOver;
    }
}