using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DevDefined.Winforms.Framework.AddIns
{
    public class AddInController : IAddInController
    {
        private readonly List<LoadedAddIn> _addins = new List<LoadedAddIn>();
        private readonly AddInLoader _loader;

        public AddInController(AddInLoader loader)
        {
            if (loader == null) throw new ArgumentNullException("loader");
            _loader = loader;
        }

        #region IAddInController Members

        public IList<LoadedAddIn> LoadedAddIns
        {
            get { return _addins; }
        }

        public void InstallAddInsFromFolder(string folder)
        {
            foreach (string file in Directory.GetFiles(folder, "*.dll"))
            {
                InstallIfAddInAssembly(file);
            }
        }

        public void InstallIfAddInAssembly(string fileName)
        {
            Assembly assembly = Assembly.LoadFile(fileName);

            var attribute = Reflector.GetAttribute<AddInAttribute>(assembly);

            if (attribute != null)
            {
                InstallAddInAssembly(fileName, assembly, attribute);
            }
        }

        #endregion

        public void InstallAddInAssembly(string fileName, Assembly assembly, AddInAttribute attribute)
        {
            var loadedAddIn = new LoadedAddIn(attribute.Name, attribute.Description, assembly, fileName);

            try
            {
                _loader.LoadAssembly(assembly);
            }
            catch (Exception ex)
            {
                loadedAddIn.Error = ex.ToString();
            }

            _addins.Add(loadedAddIn);
        }
    }
}