using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.Core;
using DevDefined.Winforms.Framework.Docking;
using DevDefined.Winforms.Framework.EventPublisher;
using DevDefined.Winforms.Framework.Images;
using DevDefined.Winforms.Framework.Shell;

namespace DevDefined.Winforms.Framework.Menus
{
    public abstract class MenuStripPresenterBase : IPresenter, IStartable, IListener<ApplicationStartedSubject>,
                                                   IMenuModelObserver
    {
        private readonly IImageFactory _imageFactory;
        private readonly IMenuRegistry _menuRegistry;

        protected MenuStripPresenterBase(IMenuRegistry menuRegistry, IImageFactory imageFactory)
        {
            _menuRegistry = menuRegistry;
            _imageFactory = imageFactory;
        }

        protected IMenuRegistry MenuRegistry
        {
            get { return _menuRegistry; }
        }

        protected abstract ToolStripItemCollection RootCollection { get; }

        #region IListener<ApplicationStartedSubject> Members

        public void Handle(ApplicationStartedSubject subject)
        {
            Populate();
        }

        #endregion

        #region IMenuModelObserver Members

        public void NotifyChanged(IMenuModel model)
        {
            RebuildMenuItemsForModel(model);
        }

        #endregion

        #region IPresenter Members

        public abstract object UntypedView { get; }

        #endregion

        #region IStartable Members

        public void Start()
        {
            _menuRegistry.Register(this);
        }

        public void Stop()
        {
            _menuRegistry.UnRegister(this);
        }

        #endregion

        public void Populate()
        {
            RootCollection.Clear();

            ToolStripItem[] styledItems = StyleMenuItems(_menuRegistry.Root.GetMenuItems(_imageFactory));

            RootCollection.AddRange(styledItems);
        }

        protected virtual ToolStripItem[] StyleMenuItems(ToolStripItem[] items)
        {
            return items;
        }

        private void RebuildMenuItemsForModel(IMenuModel model)
        {
            ToolStripItem[] oldItems = FindItems(i => i.Tag == model).ToArray();

            if (oldItems.Length > 0)
            {
                var parent = oldItems[0].OwnerItem as ToolStripDropDownItem;

                ToolStripItem[] newItems = StyleMenuItems(model.GetMenuItems(_imageFactory));

                if (parent != null)
                {
                    ReplaceItems(parent.DropDownItems, oldItems, newItems);
                }
                else
                {
                    ReplaceItems(RootCollection, oldItems, newItems);
                }
            }
            else
            {
                if (model.Parent != null) RebuildMenuItemsForModel(model.Parent);
            }
        }

        private static void ReplaceItems(ToolStripItemCollection collection, IEnumerable<ToolStripItem> oldItems,
                                         IEnumerable<ToolStripItem> newItems)
        {
            int insertIndex = collection.IndexOf(oldItems.First());

            foreach (ToolStripItem itemToRemove in oldItems)
            {
                collection.Remove(itemToRemove);
            }

            foreach (ToolStripItem itemToAdd in newItems)
            {
                collection.Insert(insertIndex++, itemToAdd);
            }
        }

        private IEnumerable<ToolStripItem> FindItems(Predicate<ToolStripItem> predicate)
        {
            foreach (ToolStripDropDownItem item in RootCollection)
            {
                if (predicate(item)) yield return item;

                foreach (ToolStripItem innerItem in FindItems(item, predicate))
                {
                    yield return innerItem;
                }
            }
        }

        private static IEnumerable<ToolStripItem> FindItems(ToolStripItem current, Predicate<ToolStripItem> predicate)
        {
            var dropDownItem = current as ToolStripDropDownItem;

            if (dropDownItem != null)
            {
                foreach (ToolStripItem item in dropDownItem.DropDownItems)
                {
                    if (predicate(item)) yield return item;

                    foreach (ToolStripItem innerItem in FindItems(item, predicate))
                        yield return innerItem;
                }
            }
        }
    }
}