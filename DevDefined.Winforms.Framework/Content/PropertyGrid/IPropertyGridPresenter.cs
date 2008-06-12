using DevDefined.Winforms.Framework.Content.ProjectExplorer;
using DevDefined.Winforms.Framework.Docking;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Content.PropertyGrid
{
    [DockInsidePanel(Alignment = DockAlignment.Bottom, PanelPresenterType = typeof (IProjectExplorerPresenter),
        Size = 0.4f)]
    public interface IPropertyGridPresenter : IPresenter
    {
    }
}