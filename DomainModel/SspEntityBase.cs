using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal
{
    public abstract class SspEntityBase
    {
        public SspEntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get;
            private set;
        }
    }
}
