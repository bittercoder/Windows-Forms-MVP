using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public class FolderMenuModel : CollectionMenuModel
    {
        private readonly string _after;
        private readonly string _name;
        private readonly string _text;

        public FolderMenuModel(string name, string after, string text)
        {
            _after = after;
            _name = name;
            _text = text;
        }

        public override string After
        {
            get { return _after; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public string Text
        {
            get { return _text; }
        }

        public override ToolStripItem[] GetMenuItems(IImageFactory imageFactory)
        {
            var item = new ToolStripMenuItem(Name);
            item.Tag = this;

            item.DropDownItems.AddRange(base.GetMenuItems(imageFactory));

            return new ToolStripItem[] {item};
        }
    }
}