using System;

namespace DevDefined.Winforms.Framework.Docking
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public abstract class AbstractDockStrategyAttribute : Attribute
    {
        public bool HideAfterPositioned { get; set; }
        public Type PresenterType { get; protected set; }

        public abstract void Apply(IDockingController controller);

        public virtual void SetPresenterType(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}