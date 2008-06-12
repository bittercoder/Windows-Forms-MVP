using System;
using System.Collections.Generic;

namespace DevDefined.Winforms.Framework.Menus
{
    public class MenuController : IMenuController
    {
        private readonly Dictionary<Type, IMenuRegistry> _menuPerType = new Dictionary<Type, IMenuRegistry>();
        private readonly IMenuRegistry _topMenu;

        public MenuController(IMenuRegistry topMenu)
        {
            _topMenu = topMenu;
        }

        #region IMenuController Members

        public IMenuRegistry TopMenu
        {
            get { return _topMenu; }
        }

        public IMenuRegistry GetMenuFor(Type type)
        {
            IMenuRegistry registry;

            if (!_menuPerType.TryGetValue(type, out registry))
            {
                registry = new MenuRegistry();
                _menuPerType[type] = registry;
            }

            return registry;
        }

        #endregion
    }
}