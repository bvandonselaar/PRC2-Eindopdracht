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
            Event e1 = new Performance("a", 1, date, location, availableSeats, artist, demands);
            Event e2 = new Performance("b", 2, date, location, availableSeats, artist, demands);
            Event e3 = new Performance("c", 3, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);
            a.AddEvent(e2);
            a.AddEvent(e3);
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
            Assert.AreEqual(3, a.Events.Count);

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

            Assert.AreEqual(e1, a.FindEvent(id));
        }
        [TestMethod]
        public void TestAdminFindEventNotFound()
        {
            Event e1 = new Performance(name, id, date, location, availableSeats, artist, demands);
            a.AddEvent(e1);

            Assert.AreEqual(null, a.FindEvent(30));
        }

        [TestMethod]
        public void TestEventDefaultSort()
        {
            a.Events.Sort();
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {
                if (e.Id.CompareTo(pre.Id) == -1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortNameAscending()
        {

            a.SortEvents(Administration.Order.Ascending, Administration.SortBy.Name);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {
                
                if(string.Compare(e.Name, pre.Name) == -1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortNameDescending()
        {

            a.SortEvents(Administration.Order.Descending, Administration.SortBy.Name);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {

                if (string.Compare(e.Name, pre.Name) == 1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortIdAscending()
        {
            a.SortEvents(Administration.Order.Ascending, Administration.SortBy.Id);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {

                if (e.Id.CompareTo(pre.Id) == -1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortIdDescending()
        {
            a.SortEvents(Administration.Order.Descending, Administration.SortBy.Id);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {

                if (e.Id.CompareTo(pre.Id) == 1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortDateAscending()
        {
            a.SortEvents(Administration.Order.Ascending, Administration.SortBy.Date);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {

                if (e.Date.CompareTo(pre.Date) == -1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }

        [TestMethod]
        public void TestEventSortDateDescending()
        {
            a.SortEvents(Administration.Order.Descending, Administration.SortBy.Date);
            Event pre = a.Events[0];
            foreach (Event e in a.Events)
            {

                if (e.Date.CompareTo(pre.Date) == 1)
                {
                    Assert.Fail();
                }
                pre = e;
            }
        }
    }
}
