using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop
{
    [Serializable]
    public class Buyer
    {
        public string Name { get; private set; }
        public DateTime Birth { get; private set; }
        public string Address { get; private set; }

        public Buyer(string name, DateTime birth, string address)
        {
            Name = name;
            Birth = birth;
            Address = address;
        }
        public override string ToString()
        {
            return "Buyername: " + Name + " "
            + "\nBirthday: " + Birth.ToShortDateString() + " "
            + "\nAddress: " + Address; 
        }
    }
}
