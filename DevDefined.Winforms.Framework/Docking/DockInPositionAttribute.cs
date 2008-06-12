using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Docking
{
    public class DockInPositionAttribute : AbstractDockStrategyAttribute
    {
        public DockState State { get; set; }

        public override void Apply(IDockingController controller)
        {
            controller.ShowPresenterDocked(PresenterType, State);
            if (HideAfterPositioned) controller.Hide(PresenterType);
        }
    }
}