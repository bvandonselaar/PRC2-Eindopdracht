using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    public class Ticket : ISellable
    {

        public int Id { get; private set; }
        public int Class { get; private set; }
        public int Seat { get; private set; }
        public Buyer Buyer { get; set; }
        public double StartingPrice { get; private set; }


        public double Price
        {
            get
            {
                return (1 / Class) * StartingPrice;
            }
        }

        public Ticket(int id, int clas, int seat, Buyer buyer, double startingPrice)
        {
            Id = id;
            Class = clas;
            Seat = seat;
            Buyer = buyer;
            StartingPrice = startingPrice;
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
