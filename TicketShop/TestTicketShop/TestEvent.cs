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
            id = 10;
            date = new DateTime(2018, 9, 12);
            location = "HomeStreet 1";
            availableSeats = 599;
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
            e1.GenerateTickets(599);
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
            e2.GenerateTickets(startingPrice);
            int[] array = { 0, 0, 0 };
            foreach(Ticket ti in e1.Tickets)
            {
                if(ti.Class == 1)
                {
                    array[0]++;
                }
                else if(ti.Class == 2)
                {
                    array[1]++;
                }
                else if(ti.Class == 3)
                {
                    array[2]++;
                }
            }
            Assert.AreEqual(600, (array[0] + array[1] + array[2]));
        }
        [TestMethod]
        public void TestEventOrderTickets()
        {
            e1.OrderTickets(5, 2, buyer);
            int counter = 0;
            foreach(Ticket t in e1.Tickets)
            {
                if(t.Buyer.Name == buyer.Name)
                {
                    counter++;
                }
            }
            Assert.AreEqual(5, counter);
        }
        [TestMethod]
        public void TestEventFindTicket()
        {
            Ticket t = new Ticket(id, clas, seat, buyer, startingPrice);
            e1.OrderTickets(25, 1, buyer);
            Assert.AreEqual(t.Id, e1.FindTicket(id).Id);
            Assert.AreEqual(t.Class, e1.FindTicket(id).Class);

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
            int index = e1.IndexOf(5);
            Assert.AreEqual(5, index);
        }

        [TestMethod]
        public void TestEventDeleteTicketsByname()
        {
            e1.OrderTickets(5, 2, buyer);
            e1.DeleteTickets(name);
            foreach(Ticket t in e1.Tickets)
            {
                if(t.Buyer.Name == buyer.Name)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestEventDeleteTicketsByID()
        {
            e1.OrderTickets(20, 1, buyer);
            e1.DeleteTickets(id);
            Assert.AreNotEqual(e1.Tickets[20].Buyer.Name, buyer.Name);
        }

        [TestMethod]
        public void TestTicketsDefaultSort()
        {
            e1.Tickets.Sort();
            Ticket pre = e1.Tickets[0];
            foreach (Ticket t in e1.Tickets)
            {
                if (t.Id.CompareTo(pre.Id) == -1)
                {
                    Assert.Fail();
                }
                pre = t;
            }
        }

        [TestMethod]
        public void TestTicketsSortPriceDescending()
        {
            e1.SortTickets(Administration.Order.Descending, Event.SortBy.Price);
            Ticket pre = e1.Tickets[0];
            foreach (Ticket t in e1.Tickets)
            {
                if (t.Price.CompareTo(pre.Price) == 1)
                {
                    Assert.Fail();
                }
                pre = t;
            }
        }

        [TestMethod]
        public void TestTicketsSortPriceAscending()
        {
            e1.SortTickets(Administration.Order.Ascending, Event.SortBy.Price);
            Ticket pre = e1.Tickets[0];
            foreach (Ticket t in e1.Tickets)
            {
                if (t.Price.CompareTo(pre.Price) == -1)
                {
                    Assert.Fail();
                }
                pre = t;
            }
        }

        [TestMethod]
        public void TestTicketsSortBuyernameDescending()
        {
            e1.OrderTickets(20, 1, buyer);
            e1.OrderTickets(20, 2, new Buyer("Bram hoppa", Birth, Address));
            e1.SortTickets(Administration.Order.Descending, Event.SortBy.Buyername);
            Ticket pre = e1.Tickets[0];
            foreach (Ticket t in e1.Tickets)
            {
                if (string.Compare(t.Buyer.Name, pre.Buyer.Name) == 1)
                {
                    Assert.Fail();
                }
                pre = t;
            }
        }

        [TestMethod]
        public void TestTicketsSortBuyernameAscending()
        {
            e1.OrderTickets(20, 1, buyer);
            e1.OrderTickets(20, 2, new Buyer("Bram hoppa", Birth, Address));
            e1.SortTickets(Administration.Order.Ascending, Event.SortBy.Buyername);
            Ticket pre = e1.Tickets[0];
            foreach (Ticket t in e1.Tickets)
            {
                if (string.Compare(t.Buyer.Name, pre.Buyer.Name) == -1)
                {
                    Assert.Fail();
                }
                pre = t;
            }
        }

    }
}

