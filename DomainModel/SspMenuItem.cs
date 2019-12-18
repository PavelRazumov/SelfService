using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceTerminal
{
    public class SspMenuItem : SspEntityBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        private bool _status;

        public bool Status
        { 
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        private decimal _price;
        public decimal Price
        {
            set
            {
                _price = value;
            }

            get
            {
                return _price;
            }
        }
        public SspMenuItem(string name, bool status, decimal price)
        {
            Status = status;
            Name = name;
            Price = price;
        }
    }
}
