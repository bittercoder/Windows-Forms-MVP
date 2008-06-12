namespace DevDefined.Winforms.Framework.Docking
{
    public abstract class AbstractPresenter : IPresenter
    {
        private readonly object _view;

        public AbstractPresenter(object view)
        {
            _view = view;
        }

        #region IPresenter Members

        public object UntypedView
        {
            get { return _view; }
        }

        #endregion
    }
}