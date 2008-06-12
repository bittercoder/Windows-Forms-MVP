using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.Content.ToolBox
{
    public interface IToolBoxView : IView
    {
        void SetPresenter(IToolBoxPresenter presenter);
    }
}