using System;
using Castle.MicroKernel;

namespace DevDefined.Winforms.Framework.Docking
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly IKernel _kernel;

        public PresenterFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        #region IPresenterFactory Members

        public IPresenter Create(Type presenterType)
        {
            return (IPresenter) _kernel[presenterType];
        }

        #endregion
    }
}