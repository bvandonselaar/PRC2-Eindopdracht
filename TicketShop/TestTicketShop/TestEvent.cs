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

        int clas;
        int seat;
        DateTime Birth;
        string Address;
        decimal startingPrice;
        Buyer buyer;
        Event e1; 
        Event e2; 

        [TestInitialize]
        public void TestInitialize()
        {
            name = "J. Johansson";
            id = 1;
            date = new DateTime(2018, 9, 12);
            location = "HomeStreet 1";
            availableSeats = 1000;
            artist = "M. Jackson";
            demands = "White color";
            player = "Red Sox";
            opponent = "Yankees";

            clas = 1;
            seat = 10;
            Birth = new DateTime(2018, 9, 12);
            Address = "HomeStreet 1";
            startingPrice = 100;
            buyer = new Buyer(name, Birth, Address);
            e1= new Performance(name, id, date, location, availableSeats, artist, demands);
            e2 = new Match(name, id, date, location, availableSeats, player, opponent);

        }
        [TestMethod]
        public void TestEventConstructor()
        {
            Assert.AreEqual(name, e1.Name);
            Assert.AreEqual(id, e1.Id);
            Assert.AreEqual(location, e1.Location);
            Assert.AreEqual(availableSeats, e1.AvailableSeats);
            Assert.AreEqual(date, e1.Date);

        }
        [TestMethod]
        public void TestEventToString()
        {
            string expected = ("Performance: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + artist + ", " + demands);
            string expected2 = ("Match: " + id + ", " + name + ", " + date + ", " + location + ", Seats: " + availableSeats +  ", " + player + ", " + opponent);

            Assert.AreEqual(expected, e1.ToString());
            Assert.AreEqual(expected2, e2.ToString());
        }

        [TestMethod]
        public void TestEventGenerateTickets()
        { 
            Ticket t = new Ticket(id, clas, seat, buyer, startingPrice);
            Assert.AreEqual(1000, e1.AvailableSeats);
            //Kijken of hij x seats heeft per klasse?, Afmaken!
        }
        [TestMethod]
        public void TestEventOrderTickets()
        {
            e1.OrderTickets(5, 2, buyer);
            //kijken of hij x sets heeft, Afmaken!
        }
        [TestMethod]
        public void TestEventFindTicket()
        {
            Ticket t = new Ticket(id, clas, seat, buyer, startingPrice);
            e1.OrderTickets(25, 2, buyer);
            //Deze werkt nog niet, afmaken!
            Assert.AreEqual(id, e1.FindTicket(id));
            Assert.AreEqual(10, e1.FindTicket(id));
            Assert.AreEqual(t.Id, e1.FindTicket(id));

        }
        [TestMethod]
        public void TestEventFindTicketCannotfind()
        {
            int id2 = 9999;
            Ticket t = new Ticket(id2, clas, seat, buyer, startingPrice);
            e1.FindTicket(id2);
            Assert.AreEqual(null, e1.FindTicket(id2));
        }

        [TestMethod]
        public void TestEventIndexOfTicket()
        {
            //Werkt niet, Afmaken!
            Assert.AreEqual(1, e1.IndexOf(id));
        }
        [TestMethod]
        public void TestEventFindBuyer()
        {
            e1.OrderTickets(5, 2, buyer);
            Assert.AreEqual(buyer, e1.FindBuyer(name));
            //Werkt niet, Afmaken
        }

        [TestMethod]
        public void TestEventDeleteTicketsByname()
        {
            e1.OrderTickets(5, 2, buyer);
            e1.DeleteTickets(name);
            Assert.AreEqual(0, e1.Buyers);
            //Werkt ook niet, afmaken!
        }

        [TestMethod]
        public void TestEventDeleteTicketsByID()
        {
            //Geeft direct foutcode aan, afmaken!
            e1.DeleteTickets(id);
        }
        //Unittests maken voor de Nested classes van Icomparer?

    }
}

