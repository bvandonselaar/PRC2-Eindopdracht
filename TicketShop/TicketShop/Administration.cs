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

        public Administration()
        {
            Events = new List<Event>();
        }

        public bool AddEvent(Event eventx)
        {
            if (eventx == null) { return false; }

            Events.Add(eventx);
            return true;
        }

        public bool DeleteEvent(int id)
        {
            Event e = findEvent(id);
            if (e == null) { return false; }

            Events.Remove(e);
            return true;
        }

        public Event findEvent(int id)
        {
            foreach (Event e in Events)
            {
                if (e.Id == id) { return e; }
            }
            return null;
        }

        public int indexOf(int id)
        {
            return Events.IndexOf(findEvent(id));
        }

        public void Save(string filename)
        {
           /* - Deze moeten staan in de form
            * try
            {
                using (Stream output = File.Create(@filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(output, Events);
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("serialisationstream is null", ex);
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("Can not serialize, because of unserializable attributes", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid path", ex);
            }*/
        }

        public void Load(string filename)
        {/* - Deze moeten staan in de form
            try
            {
                using (Stream input = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Events = (List<Event>)formatter.Deserialize(input);
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("The deserializationStream is null", ex);
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("Can not deserialize, because of wrong values", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid path", ex);
            }*/
        }

        public void Export(string filename)
        {/* - Deze moeten staan in de form
            try
            {
                using (StreamWriter writer = new StreamWriter(@filename))
                {
                    foreach (Event e in Events)
                    {
                        writer.WriteLine(e.ToString());
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException("Export error", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Path is null", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid path", ex);
            }*/
        }
    }
}
