using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public class MenuStripPresenter : MenuStripPresenterBase
    {
        private readonly MenuStrip _menu;

        public MenuStripPresenter(MenuStrip menu, IMenuRegistry menuRegistry, IImageFactory imageFactory)
            : base(menuRegistry, imageFactory)
        {
            _menu = menu;
        }

        public override object UntypedView
        {
            get { return _menu; }
        }

        protected override ToolStripItemCollection RootCollection
        {
            get { return _menu.Items; }
        }
    }
}