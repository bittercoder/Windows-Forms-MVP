namespace DevDefined.Winforms.Framework.EventPublisher
{
    public interface IListener
    {
    }

    public interface IListener<T> : IListener
    {
        void Handle(T subject);
    }
}