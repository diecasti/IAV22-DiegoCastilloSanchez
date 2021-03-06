using System;

namespace Bolt
{
    /// <summary>
    /// Called when this collider / rigidbody has stopped touching another rigidbody / collider.
    /// </summary>
    public sealed class OnCollisionExit : CollisionEventUnit
    {
        public override Type MessageListenerType => typeof(UnityOnCollisionExitMessageListener);
        protected override string hookName => EventHooks.OnCollisionExit;
    }
}