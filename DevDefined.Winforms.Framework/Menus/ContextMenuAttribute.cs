using System;

namespace DevDefined.Winforms.Framework.Menus
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ContextMenuAttribute : AbstractMenuAttribute
    {
        public Type TargetType { get; set; }
    }
}