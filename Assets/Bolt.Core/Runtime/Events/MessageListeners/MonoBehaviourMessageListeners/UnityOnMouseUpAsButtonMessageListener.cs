namespace Bolt
{
    [UnityEngine.AddComponentMenu("")]
    public sealed class UnityOnMouseUpAsButtonMessageListener : MessageListener
    {
        private void OnMouseUpAsButton()
        {
            EventBus.Trigger(EventHooks.OnMouseUpAsButton, gameObject);
        }
    }
}