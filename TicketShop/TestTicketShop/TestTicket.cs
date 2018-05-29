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
        decimal startingPrice;
        int clas2;
        [TestInitialize]
        public void TestInitialize()
        {
            id = 10;
            clas = 1;
            seat = 10;
            name = "J. Johansson";
            Birth = new DateTime(2018, 9, 12);
            Address = "HomeStreet 1";
            startingPrice = 100;
            clas2 = 3;
        }
        [TestMethod]
        public void TestTicketConstructor()
        {
            Buyer buyer = new Buyer(name, Birth, Address);
            Ticket t = new Ticket(id, clas, seat, buyer, startingPrice);

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
            decimal x = Decimal.Round(startingPrice/clas2, 2);
            Buyer buyer = new Buyer(name, Birth, Address);
            Ticket t = new Ticket(id, clas, seat, buyer, startingPrice);
            string expected = ("Id: "+ id + ", " + clas + ", " + seat + ", " + buyer + ", €" + startingPrice);
            Ticket t2 = new Ticket(id, clas2, seat, buyer, startingPrice);
            string expected2 = ("Id: " + id + ", " + clas2 + ", " + seat + ", " + buyer + ", €" + x.ToString().Replace(",", "."));
            Assert.AreEqual(expected, t.ToString());
            Assert.AreEqual(expected2, t2.ToString());
            
        }
    }
}
