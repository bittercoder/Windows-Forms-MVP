using System.Collections.Generic;

namespace DevDefined.Winforms.Framework.AddIns
{
    public interface IAddInController
    {
        IList<LoadedAddIn> LoadedAddIns { get; }
        void InstallAddInsFromFolder(string folder);
        void InstallIfAddInAssembly(string fileName);
    }
}