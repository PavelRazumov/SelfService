using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal.DomainModel
{
    public enum SspOrderStage
    {
        InProgress,
        WaitForPayment,
        Ready,
        Received,
        Cancell
    }
        
}
