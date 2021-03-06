namespace Bolt
{
    [UnityEngine.AddComponentMenu("")]
    public sealed class UnityOnMouseDownMessageListener : MessageListener
    {
        private void OnMouseDown()
        {
            EventBus.Trigger(EventHooks.OnMouseDown, gameObject);
        }
    }
}