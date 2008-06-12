using System;

namespace DevDefined.Winforms.Framework.AddIns
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AddInAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}