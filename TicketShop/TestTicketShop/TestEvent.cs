using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestEvent
    {

        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]
        public void TestEventConstructor()
        {
            string name = "J. Johansson";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            string artist = "M. Jackson";
            string demands = "White color";
            string player = "Red Sox";
            string opponent = "Yankees";

            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            Event e2 = new Match(name, id, date, location, availableSeats, player, opponent);

            Assert.AreEqual(name, e1.Name);
            Assert.AreEqual(id, e1.Id);
            Assert.AreEqual(location, e1.Location);
            Assert.AreEqual(availableSeats, e1.AvailableSeats);
            Assert.AreEqual(date, e1.Date);

        }
        [TestMethod]
        public void TestEventToString()
        {
            string name = "J. Johansson";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            int Price = 0;
            string artist = "M. Jackson";
            string demands = "White color";
            string player = "Red Sox";
            string opponent = "Yankees";

            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            Event e2 = new Match(name, id, date, location, availableSeats, player, opponent);
            string expected = ("Performance: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats + ", Price: €" + Price);
            string expected2 = ("Match: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats + ", Price: €" + Price);

            Assert.AreEqual(expected, e1.ToString());
            Assert.AreEqual(expected2, e2.ToString());
        }

        [TestMethod]
        public void TestEventFindTicket()
        {
        }


        [TestMethod]
        public void TestEventFindBuyer()
        {
        }


        [TestMethod]
        public void TestEventDeleteTicketsByname()
        {
        }

        [TestMethod]
        public void TestEventDeleteTicketsByID()
        {
        }
        [TestMethod]
        public void TestEventOrderTickets()
        {
        }

    }
}

