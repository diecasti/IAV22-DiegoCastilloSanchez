namespace Bolt
{
    [UnityEngine.AddComponentMenu("")]
    public sealed class UnityOnMouseEnterMessageListener : MessageListener
    {
        private void OnMouseEnter()
        {
            EventBus.Trigger(EventHooks.OnMouseEnter, gameObject);
        }
    }
}