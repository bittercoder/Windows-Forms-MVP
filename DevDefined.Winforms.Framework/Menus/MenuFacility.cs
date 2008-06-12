using Castle.Core;
using Castle.MicroKernel.Facilities;
using DevDefined.Winforms.Framework.Commands;

namespace DevDefined.Winforms.Framework.Menus
{
    public class MenuFacility : AbstractFacility
    {
        private readonly IMenuController _menuController;
        private readonly IMenuRegistry _topMenuRegistry;

        public MenuFacility()
        {
            _topMenuRegistry = new MenuRegistry();
            _menuController = new MenuController(_topMenuRegistry);
        }

        protected override void Init()
        {
            Kernel.AddComponentInstance<IMenuRegistry>(_topMenuRegistry);
            Kernel.AddComponentInstance<IMenuController>(_menuController);
            Kernel.ComponentCreated += Kernel_ComponentCreated;
        }

        private void Kernel_ComponentCreated(ComponentModel model, object instance)
        {
            HandleCommand(instance);
            HandleMenuModule(instance);
        }

        private void HandleMenuModule(object instance)
        {
            var menuModel = instance as IMenuModel;

            if (menuModel != null)
            {
                string path = null;

                var attribute = Reflector.GetAttribute<MainMenuAttribute>(instance);

                if (attribute != null)
                {
                    path = attribute.Path;
                }

                _topMenuRegistry.AddMenuModel(path, menuModel);
            }
        }

        private void HandleCommand(object instance)
        {
            var command = instance as ICommand;

            if (command != null)
            {
                HandleMainMenuAttribute(instance, command);
                HandleContextMenuAttributes(instance, command);
            }
        }

        private void HandleContextMenuAttributes(object instance, ICommand command)
        {
            foreach (ContextMenuAttribute contextAttribute in Reflector.GetAttributes<ContextMenuAttribute>(instance))
            {
                if (contextAttribute.TargetType == null)
                    throw Error.ContextMenuAttributeMustHaveTargetTypeAssigned(instance.GetType());

                _menuController
                    .GetMenuFor(contextAttribute.TargetType)
                    .AddCommand(command, contextAttribute);
            }
        }

        private void HandleMainMenuAttribute(object instance, ICommand command)
        {
            var attribute = Reflector.GetAttribute<MainMenuAttribute>(instance);

            if (attribute != null)
            {
                _topMenuRegistry.AddCommand(command, attribute);
            }
        }
    }
}