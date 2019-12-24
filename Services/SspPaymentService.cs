using SelfServiceTerminal.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.Services
{
    public class SspPaymentService
    {   
        public SspOrderStage statusOrder;
        
        public SspPaymentService()
        {
            statusOrder = new SspOrderStage();
        }
        public void SendOnPayment(SspOrder order)
        {
           if (order.orderStage == SspOrderStage.WaitForPayment)
            {
                // send payment
            }
        }
    }
}
