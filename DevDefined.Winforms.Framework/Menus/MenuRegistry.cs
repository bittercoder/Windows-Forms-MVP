using System;
using System.Collections.Generic;
using System.Linq;
using DevDefined.Winforms.Framework.Commands;

namespace DevDefined.Winforms.Framework.Menus
{
    public class MenuRegistry : IMenuRegistry, IMenuModelObserver
    {
        private readonly List<IMenuModelObserver> _observers = new List<IMenuModelObserver>();
        private readonly RootMenuModel _root = new RootMenuModel();

        #region IMenuModelObserver Members

        public void NotifyChanged(IMenuModel model)
        {
            foreach (IMenuModelObserver observer in _observers)
                observer.NotifyChanged(model);
        }

        #endregion

        #region IMenuRegistry Members

        public void AddCommand(ICommand command, AbstractMenuAttribute attribute)
        {
            var model = new CommandMenuModel(command, attribute.AfterMenuItem, attribute.SeperatorAbove,
                                             attribute.SeperatorBelow, attribute.Image);

            CollectionMenuModel parent = _root;

            if (!string.IsNullOrEmpty(attribute.Path))
            {
                parent = FindOrCreateCollection(attribute.Path);
            }

            parent.AddModel(model);
        }

        public void AddMenuModel(string path, IMenuModel model)
        {
            CollectionMenuModel parentModel = FindOrCreateCollection(path);
            parentModel.AddModel(model);
            model.Register(this);
        }

        public CollectionMenuModel FindOrCreateCollection(string path)
        {
            return FindOrCreateCollection(_root, path);
        }

        public IMenuModel FindModel(string path)
        {
            return FindModel(_root, path);
        }

        public RootMenuModel Root
        {
            get { return _root; }
        }

        public void Register(IMenuModelObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnRegister(IMenuModelObserver observer)
        {
            _observers.Remove(observer);
        }

        #endregion

        private CollectionMenuModel FindOrCreateCollection(CollectionMenuModel model, string[] fragments)
        {
            var childModel = (CollectionMenuModel) model.Children.FirstOrDefault(child => child.Name == fragments[0]);

            if (childModel == null)
            {
                childModel = new FolderMenuModel(fragments[0], null, fragments[0]);
                model.AddModel(childModel);
            }

            if (fragments.Length > 1)
            {
                var fragmentsLessOne = new string[fragments.Length - 1];
                Array.ConstrainedCopy(fragments, 1, fragmentsLessOne, 0, fragmentsLessOne.Length);
                return FindOrCreateCollection(childModel, fragmentsLessOne);
            }

            return childModel;
        }

        private CollectionMenuModel FindOrCreateCollection(CollectionMenuModel model, string path)
        {
            string[] parts = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);

            return FindOrCreateCollection(model, parts);
        }

        private IMenuModel FindModel(IMenuModel model, string[] fragments)
        {
            IMenuModel childModel = model.Children.FirstOrDefault(child => child.Name == fragments[0]);

            if (fragments.Length > 1)
            {
                var fragmentsLessOne = new string[fragments.Length - 1];
                Array.ConstrainedCopy(fragments, 1, fragmentsLessOne, 0, fragmentsLessOne.Length);
                return FindModel(childModel, fragmentsLessOne);
            }

            return childModel;
        }

        private IMenuModel FindModel(IMenuModel model, string path)
        {
            string[] parts = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);

            return FindModel(model, parts);
        }
    }
}