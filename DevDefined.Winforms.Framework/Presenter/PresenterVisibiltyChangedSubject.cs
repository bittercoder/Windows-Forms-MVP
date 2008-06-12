using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Presenter
{
    public class PresenterVisibiltyChangedSubject
    {
        private readonly bool _isVisible;
        private readonly IPresenter _presenter;

        public PresenterVisibiltyChangedSubject(IPresenter presenter, bool isVisible)
        {
            _presenter = presenter;
            _isVisible = isVisible;
        }

        public IPresenter Presenter
        {
            get { return _presenter; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
        }
    }
}