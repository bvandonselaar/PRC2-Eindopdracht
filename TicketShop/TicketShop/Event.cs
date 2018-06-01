using System;
using System.Collections.Generic;
using System.Collections;

namespace TicketShop
{
    [Serializable]
    public abstract class Event : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public int AvailableSeats { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        public enum SortBy : byte { Buyername, Price };

        //Comparer Methods
        //-----------------------------------------------------------------------------------

        /// <summary>
        /// Sorteert op naam aflopend (alfabetisch)
        /// </summary>
        private class NameDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if (x != null && y != null)
                {
                    return string.Compare(y.Name, x.Name);
                }
                return 0;
            }
        }
        /// <summary>
        /// Sorteert op naam oplopend (alfabetisch)
        /// </summary>
        private class NameAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if (x != null && y != null)
                {
                    return string.Compare(x.Name, y.Name);
                }
                return 0;
            }
        }
        /// <summary>
        /// Sorteert op ID oplopend (laagste eerst)
        /// </summary>
        private class IdAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if (x != null && y != null)
                {
                    return x.Id.CompareTo(y.Id);
                }
                return 0;
            }
        }
        /// <summary>
        /// Sorteert op ID aflopend (hoogste eerst)
        /// </summary>
        private class IdDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if(x != null && y != null)
                {
                    return y.Id.CompareTo(x.Id);
                }
                return 0;
            }
        }
        /// <summary>
        /// Sorteert op datum oplopend (nieuwste eerst)
        /// </summary>
        private class DateAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if (x != null && y != null)
                {
                    return x.Date.CompareTo(y.Date);
                }
                return 0;
            }
        }
        /// <summary>
        /// Sorteert op datum aflopend (oudste eerst)
        /// </summary>
        private class DateDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                if (x != null && y != null)
                {
                    return y.Date.CompareTo(x.Date);
                }
                return 0;
            }
        }
        //-----------------------------------------------------------------------------------

        public Event(string name, int id, DateTime date, string location, int availableSeats)
        {
            Name = name;
            Id = id;
            Date = date;
            Location = location;
            AvailableSeats = availableSeats;
            Tickets = new List<Ticket>();
        }

        /// <summary>
        /// Creeërt het de tickets voor een event afhankelijk van het aantal seats
        /// </summary>
        /// <param name="startingPrice">de prijs voor de 1e klasse</param>
        public void GenerateTickets(decimal startingPrice)
        {
            int classOne = (int)Decimal.Round((decimal)(AvailableSeats * 0.20));
            int classTwo = (int)Decimal.Round((decimal)(AvailableSeats * 0.30));
            int classThree = (int)Decimal.Round((decimal)(AvailableSeats * 0.50));

            int index = 0;
            for (; index < classOne; index++)
            {
                Ticket ticket = new Ticket(index, 1, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
                Tickets.Add(ticket);
            }
            for (; index < (classTwo + classOne); index++)
            {
                Ticket ticket = new Ticket(index, 2, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
                Tickets.Add(ticket);
            }
            for (; index < (classThree + classTwo + classOne); index++)
            {
                Ticket ticket = new Ticket(index, 3, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
                Tickets.Add(ticket);
            }

            // OPLOSSING
            while (Tickets.Count < AvailableSeats)
            {
                Ticket ticket = new Ticket(index, 3, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
                Tickets.Add(ticket);
            }
        }

        /// <summary>
        /// Het bestellen van tickets door een buyer voor een event
        /// </summary>
        /// <param name="amount">Het aantal gewenste tickets door de buyer</param>
        /// <param name="chairClass">De gewenste klasse van de klant</param>
        /// <param name="buyer">De klant</param>
        /// <returns>Of het bestellen gelukt is</returns>
        public bool OrderTickets(int amount, int chairClass, Buyer buyer)
        {
            List<int> ticketsIndexes = new List<int>();
            if (buyer == null) { return false; }
            if (string.IsNullOrEmpty(buyer.Name) || string.IsNullOrEmpty(buyer.Address) || buyer.Birth == null) { return false; }

            for (int i = 0; i < amount; i++)
            {
                foreach (Ticket t in Tickets)
                {
                    int ticketIndex = Tickets.IndexOf(t);

                    if (t.Buyer.Name == "none" && t.Class == chairClass && !ticketsIndexes.Contains(ticketIndex))
                    {
                        ticketsIndexes.Add(ticketIndex);
                        break;
                    }
                }
            }

            if (ticketsIndexes.Count == amount)
            {
                foreach (int index in ticketsIndexes)
                {
                    Tickets[index].SetNewBuyer(buyer);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verwijdert de tickets op basis van het ID
        /// </summary>
        /// <param name="ticketID">Het ticket dat moet worden verwijderd</param>
        public void DeleteTickets(int ticketID)
        {
            Ticket t = FindTicket(ticketID);

            int index = Tickets.IndexOf(t);
            decimal startingPrice = Tickets[index].StartingPrice;
            int klasse = Tickets[index].Class;
            Tickets[index] = new Ticket(ticketID, klasse, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
        }

        /// <summary>
        /// Verwijdert de tickets op basis van het naam van de koper
        /// </summary>
        /// <param name="buyerName">De koper waarvan de tickets verwijderd moeten worden</param>
        public void DeleteTickets(string buyerName)
        {
            while (Tickets.Exists(x => x.Buyer.Name == buyerName))
            {
                int index = Tickets.FindIndex(y => y.Buyer.Name == buyerName);
                decimal startingPrice = Tickets[index].StartingPrice;
                int klasse = Tickets[index].Class;
                Tickets[index] = new Ticket(index, klasse, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
            }
        }

        /// <summary>
        /// Vindt het ticket waarvan het ID wordt gevraagd
        /// </summary>
        /// <param name="id">Het ID van de ticket die moet worden gezocht en gevonden</param>
        /// <returns>Het ticket als het gevonden is, anders null</returns>
        public Ticket FindTicket(int id)
        {
            foreach (Ticket t in Tickets)
            {
                if (t.Id == id) { return t; }
            }
            return null;
        }

        /// <summary>
        /// Zoekt de index van een Ticket
        /// </summary>
        /// <param name="id">Het ID van de ticket die moet worden gezocht en gevonden</param>
        /// <returns>Het ticket als het gevonden is, anders null</returns>
        public int IndexOf(int id)
        {
            return Tickets.IndexOf(FindTicket(id));
        }
        
        /// <summary>
        /// Default sort-order
        /// </summary>
        /// <param name="obj"> object to sort with this object </param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj == null) { return 0; }
            Event e = (Event)obj;
            return this.Id.CompareTo(e.Id);
        }
        

        /// <summary>
        /// Sorteert de tickets op basis van de 2 gegevens
        /// </summary>
        /// <param name="order">Wat er moet worden gesorteerd (type)</param>
        /// <param name="sortBy">Hoe het moet worden gesorteerd(type)</param>
        public void SortTickets(Administration.Order order, Event.SortBy sortBy)
        {
            
            IComparer<Ticket> compareEvents = null;
            switch (sortBy)
            {
                case SortBy.Price:
                    if (order == Administration.Order.Ascending) { compareEvents = Ticket.SortPriceAscendingTicket(); }
                    else { compareEvents = Ticket.SortPriceDescendingTicket(); }
                    break;

                case SortBy.Buyername:
                    if (order == Administration.Order.Ascending) { compareEvents = Ticket.SortBuyernameAscendingTicket(); }
                    else { compareEvents = Ticket.SortBuyernameDescendingTicket(); }
                    break;
            }

            Tickets.Sort(compareEvents);
        }
        

        // These return the Comparer methods
        //-----------------------------------------------------------------------------------
        public static IComparer<Event> SortNameDescendingEvent()
        {
            return new NameDescendingComparer();
        }

        public static IComparer<Event> SortNameAscendingEvent()
        {
            return new NameAscendingComparer();
        }

        public static IComparer<Event> SortIdAscendingEvent()
        {
            return new IdAscendingComparer();
        }

        public static IComparer<Event> SortIdDescendingEvent()
        {
            return new IdDescendingComparer();
        }

        public static IComparer<Event> SortDateAscendingEvent()
        {
            return new DateAscendingComparer();
        }

        public static IComparer<Event> SortDateDescendingEvent()
        {
            return new DateDescendingComparer();
        }
        //-----------------------------------------------------------------------------------

        public override string ToString()
        {
            string eventStyle = "";
            if (this is Match) { eventStyle = "Match: "; }
            else { eventStyle = "Performance: "; }

            return eventStyle
            + Id
            + ", " + Name
            + ", " + Date
            + ", " + Location
            + ", Seats: " + AvailableSeats;
        }
    }
}
