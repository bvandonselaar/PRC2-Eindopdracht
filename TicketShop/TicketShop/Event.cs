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
        public abstract double Price { get; }
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

            for (int i = 0; i < availableSeats; i++)
            {
                Ticket ticket = new Ticket(i, 1, i, new Buyer("none", new DateTime(1,1,1), "none"));
                Tickets.Add(ticket);
            }
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
            Tickets[index] = new Ticket(ticketID, 0, index, new Buyer("none", new DateTime(0, 0, 0), "none"));
            return true;
        }

        public bool DeleteTickets(string buyerName)
        {
            while(Tickets.Exists(x => x.Buyer.Name == buyerName))
            {
                int index = Tickets.FindIndex(y => y.Buyer.Name == buyerName);
                Tickets[index] = new Ticket(index, 0, index, new Buyer("none", new DateTime(0, 0, 0), "none"));
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
            + ", Seats: " + AvailableSeats
            + ", Price: €" + Price;
        }
    }
}
