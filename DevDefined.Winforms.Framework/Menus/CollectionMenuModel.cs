using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public abstract class CollectionMenuModel : MenuModelBase
    {
        private IList<IMenuModel> _models = new List<IMenuModel>();

        public override IEnumerable<IMenuModel> Children
        {
            get { return _models; }
        }

        public void AddModel(IMenuModel model)
        {
            _models.Add(model);
            model.Parent = this;
            _models = SortByAfter(_models);
        }

        public override ToolStripItem[] GetMenuItems(IImageFactory imageFactory)
        {
            var items = new List<ToolStripItem>();

            foreach (IMenuModel model in _models)
            {
                items.AddRange(model.GetMenuItems(imageFactory));
            }

            return items.ToArray();
        }

        private IList<IMenuModel> SortByAfter(IList<IMenuModel> menuModels)
        {
            var sorted = new List<IMenuModel>(menuModels);

            foreach (IMenuModel model in menuModels)
            {
                int newIndex =
                    sorted.FindIndex(m => m.Name.Equals(model.After, StringComparison.InvariantCultureIgnoreCase));

                if (newIndex < 0) continue;

                int currentIndex = sorted.IndexOf(model);

                if (currentIndex < newIndex)
                {
                    sorted.Remove(model);
                    sorted.Insert(newIndex, model);
                }
                else
                {
                    sorted.Remove(model);
                    sorted.Insert(newIndex + 1, model);
                }
            }

            return sorted;
        }
    }
}