using System.Collections.Generic;
using System.Linq;

namespace DevDefined.Winforms.Framework.Docking
{
    public class DockingLayoutRegistry : IDockingLayoutRegistry
    {
        private readonly List<AbstractDockStrategyAttribute> _defaults = new List<AbstractDockStrategyAttribute>();

        #region IDockingLayoutRegistry Members

        public void RegisterDefaultLayout(AbstractDockStrategyAttribute attribute)
        {
            _defaults.Add(attribute);
        }

        public void ApplyDefaultLayout(IDockingController controller)
        {
            foreach (AbstractDockStrategyAttribute attribute in _defaults.Where(i => i is DockInPositionAttribute))
            {
                attribute.Apply(controller);
            }

            foreach (AbstractDockStrategyAttribute attribute in _defaults.Where(i => !(i is DockInPositionAttribute)))
            {
                attribute.Apply(controller);
            }
        }

        #endregion
    }
}