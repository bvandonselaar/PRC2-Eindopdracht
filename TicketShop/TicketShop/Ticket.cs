using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    public class Ticket
    {
        public int Id{ get; private set; }
        public int Class { get; private set; }
        public int Seat { get; private set; }
        public Buyer Buyer { get; set; }

        public Ticket(int id, int clas, int seat, Buyer buyer)
        {
            Id = id;
            Class = clas;
            Seat = seat;
            Buyer = buyer;
        }
        public override string ToString()
        {
            return Id
            + ", " + Class
            + ", " + Seat
            + ", " + Buyer;
        }
    }
}
