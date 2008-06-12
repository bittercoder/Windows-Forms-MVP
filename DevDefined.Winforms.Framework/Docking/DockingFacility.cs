using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;

namespace DevDefined.Winforms.Framework.Docking
{
    public class DockingFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.AddComponent("docking.layoutRegistry", typeof (IDockingLayoutRegistry),
                                typeof (DockingLayoutRegistry));
            Kernel.AddComponent("docking.controller", typeof (IDockingController), typeof (DockingController));
            Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            var attribute = Reflector.GetAttribute<AbstractDockStrategyAttribute>(handler.ComponentModel.Service);

            if (attribute != null)
            {
                var controller = Kernel.Resolve<IDockingLayoutRegistry>();
                attribute.SetPresenterType(handler.ComponentModel.Service);
                controller.RegisterDefaultLayout(attribute);
            }
        }
    }
}