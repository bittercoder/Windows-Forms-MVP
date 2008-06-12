using Castle.Windsor;

namespace DevDefined.Winforms.Framework.Container
{
    public class WinformsContainer : WindsorContainer
    {
        public WinformsContainer(params IModule[] modules)
        {
            if (modules != null)
            {
                foreach (IModule module in modules)
                {
                    module.Install(this);
                }
            }
        }
    }
}