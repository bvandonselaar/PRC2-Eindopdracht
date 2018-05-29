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
                    Tickets[index].Buyer = buyer;
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
        /// Zoekt of het een koper kan vinden met de naam
        /// </summary>
        /// <param name="name">Het ID van de ticket die moet worden gezocht en gevonden</param>
        /// <returns>De koper als deze is gevonden, anders null</returns>
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

        /// <summary>
        /// Sorteert op naam oplopend (alfabetisch)
        /// </summary>
        public class NameDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return string.Compare(y.Name, x.Name);
            }
        }
        /// <summary>
        /// Sorteert op naam aflopend (alfabetisch)
        /// </summary>
        public class NameAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }
        /// <summary>
        /// Sorteert op ID oplopend (laagste eerst)
        /// </summary>
        public class IdAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return x.Id.CompareTo(y.Id);
            }
        }
        /// <summary>
        /// Sorteert op ID aflopend (hoogste eerst)
        /// </summary>
        public class IdDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return y.Id.CompareTo(x.Id);
            }
        }
        /// <summary>
        /// Sorteert op datum oplopend (nieuwste eerst)
        /// </summary>
        public class DateAscendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return x.Date.CompareTo(y.Date);
            }
        }
        /// <summary>
        /// Sorteert op datum aflopend (oudste eerst)
        /// </summary>
        public class DateDescendingComparer : IComparer<Event>
        {
            int IComparer<Event>.Compare(Event x, Event y)
            {
                return y.Date.CompareTo(x.Date);
            }
        }
    }
}
