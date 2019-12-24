using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspOrder : SspEntityBase
    {
        public SspOrderStage orderStage;
        private decimal _totalPrice;
        private SspPaymentStage paymentStage;
        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }

            set
            {
                _totalPrice = value;
            }
        }

        public SspCart cart;


        public SspOrder(SspCart _cart)
        {
            cart = _cart;
            orderStage = SspOrderStage.InProgress;
            paymentStage = SspPaymentStage.undefined;
            CalculateTotalPrice();
        }
        
        public void CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach(SspCartItem cartItem in cart.Cart.Values)
            {
                TotalPrice += cartItem.MenuItem.Price * cartItem.Quantity;
            }
        }
        public SspOrderStage getCurrentOrderStage()
        {
            return orderStage;
        }
       
        public void setPaymentMethod(string paymentMethod)
        {
            orderStage = SspOrderStage.WaitForPayment;
            switch (paymentMethod)
            {
                case "cash":
                    paymentStage = SspPaymentStage.byCash;
                    orderStage = SspOrderStage.WaitForPayment;
                    break;

                case "card":
                    paymentStage = SspPaymentStage.byCard;
                    orderStage = SspOrderStage.WaitForPayment;
                    break;
                default:
                    paymentStage = SspPaymentStage.undefined;
                    break;
                    
            }
        }
    }
}
