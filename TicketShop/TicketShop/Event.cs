using System;
using System.Collections.Generic;

namespace TicketShop
{
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

        public void generateTickets (decimal startingPrice)
        {
            int classOne = (int)Decimal.Round((decimal)(AvailableSeats * 0.20));
            int classTwo = (int)Decimal.Round((decimal)(AvailableSeats * 0.30));
            int classThree = (int)Decimal.Round((decimal)(AvailableSeats * 0.50));

            /* OPLOSSING 1 (delete wat hier boven staat natuurlijk)
            int classOne = (int)Decimal.Round((decimal)(AvailableSeats * 0.20 + 0.5));
            int classTwo = (int)Decimal.Round((decimal)(AvailableSeats * 0.30 + 0.5));
            int classThree = (int)Decimal.Round((decimal)(AvailableSeats * 0.50 + 0.5));
            */

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

            /* OPLOSSING 2
            while(Tickets.Count < AvailableSeats)
            {
                Ticket ticket = new Ticket(index, 3, index, new Buyer("none", new DateTime(1, 1, 1), "none"), startingPrice);
                Tickets.Add(ticket);
            }
            */
        }

        public bool orderTickets(int amount, int chairClass, Buyer buyer)
        {
            List<int> ticketsIndexes = new List<int>();

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

        public bool DeleteTickets(int ticketID)
        {
            Ticket t = findTicket(ticketID);
            if (t == null) { return false; }

            int index = Tickets.IndexOf(t);
            decimal startingPrice = Tickets[index].StartingPrice;
            Tickets[index] = new Ticket(ticketID, 0, index, new Buyer("none", new DateTime(0, 0, 0), "none"), startingPrice);
            return true;
        }

        public bool DeleteTickets(string buyerName)
        {
            while(Tickets.Exists(x => x.Buyer.Name == buyerName))
            {
                int index = Tickets.FindIndex(y => y.Buyer.Name == buyerName);
                decimal startingPrice = Tickets[index].StartingPrice;
                Tickets[index] = new Ticket(index, 0, index, new Buyer("none", new DateTime(0, 0, 0), "none"), startingPrice);
            }
            return true;
        }

        public Ticket findTicket(int id)
        {
            foreach (Ticket t in Tickets)
            {
                if (t.Id == id) { return t; }
            }
            return null;
        }

        public int indexOf(int id)
        {
            return Tickets.IndexOf(findTicket(id));
        }

        public Buyer findBuyer(string name)
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
    }
}
