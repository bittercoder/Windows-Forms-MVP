using System;

namespace DevDefined.Winforms.Framework.AddIns
{
    /// <summary>
    /// If a class in the add-in implements this interface (and has a default constructor) it will be
    /// constructed by installed against the applications container.
    /// </summary>
    public interface IAddInInstallAction
    {
        void Install(IServiceProvider serviceProvider);
    }
}