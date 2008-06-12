using System;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework.Docking
{
    public class DockInsidePanelAttribute : AbstractDockStrategyAttribute
    {
        public Type PanelPresenterType { get; set; }
        public DockAlignment Alignment { get; set; }
        public float Size { get; set; }

        public override void Apply(IDockingController controller)
        {
            if (PresenterType == PanelPresenterType)
            {
                throw Error.CanNotDockPresenterInsideItself(PresenterType);
            }

            controller.ShowPresenterDockedInsidePanel(PresenterType, PanelPresenterType, Alignment, Size);
            if (HideAfterPositioned) controller.Hide(PresenterType);
        }
    }
}