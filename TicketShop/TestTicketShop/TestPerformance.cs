using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestPerformance
    {
        string name;
        string artist;
        string demands;
        int id;
        DateTime date;
        string location;
        int availableSeats;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "J. Johansson";
            artist = "M. Jackson";
            demands = "White color";
            id = 10;
            date = new DateTime(2018, 9, 12);
            location = "HomeStreet 1";
            availableSeats = 15000;

        }
        [TestMethod]
        public void TestPerformanceConstructor()
        {
            Performance p = new Performance(name, id, date, location, availableSeats, artist, demands);

            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(artist, p.Artist);
            Assert.AreEqual(demands, p.Demands);
            Assert.AreEqual(id, p.Id);
            Assert.AreEqual(location, p.Location);
            Assert.AreEqual(availableSeats, p.AvailableSeats);
            Assert.AreEqual(date, p.Date);
        }
        [TestMethod]
        public void TestPerformanceToString()
        {
            Performance p = new Performance(name, id, date, location, availableSeats, artist, demands);
            string expected = ("Performance: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + artist + ", " + demands);

            Assert.AreEqual(expected, p.ToString());
        }
    }
}
