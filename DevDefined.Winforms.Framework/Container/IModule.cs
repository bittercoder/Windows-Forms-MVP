using Castle.Windsor;

namespace DevDefined.Winforms.Framework.Container
{
    public interface IModule
    {
        void Install(IWindsorContainer container);
    }
}