using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspCartItem
    {
        private SspMenuItem menuItem;
        public int quantity;

        public SspCartItem(SspMenuItem menuItem)
        {
            MenuItem = menuItem;
            Quantity = 1;
        }
        public SspMenuItem MenuItem
        {
            get
            {
                return menuItem;
            }

            set
            {
                menuItem = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

    }
}
