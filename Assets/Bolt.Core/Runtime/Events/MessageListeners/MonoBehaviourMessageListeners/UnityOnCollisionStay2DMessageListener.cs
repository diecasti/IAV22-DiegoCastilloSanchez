using UnityEngine;

namespace Bolt
{
    [AddComponentMenu("")]
    public sealed class UnityOnCollisionStay2DMessageListener : MessageListener
    {
        private void OnCollisionStay2D(Collision2D collision)
        {
            EventBus.Trigger(EventHooks.OnCollisionStay2D, gameObject, collision);
        }
    }
}