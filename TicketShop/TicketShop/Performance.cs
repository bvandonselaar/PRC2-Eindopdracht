using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    [Serializable]
    public class Performance : Event
    {
        public string Artist { get; private set; }
        public string Demands { get; private set; }

        public Performance(string name, int id, DateTime date, string location, int availableSeats, string artist, string demands):base(name, id, date, location, availableSeats)
        {
            Artist = artist;
            Demands = demands;
        }

        public override string ToString()
        {
            return base.ToString()
            + ", " + Artist
            + ", " + Demands;
        }
    }
}
