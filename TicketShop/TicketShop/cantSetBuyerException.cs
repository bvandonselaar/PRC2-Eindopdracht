using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    class CantSetBuyerException : Exception
    {
        public CantSetBuyerException()
        {
        }

        public CantSetBuyerException(string message) : base(message)
        {
        }

        public CantSetBuyerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
