using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestAdministration
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]
        public void TestAdminAddEventCorrect()
        {
            Administration a = new Administration();
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

            Assert.AreEqual(true, a.AddEvent(e1));
            Assert.AreEqual(true, a.AddEvent(e2));

        }
        [TestMethod]
        public void TestAdminAddEventIncorrectByNull()
        {
            Administration a = new Administration();

            Event e1 = null;

            Assert.AreEqual(false, a.AddEvent(e1));
        }
        [TestMethod]
        public void TestAdminDeleteEventCorrect()
        {
            Administration a = new Administration();

            string name = "J. Johansson";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            string artist = "M. Jackson";
            string demands = "White color";

            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1); 

            Assert.AreEqual(true, a.DeleteEvent(id));
        }
        [TestMethod]
        public void TestAdminDeleteEventIncorrectByNull()
        {
            Administration a = new Administration();

            int id = 0;
            a.DeleteEvent(id);

            Assert.AreEqual(false, a.DeleteEvent(id));
        }
        [TestMethod]
        public void TestAdminFindEventFound()
        {
            Administration a = new Administration();
            
            string name = "J. Johansson";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            string artist = "M. Jackson";
            string demands = "White color";

            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);
            Assert.AreEqual(e1, a.findEvent(id));
        }
        [TestMethod]
        public void TestAdminFindEventNotFound()
        {
            Administration a = new Administration();

            string name = "J. Johansson";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            string artist = "M. Jackson";
            string demands = "White color";

            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);
            Assert.AreEqual(null, a.findEvent(30));
        }
    }
}
