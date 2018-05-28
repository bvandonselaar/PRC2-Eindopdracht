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

        public bool AddEvent(Event eventx)
        {
            if (eventx == null) { return false; }

            Events.Add(eventx);
            return true;
        }

        public bool DeleteEvent(int id)
        {
            Event e = FindEvent(id);
            if (e == null) { return false; }

            Events.Remove(e);
            return true;
        }

        public Event FindEvent(int id)
        {
            foreach (Event e in Events)
            {
                if (e.Id == id) { return e; }
            }
            return null;
        }

        public int IndexOf(int id)
        {
            return Events.IndexOf(FindEvent(id));
        }

        public void Save(string filename)
        {
            using (Stream output = File.Create(@filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, Events);
            }
        }

        public void Load(string filename)
        {
            using (Stream input = File.OpenRead(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Events = (List<Event>)formatter.Deserialize(input);
            }
        }

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
