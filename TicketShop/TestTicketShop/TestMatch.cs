using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestMatch
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]
        public void TestMatchConstructor()
        {
            string name = "J. Johansson";
            string player = "M. Jordan";
            string opponent = "K. Bryant";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;

            Match m = new Match(name, id, date, location, availableSeats, player, opponent);

            Assert.AreEqual(name, m.Name);
            Assert.AreEqual(player, m.Player);
            Assert.AreEqual(opponent, m.Opponent);
            Assert.AreEqual(id, m.Id);
            Assert.AreEqual(location, m.Location);
            Assert.AreEqual(availableSeats, m.AvailableSeats);
            Assert.AreEqual(date, m.Date);

        }
        [TestMethod]
        public void TestMatchToString()
        {
            string name = "J. Johansson";
            string player = "M. Jordan";
            string opponent = "K. Bryant";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            int Price = 0;

            Match m = new Match(name, id, date, location, availableSeats, player, opponent);
            string expected = ("Match: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats + ", Price: €" + Price);
            Assert.AreEqual(expected, m.ToString());
        }
    }
}
