using System;

namespace DevDefined.Winforms.Framework.Menus
{
    public interface IMenuController
    {
        IMenuRegistry TopMenu { get; }
        IMenuRegistry GetMenuFor(Type type);
    }
}