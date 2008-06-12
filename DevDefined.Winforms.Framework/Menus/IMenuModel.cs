using System.Collections.Generic;
using System.Windows.Forms;
using DevDefined.Winforms.Framework.Images;

namespace DevDefined.Winforms.Framework.Menus
{
    public interface IMenuModel
    {
        IMenuModel Parent { get; set; }
        string After { get; }
        string Name { get; }
        IEnumerable<IMenuModel> Children { get; }
        ToolStripItem[] GetMenuItems(IImageFactory imageFactory);
        void Register(IMenuModelObserver observer);
        void UnRegister(IMenuModelObserver observer);
    }
}