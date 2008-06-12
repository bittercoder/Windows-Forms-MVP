using System;

namespace DevDefined.Winforms.Framework.Menus
{
    public class AbstractMenuAttribute : Attribute
    {
        public string Path { get; set; }
        public string AfterMenuItem { get; set; }
        public bool SeperatorBelow { get; set; }
        public bool SeperatorAbove { get; set; }
        public string Image { get; set; }
    }
}