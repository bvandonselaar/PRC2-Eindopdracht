using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    [Serializable]
    public class Ticket : ISellable
    {

        public int Id { get; private set; }
        public int Class { get; private set; }
        public int Seat { get; private set; }
        public Buyer Buyer { get; set; }
        public decimal StartingPrice { get; private set; }

        /// <summary>
        /// Berekent de prijs op basis van de startprijs en de klasse
        /// </summary>
        public decimal Price
        {
            get
            {
                return (1 / (decimal)Class) * StartingPrice;
            }
        }

        public Ticket(int id, int clas, int seat, Buyer buyer, decimal startingPrice)
        {
            Id = id;
            Class = clas;
            Seat = seat;
            Buyer = buyer;
            StartingPrice = startingPrice;
        }
        public override string ToString()
        {
            decimal returnPrice = Decimal.Round(Price, 2); 
            return "Id: " + Id
            + ", " + Class
            + ", " + Seat
            + ", " + Buyer
            + ", €" + returnPrice.ToString().Replace(",", ".");
        }
    }
}
