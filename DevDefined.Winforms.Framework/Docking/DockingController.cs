using System;
using System.Collections.Generic;
using Castle.Core;
using DevDefined.Winforms.Framework.EventPublisher;
using DevDefined.Winforms.Framework.Presenter;
using DevDefined.Winforms.Framework.Shell;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Docking
{
    public class DockingController : IDockingController, IListener<ApplicationStartedSubject>, IStartable
    {
        private readonly IPresenterFactory _factory;
        private readonly IDockingLayoutRegistry _layoutRegistry;
        private readonly DockPanel _panel;
        private readonly List<IPresenter> _presenters = new List<IPresenter>();
        private readonly IEventPublisher _publisher;

        public DockingController(DockPanel panel, IPresenterFactory factory, IDockingLayoutRegistry layoutRegistry,
                                 IEventPublisher publisher)
        {
            _panel = panel;
            _factory = factory;
            _layoutRegistry = layoutRegistry;
            _publisher = publisher;
        }

        #region IDockingController Members

        public void ArrangeInDefaultLayout()
        {
            try
            {
                _panel.SuspendLayout(true);
                _layoutRegistry.ApplyDefaultLayout(this);
            }
            finally
            {
                _panel.ResumeLayout(true, true);
            }
        }

        public IEnumerable<IPresenter> Presenters
        {
            get { return _presenters; }
        }

        public bool IsVisible(IPresenter presenter)
        {
            DockContent view = GetDockContent(presenter);
            return view.Visible;
        }

        public void ShowPresenterDocked(Type presenterType, DockState state)
        {
            ChangeVisibilty(_factory.Create(presenterType), view => view.Show(_panel, state));
        }

        public void ShowPresenterDockedInsidePanel(Type presenterType, Type panelPresenterType, DockAlignment alignment,
                                                   float proportion)
        {
            IPresenter presenter = _factory.Create(presenterType);

            DockContent panelView = GetDockContent(panelPresenterType);

            ChangeVisibilty(presenter, view => view.Show(panelView.PanelPane, alignment, proportion));
        }

        public void Hide(Type presenterType)
        {
            Hide(_factory.Create(presenterType));
        }

        #endregion

        #region IListener<ApplicationStartedSubject> Members

        public void Handle(ApplicationStartedSubject subject)
        {
            ArrangeInDefaultLayout();
        }

        #endregion

        #region IStartable Members

        public void Start()
        {
        }

        public void Stop()
        {
        }

        #endregion

        public void Hide(IPresenter presenter)
        {
            ChangeVisibilty(presenter, view => view.Hide());
        }

        public void Show(Type presenterType)
        {
            Show(_factory.Create(presenterType));
        }

        public void Show(IPresenter presenter)
        {
            ChangeVisibilty(presenter, view => view.Show());
        }

        private void ChangeVisibilty(IPresenter presenter, Action<DockContent> viewAction)
        {
            DockContent view = GetDockContent(presenter);

            bool previousVisibility = view.Visible;

            viewAction(view);

            if (previousVisibility != view.Visible)
            {
                _publisher.PublishEvent(new PresenterVisibiltyChangedSubject(presenter, view.Visible));
            }
        }

        private DockContent GetDockContent(Type presenterType)
        {
            return GetDockContent(_factory.Create(presenterType));
        }

        private DockContent GetDockContent(IPresenter presenter)
        {
            var view = presenter.UntypedView as DockContent;

            if (view == null) throw Error.ViewForPresenterDoesNotInheritFromDockContent(presenter.GetType());

            if (!_presenters.Contains(presenter)) _presenters.Add(presenter);

            return view;
        }
    }
}