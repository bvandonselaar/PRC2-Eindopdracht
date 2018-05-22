using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestAdministration
    {
        // these are needed on every test
        Administration a;
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
            a = new Administration();
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
        public void TestAdminAddEventCorrect()
        {
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            Event e2 = new Match(name, id, date, location, availableSeats, player, opponent);

            Assert.AreEqual(true, a.AddEvent(e1));
            Assert.AreEqual(true, a.AddEvent(e2));

        }
        [TestMethod]
        public void TestAdminAddEventIncorrectByNull()
        {
            Event e1 = null;

            Assert.AreEqual(false, a.AddEvent(e1));
        }
        [TestMethod]
        public void TestAdminDeleteEventCorrect()
        {
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1); 

            Assert.AreEqual(true, a.DeleteEvent(id));
            Assert.AreEqual(0, a.Events.Count);

        }
        [TestMethod]
        public void TestAdminDeleteEventIncorrectByNull()
        {
            int id = 0;
            a.DeleteEvent(id);

            Assert.AreEqual(false, a.DeleteEvent(id));
        }
        [TestMethod]
        public void TestAdminFindEventFound()
        {           
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);

            Assert.AreEqual(e1, a.findEvent(id));
        }
        [TestMethod]
        public void TestAdminFindEventNotFound()
        {
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);

            Assert.AreEqual(null, a.findEvent(30));
        }
    }
}
