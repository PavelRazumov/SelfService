using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspCart : SspEntityBase
    {
        private Dictionary<Guid, SspCartItem> cart;
 
        public SspCart()
        {
            cart = new Dictionary<Guid, SspCartItem>();
        }

        public Dictionary<Guid, SspCartItem> Cart
        {
            get
            {
                return cart;
            }

            set
            {
                cart = value;
            }
        }

        public void AddToCart(SspMenuItem menuItem)
        {
            var newCartItem = new SspCartItem(menuItem);
            cart.Add(menuItem.Id, newCartItem);
        }

        public void ChangeQuantity(SspMenuItem menuItem, int newQuantity)
        {
            var curQuantity = cart[menuItem.Id].Quantity;
            if (curQuantity != newQuantity && newQuantity > 0)
            {
                cart[menuItem.Id].Quantity = newQuantity;
            }
        }

        public bool RemoveFromCart(Guid itemId)
        {
            return cart.Remove(itemId);
        }
    }
}
