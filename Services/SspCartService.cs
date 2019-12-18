using SelfServiceTerminal.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.Services
{
    public class SspCartService
    {
        public SspCart _cart;
        public SspMenu _menu;
        public SspCartService(ref SspCart cart, SspMenu menu)
        {
            _cart = cart;
            _menu = menu;
        }
        
        public SspCart CartService
        {
            get
            {
                return _cart;
            }

            set
            {
                _cart = value;
            }
        }

        public void AddMenuItem(SspMenuItem item)
        {
            _cart.AddToCart(item.Id, 1);
        }

        public void ChangeQuantity(SspMenuItem item, int quantity)
        {
            _cart.ChangeQuantity(item.Id, quantity);
        }

        public SspMenuItem GetMenuItemById(Guid id)
        {
            foreach (SspMenuItem menuItem in _menu._menu)
            {
                if (menuItem.Id == id)
                {
                    return menuItem;
                }
            }

            return null;
        }
    }
}
