using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public class ToolStripMenuPresenter : MenuStripPresenterBase
    {
        private readonly ToolStrip _menu;

        public ToolStripMenuPresenter(ToolStrip menu, IMenuRegistry menuRegistry, IImageFactory imageFactory)
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

    public class ToolBarMenuPresenter : MenuStripPresenterBase
    {
        private readonly ToolStrip _menu;

        public ToolBarMenuPresenter(ToolStrip menu, IMenuRegistry menuRegistry, IImageFactory imageFactory)
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

        protected override ToolStripItem[] StyleMenuItems(ToolStripItem[] items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Image != null)
                {
                    item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                }
            }

            return items;
        }
    }
}