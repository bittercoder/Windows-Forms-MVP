namespace DevDefined.Winforms.Framework.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        #region ICommand Members

        public abstract string Text { get; }

        public abstract string Name { get; }

        public abstract void Execute();

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
        }

        #endregion
    }
}