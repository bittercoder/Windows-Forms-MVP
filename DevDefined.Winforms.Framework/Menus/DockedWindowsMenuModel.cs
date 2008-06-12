using System.Collections.Generic;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Docking;
using DevDefined.Winforms.Framework.EventPublisher;
using DevDefined.Winforms.Framework.Images;
using DevDefined.Winforms.Framework.Presenter;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Menus
{
    [MainMenu(Path = "View")]
    public class DockedWindowsMenuModel : CustomMenuModelBase, IListener<PresenterVisibiltyChangedSubject>
    {
        private readonly IDockingController _controller;

        public DockedWindowsMenuModel(IDockingController controller)
            : base("DockedWindowsList", null)
        {
            _controller = controller;
        }

        #region IListener<PresenterVisibiltyChangedSubject> Members

        public void Handle(PresenterVisibiltyChangedSubject subject)
        {
            NotifyChanged();
        }

        #endregion

        public override IEnumerable<ToolStripItem> GenerateItems(IImageFactory imageFactory)
        {
            foreach (IPresenter presenter in _controller.Presenters)
            {
                string text = ((DockContent) presenter.UntypedView).Text;
                bool visible = _controller.IsVisible(presenter);

                var item = new ToolStripMenuItem(text);
                item.Checked = visible;

                yield return item;
            }
        }
    }
}