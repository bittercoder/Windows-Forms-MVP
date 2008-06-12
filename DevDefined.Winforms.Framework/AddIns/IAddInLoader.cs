using System.Reflection;

namespace DevDefined.Winforms.Framework.AddIns
{
    public interface IAddInLoader
    {
        void LoadAssembly(Assembly assembly);
    }
}