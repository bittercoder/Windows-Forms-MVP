using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    /// <summary>
    /// A base class for simplifying the implementation of a custom menu model.
    /// </summary>
    public abstract class CustomMenuModelBase : MenuModelBase, IStartable
    {
        private readonly string _after;
        private readonly string _name;

        protected CustomMenuModelBase(string name, string after)
        {
            _name = name;
            _after = after;
        }

        public override string After
        {
            get { return _after; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override IEnumerable<IMenuModel> Children
        {
            get { return new IMenuModel[] {}; }
        }

        #region IStartable Members

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
        }

        #endregion

        public override ToolStripItem[] GetMenuItems(IImageFactory imageFactory)
        {
            var items = new List<ToolStripItem>();

            foreach (ToolStripItem item in GenerateItems(imageFactory))
            {
                item.Tag = this;
                items.Add(item);
            }

            return items.ToArray();
        }

        public abstract IEnumerable<ToolStripItem> GenerateItems(IImageFactory imageFactory);
    }
}