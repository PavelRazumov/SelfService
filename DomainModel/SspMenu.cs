using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspMenu : SspEntityBase
    {
        public List<SspMenuItem> _menu;
        public SspMenu()
        {
            _menu = new List<SspMenuItem>();
        }

        public void AddMenuItem(SspMenuItem _menuItem)
        {
            _menu.Add(_menuItem);
        }

        public void RemoveMenuItem(SspMenuItem _menuItem)
        {
            _menu.Remove(_menuItem);
        }

        public SspMenuItem GetMenuItemById(Guid Id)
        {
            foreach (SspMenuItem menuItem in _menu)
            {
                if (menuItem.Id == Id)
                {
                    return menuItem;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
