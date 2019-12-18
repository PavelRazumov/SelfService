using SelfServiceTerminal.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.Services
{
    public class SspOrderService
    {
        public SspOrder _order;
        SspCartService cartService;
        public SspOrderService(ref SspOrder order, ref SspCartService _cartService)
        {
            _order = order;
            cartService = _cartService;
        }

        public decimal GetTotalPriceOrder()
        {
            decimal TotalPrice = 0;
            foreach (var pair in _order.cart.Cart)
            {
                TotalPrice += pair.Value * cartService.GetMenuItemById(pair.Key).Price;
            }

            return TotalPrice;

        }
        public void SendOnPayment()
        {
           // return "successfull";
        }
    }
}
