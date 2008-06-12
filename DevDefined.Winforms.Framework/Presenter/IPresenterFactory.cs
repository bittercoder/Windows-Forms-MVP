using System;

namespace DevDefined.Winforms.Framework.Docking
{
    public interface IPresenterFactory
    {
        IPresenter Create(Type presenterType);
    }
}