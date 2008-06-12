namespace DevDefined.Winforms.Framework.EventPublisher
{
    public interface IEventPublisher
    {
        void PublishEvent<T>(T subject);
        void AddListener(IListener listener);
        void RemoveListener(IListener listener);
    }
}