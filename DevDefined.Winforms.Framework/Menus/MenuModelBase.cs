using System.Collections.Generic;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public abstract class MenuModelBase : IMenuModel
    {
        private readonly List<IMenuModelObserver> _observers = new List<IMenuModelObserver>();

        #region IMenuModel Members

        public void Register(IMenuModelObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnRegister(IMenuModelObserver observer)
        {
            _observers.Remove(observer);
        }

        public IMenuModel Parent { get; set; }

        public abstract string After { get; }
        public abstract string Name { get; }

        public abstract ToolStripItem[] GetMenuItems(IImageFactory imageFactory);
        public abstract IEnumerable<IMenuModel> Children { get; }

        #endregion

        protected void NotifyChanged()
        {
            foreach (IMenuModelObserver observer in _observers)
                observer.NotifyChanged(this);
        }
    }

    public interface IMenuModelObserver
    {
        void NotifyChanged(IMenuModel model);
    }
}