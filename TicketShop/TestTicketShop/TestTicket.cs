using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestTicket
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]
        public void TestTicketConstructor()
        {
            int id = 10;
            int clas = 2;
            int seat = 10;
            string name = "J. Johansson";
            DateTime Birth = new DateTime(2018, 9, 12);
            string Address = "HomeStreet 1";

            Buyer buyer = new Buyer(name, Birth, Address);
            Ticket t = new Ticket(id, clas, seat, buyer);

            Assert.AreEqual(name, buyer.Name);
            Assert.AreEqual(Birth, buyer.Birth);
            Assert.AreEqual(Address, buyer.Address);
            Assert.AreEqual(id, t.Id);
            Assert.AreEqual(clas, t.Class);
            Assert.AreEqual(seat, t.Seat);
            Assert.AreEqual(buyer, t.Buyer);
        }
        [TestMethod]
        public void TestTicketToString()
        {
            int id = 10;
            int clas = 2;
            int seat = 10;
            string name = "J. Johansson";
            DateTime Birth = new DateTime(2018, 9, 12);
            string Address = "HomeStreet 1";

            Buyer buyer = new Buyer(name, Birth, Address);
            Ticket t = new Ticket(id, clas, seat, buyer);
            string expected = (id + ", " + clas + ", " + seat + ", " + buyer);
            Assert.AreEqual(expected, t.ToString());
        }
    }
}
