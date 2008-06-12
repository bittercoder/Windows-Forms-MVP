using DevDefined.Winforms.Framework.Docking;

namespace DevDefined.Winforms.Framework.AddIns
{
    public class InstalledAddInsPresenter : AbstractPresenter, IInstalledAddInsPresenter
    {
        public InstalledAddInsPresenter(IInstalledAddInsView view) : base(view)
        {
            view.SetPresenter(this);
        }
    }
}