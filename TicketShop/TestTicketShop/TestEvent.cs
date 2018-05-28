using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestEvent
    {
        string name;
        int id;
        DateTime date;
        string location;
        int availableSeats;
        string artist;
        string demands;
        string player;
        string opponent;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "J. Johansson";
            id = 10;
            date = new DateTime(2018, 9, 12);
            location = "HomeStreet 1";
            availableSeats = 15000;
            artist = "M. Jackson";
            demands = "White color";
            player = "Red Sox";
            opponent = "Yankees";
        }
        [TestMethod]
        public void TestEventConstructor()
        {
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
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            Event e2 = new Match(name, id, date, location, availableSeats, player, opponent);
            string expected = ("Performance: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + artist + ", " + demands);
            string expected2 = ("Match: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + player + ", " + opponent);

            Assert.AreEqual(expected, e1.ToString());
            Assert.AreEqual(expected2, e2.ToString());
        }

        [TestMethod]
        public void TestEventOrderTickets()
        {
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


    }
}

