using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspCart : SspEntityBase
    {
        private Dictionary<Guid, int> _cart;
 
        public SspCart()
        {
            _cart = new Dictionary<Guid, int>();
        }


        public Dictionary<Guid, int> Cart
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

        public void AddToCart(Guid itemId, int quantity)
        {
            _cart.Add(itemId, quantity);
        }

        public void ChangeQuantity(Guid itemId, int newQuantity)
        {
            var curQuantity = _cart[itemId];
            if (curQuantity != newQuantity && newQuantity > 0)
            {
                _cart[itemId] = newQuantity;
            }
        }

        public bool RemoveFromCart(Guid itemId)
        {
            return _cart.Remove(itemId);
        }
    }
}
