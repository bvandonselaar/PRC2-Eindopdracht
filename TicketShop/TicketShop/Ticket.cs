using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    [Serializable]
    public class Ticket : ISellable, IComparable
    {

        public int Id { get; private set; }
        public int Class { get; private set; }
        public int Seat { get; private set; }
        public Buyer Buyer { get; private set; }
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

        
        /// <summary>
        /// Sorteert op datum oplopend (nieuwste eerst)
        /// </summary>
        private class PriceAscendingComparer : IComparer<Ticket>
        {
            int IComparer<Ticket>.Compare(Ticket x, Ticket y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }

        /// <summary>
        /// Sorteert op class aflopend (oudste eerst)
        /// </summary>
        private class PriceDescendingComparer : IComparer<Ticket>
        {
            int IComparer<Ticket>.Compare(Ticket x, Ticket y)
            {
                return y.Price.CompareTo(x.Price);
            }
        }

        private class BuyernameAscendingComparer : IComparer<Ticket>
        {
            int IComparer<Ticket>.Compare(Ticket x, Ticket y)
            {
                return string.Compare(x.Buyer.Name, y.Buyer.Name);
            }
        }

        private class BuyernameDescendingComparer : IComparer<Ticket>
        {
            int IComparer<Ticket>.Compare(Ticket x, Ticket y)
            {
                return string.Compare(y.Buyer.Name, x.Buyer.Name);
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

        public void setNewBuyer(Buyer b)
        {
            Buyer = b;
        }

        
        /// <summary>
        /// Default sort-order
        /// </summary>
        /// <param name="obj"> object to sort with this object </param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj == null) { return 0; }
            Ticket e = (Ticket)obj;
            return this.Id.CompareTo(e.Id);
        }

        
        // These return the Comparer methods
        //-----------------------------------------------------------------------------------
        public static IComparer<Ticket> SortPriceDescendingTicket()
        {
            return new PriceAscendingComparer();
        }

        public static IComparer<Ticket> SortPriceAscendingTicket()
        {
            return new PriceDescendingComparer();
        }

        public static IComparer<Ticket> SortBuyernameAscendingTicket()
        {
            return new BuyernameAscendingComparer();
        }

        public static IComparer<Ticket> SortBuyernameDescendingTicket()
        {
            return new BuyernameDescendingComparer();
        }
        //-----------------------------------------------------------------------------------

    
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
