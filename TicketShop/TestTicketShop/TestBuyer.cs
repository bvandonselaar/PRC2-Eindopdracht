using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketShop;

namespace TestTicketShop
{
    [TestClass]
    public class TestBuyer
    {
        string name;
        DateTime Birth;
        string Address;
        [TestInitialize]
        public void TestInitialize()
        {
            name = "J. Johansson";
            Birth = new DateTime(2018, 9, 12);
            Address = "HomeStreet 1";
        }
        [TestMethod]
        public void TestBuyerConstructor()
        {
            Buyer buyer = new Buyer(name, Birth, Address);

            Assert.AreEqual(name, buyer.Name);
            Assert.AreEqual(Birth, buyer.Birth);
            Assert.AreEqual(Address, buyer.Address);
        }
        [TestMethod]
        public void TestBuyerToString()
        {
            Buyer buyer = new Buyer(name, Birth, Address);
            string expected = ("Buyer: " + name + ", " + Birth.ToShortDateString() + ", " + Address);
            Assert.AreEqual(expected, buyer.ToString());

        }
    }
}
