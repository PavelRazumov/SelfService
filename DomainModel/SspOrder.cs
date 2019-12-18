using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public class SspOrder : SspEntityBase
    {
        private SspOrderStage _orderStage;
        private decimal _totalPrice;
        private SspPaymentStage _paymentStage;
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


        public SspOrder(ref SspCart _cart)
        {
            cart = _cart;
            _orderStage = SspOrderStage.InProgress;
            _paymentStage = SspPaymentStage.undefined;
        }
 
        public SspOrderStage getCurrentOrderStage()
        {
            return _orderStage;
        }
        public void ChangeStatusOrder(string newStatus)
        {
            switch(newStatus)
            {
                case "wait":
                    _orderStage = SspOrderStage.WaitForPayment;
                    break;
                case "ready":
                    _orderStage = SspOrderStage.Ready;
                    break;
                case "received":
                    _orderStage = SspOrderStage.Received;
                    break;
                case "cancelled":
                    _orderStage = SspOrderStage.Cancell;
                    break;

            }
        }

        public void setPaymentMethod(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "cash":
                    _paymentStage = SspPaymentStage.byCash;
                    _orderStage = SspOrderStage.WaitForPayment;
                    break;

                case "card":
                    _paymentStage = SspPaymentStage.byCard;
                    _orderStage = SspOrderStage.WaitForPayment;
                    break;
                default:
                    _paymentStage = SspPaymentStage.undefined;
                    break;
                    
            }
        }
    }
}
