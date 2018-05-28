using System;
using System.Collections.Generic;
using System.Collections;

namespace TicketShop
{
    [Serializable]
    public abstract class Event
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public int AvailableSeats { get; private set; }
        public List<Ticket> Tickets { get; private set; }
        public List<Buyer> Buyers { get; private set; }

        public Event(string name, int id, DateTime date, string location, int availableSeats)
        {
            Name = name;
            Id = id;
            Date = date;
            Location = location;
            AvailableSeats = availableSeats;
            Buyers = new List<Buyer>();
            Tickets = new List<Ticket>();
        }


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
                    Tickets[index].Buyer = buyer;
                }
                return true;
            }
            return false;
        }

        public void DeleteTickets(int ticketID)
        {
            Ticket t = FindTicket(ticketID);

            int index = Tickets.IndexOf(t);
            decimal startingPrice = Tickets[index].StartingPrice;
            int klasse = Tickets[index].Class;
            Tickets[index] = new Ticket(ticketID, klasse, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
        }

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

        public Ticket FindTicket(int id)
        {
            foreach (Ticket t in Tickets)
            {
                if (t.Id == id) { return t; }
            }
            return null;
        }

        public int IndexOf(int id)
        {
            return Tickets.IndexOf(FindTicket(id));
        }

        public Buyer FindBuyer(string name)
        {
            foreach (Buyer b in Buyers)
            {
                if (b.Name == name) { return b; }
            }
            return null;
        }

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


        public class NameDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return string.Compare(y.Name, x.Name);
            }
        }

        public class NameAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }

        public class IdAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return x.Id.CompareTo(y.Id);
            }
        }

        public class IdDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return y.Id.CompareTo(x.Id);
            }
        }

        public class DateAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return x.Date.CompareTo(y.Date);
            }
        }

        public class DateDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return y.Date.CompareTo(x.Date);
            }
        }
    }
}
