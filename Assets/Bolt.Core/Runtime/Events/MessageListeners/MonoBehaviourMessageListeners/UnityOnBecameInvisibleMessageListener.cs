namespace Bolt
{
    [UnityEngine.AddComponentMenu("")]
    public sealed class UnityOnBecameInvisibleMessageListener : MessageListener
    {
        private void OnBecameInvisible()
        {
            EventBus.Trigger(EventHooks.OnBecameInvisible, gameObject);
        }
    }
}