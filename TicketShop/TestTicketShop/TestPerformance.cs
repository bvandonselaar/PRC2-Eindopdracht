using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestPerformance
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }
        [TestMethod]
        public void TestPerformanceConstructor()
        {
            string name = "J. Johansson";
            string artist = "M. Jackson";
            string demands = "White color";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;

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
            string name = "J. Johansson";
            string artist = "M. Jackson";
            string demands = "White color";
            int id = 10;
            DateTime date = new DateTime(2018, 9, 12);
            string location = "HomeStreet 1";
            int availableSeats = 15000;
            int Price = 0;

            Performance p = new Performance(name, id, date, location, availableSeats, artist, demands);
            string expected = ("Performance: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats + ", Price: €" + Price);

            Assert.AreEqual(expected, p.ToString());

        }
    }
}
