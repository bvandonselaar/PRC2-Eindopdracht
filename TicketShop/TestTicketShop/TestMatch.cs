using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestMatch
    {
        string name;
        string player;
        string opponent;
        int id;
        DateTime date;
        string location;
        int availableSeats;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "J. Johansson";
            player = "M. Jordan";
            opponent = "K. Bryant";
            id = 10;
            date = new DateTime(2018, 9, 12);
            location = "HomeStreet 1";
            availableSeats = 15000;
        }
        [TestMethod]
        public void TestMatchConstructor()
        {
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
            Match m = new Match(name, id, date, location, availableSeats, player, opponent);
            string expected = ("Match: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + player + ", " + opponent);
            Assert.AreEqual(expected, m.ToString());
        }
    }
}
