namespace Bolt
{
    [UnityEngine.AddComponentMenu("")]
    public sealed class UnityOnMouseDragMessageListener : MessageListener
    {
        private void OnMouseDrag()
        {
            EventBus.Trigger(EventHooks.OnMouseDrag, gameObject);
        }
    }
}