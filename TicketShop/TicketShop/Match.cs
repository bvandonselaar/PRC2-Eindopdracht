using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    public class Match : Event
    {
        public string Player { get; private set; }
        public string Opponent { get; private set; }

        public Match(string name, int id, DateTime date, string location, int availableSeats, string player, string opponent) :base(name, id, date, location, availableSeats)
        {
            Player = player;
            Opponent = opponent;
        }

        public override string ToString()
        {
            return base.ToString()
            + ", " + Player
            + ", " + Opponent;
        }
    }
}
