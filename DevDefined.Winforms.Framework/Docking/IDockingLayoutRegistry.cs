namespace DevDefined.Winforms.Framework.Docking
{
    public interface IDockingLayoutRegistry
    {
        void RegisterDefaultLayout(AbstractDockStrategyAttribute attribute);
        void ApplyDefaultLayout(IDockingController controller);
    }
}