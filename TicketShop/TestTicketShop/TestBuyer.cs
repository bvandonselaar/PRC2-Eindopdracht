using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestBuyer
    {
        [TestInitialize]
        public void TestInitialize()
        {
            
        }
        [TestMethod]
        public void TestBuyerConstructor()
        {
            string name = "J. Johansson";
            DateTime Birth = new DateTime(2018, 9, 12);
            string Address = "HomeStreet 1";

            Buyer buyer = new Buyer(name, Birth, Address);

            Assert.AreEqual(name, buyer.Name);
            Assert.AreEqual(Birth, buyer.Birth);
            Assert.AreEqual(Address, buyer.Address);
        }
        [TestMethod]
        public void TestBuyerToString()
        {
            string name = "J. Johansson";
            DateTime Birth = new DateTime(2018, 9, 12);
            string Address = "HomeStreet 1";

            Buyer buyer = new Buyer(name, Birth, Address);
            string expected = ("Buyer: " + name + ", " + Birth.ToShortDateString() + ", " + Address);
            Assert.AreEqual(expected, buyer.ToString());

        }
    }
}
