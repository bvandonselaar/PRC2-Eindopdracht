using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace TicketShop
{
    public class Administration
    {

        public List<Event> Events { get; private set; }

        public enum Order : byte { Ascending, Descending };
        public enum SortBy : byte { Name, Id, Date };

        public Administration()
        {
            Events = new List<Event>();
        }
        /// <summary>
        /// Sorteert de events op basis van de 2 gegevens
        /// </summary>
        /// <param name="order">Wat er moet worden gesorteerd (type)</param>
        /// <param name="sortBy">Hoe het moet worden gesorteerd(type)</param>
        public void Sort(Order order, SortBy sortBy)
        {
            IComparer<Event> compareEvents = null;
            switch (sortBy)
            {
                case SortBy.Name:
                    if (order == Order.Ascending) { compareEvents = new Event.NameAscendingComparer(); }
                    else { compareEvents = new Event.NameDescendingComparer(); }
                    break;

                case SortBy.Id:
                    if (order == Order.Ascending) { compareEvents = new Event.IdAscendingComparer(); }
                    else { compareEvents = new Event.IdDescendingComparer(); }
                    break;

                case SortBy.Date:
                    if (order == Order.Ascending) { compareEvents = new Event.DateAscendingComparer(); }
                    else { compareEvents = new Event.DateDescendingComparer(); }
                    break;
            }

            Events.Sort(compareEvents);
        }
        /// <summary>
        /// Maakt een nieuw event aan
        /// </summary>
        /// <param name="eventx">het event dat moet worden toegevoegd</param>
        /// <returns>Of het toevoegen gelukt is</returns>
        public bool AddEvent(Event eventx)
        {
            if (eventx == null) { return false; }

            Events.Add(eventx);
            return true;
        }
        /// <summary>
        /// Verwijdert een Event 
        /// </summary>
        /// <param name="id">Het ID van het event dat verwijderd moet worden</param>
        /// <returns>of het verwijderen gelukt is</returns>
        public bool DeleteEvent(int id)
        {
            Event e = FindEvent(id);
            if (e == null) { return false; }

            Events.Remove(e);
            return true;
        }
        /// <summary>
        /// Zoekt en vindt een event met het meegegeven ID
        /// </summary>
        /// <param name="id">Het ID van het event dat moet worden gezocht</param>
        /// <returns>of het event gevonden is en indien gevonden het hele event</returns>
        public Event FindEvent(int id)
        {
            foreach (Event e in Events)
            {
                if (e.Id == id) { return e; }
            }
            return null;
        }
        /// <summary>
        /// Zoekt de index in de Events van het meegegeven ID
        /// </summary>
        /// <param name="id">Het ID waar de index van moet worden gevonden</param>
        /// <returns>De index van het gezochte Event</returns>
        public int IndexOf(int id)
        {
            return Events.IndexOf(FindEvent(id));
        }
        /// <summary>
        /// Slaat de gegevens op in een file
        /// </summary>
        /// <param name="filename">Hoe het bestand gaat heten</param>
        public void Save(string filename)
        {
            using (Stream output = File.Create(@filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, Events);
            }
        }
        /// <summary>
        /// Laad de gegevens uit een file en zet ze in de events
        /// </summary>
        /// <param name="filename">de naam van het bestand die je laadt</param>
        public void Load(string filename)
        {
            using (Stream input = File.OpenRead(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Events = (List<Event>)formatter.Deserialize(input);
            }
        }
        /// <summary>
        /// Schrijft de gegevens weg naar een file
        /// </summary>
        /// <param name="filename">de naam van de file waarin het wordt opgeslagen</param>
        public void Export(string filename)
        {

            using (StreamWriter writer = new StreamWriter(@filename))
            {
                foreach (Event e in Events)
                {
                    writer.WriteLine(e.ToString());
                    writer.WriteLine("{");
                    foreach(Ticket t in e.Tickets)
                    {
                        writer.WriteLine("\t" + t.ToString());
                    }
                    writer.WriteLine("}");
                    writer.WriteLine("\n");
                }
            }
        }
    }
}
