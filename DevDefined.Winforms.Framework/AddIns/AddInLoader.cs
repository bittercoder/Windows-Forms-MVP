using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel;
using DevDefined.Winforms.Framework.Commands;
using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.AddIns
{
    public class AddInLoader : IAddInLoader
    {
        private readonly IKernel _kernel;

        public AddInLoader(IKernel kernel)
        {
            _kernel = kernel;
        }

        #region IAddInLoader Members

        public void LoadAssembly(Assembly assembly)
        {
            RegisterCommands(assembly);
            RegisterPresenters(assembly);
            ExecuteAddInInstallers(assembly);
        }

        #endregion

        private void ExecuteAddInInstallers(Assembly assembly)
        {
            IEnumerable<Type> allInstallActions =
                assembly.GetTypes().Where(t => typeof (IAddInInstallAction).IsAssignableFrom(t));

            foreach (Type installActionType in allInstallActions)
            {
                var installAction = Reflector.Construct<IAddInInstallAction>(installActionType);
                installAction.Install(_kernel);
            }
        }

        private void RegisterPresenters(Assembly assembly)
        {
            IEnumerable<Type> allPresenters = assembly.GetTypes().Where(t => typeof (IPresenter).IsAssignableFrom(t));

            foreach (Type presenterType in allPresenters)
            {
                if (_kernel.HasComponent(presenterType))
                {
                    _kernel.AddComponent("presenter." + presenterType.FullName, presenterType);
                }
            }
        }

        private void RegisterCommands(Assembly assembly)
        {
            IEnumerable<Type> allCommands = assembly.GetTypes().Where(t => typeof (ICommand).IsAssignableFrom(t));

            foreach (Type commandType in allCommands)
            {
                if (!_kernel.HasComponent(commandType))
                {
                    _kernel.AddComponent("command." + commandType.FullName, commandType);
                }
            }
        }
    }
}