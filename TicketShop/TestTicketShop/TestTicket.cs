using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestTicket
    {
        int id;
        int clas;
        int seat;
        string name;
        DateTime Birth;
        string Address;
        [TestInitialize]
        public void TestInitialize()
        {
            id = 10;
            clas = 2;
            seat = 10;
            name = "J. Johansson";
            Birth = new DateTime(2018, 9, 12);
            Address = "HomeStreet 1";
        }
        [TestMethod]
        public void TestTicketConstructor()
        {
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
            Buyer buyer = new Buyer(name, Birth, Address);
            Ticket t = new Ticket(id, clas, seat, buyer);
            string expected = (id + ", " + clas + ", " + seat + ", " + buyer);
            Assert.AreEqual(expected, t.ToString());
        }
    }
}
