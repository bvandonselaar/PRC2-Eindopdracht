using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketShop
{
    public partial class ticketShopForm : Form
    {
        Administration administration;
        List<TabPage> tabs;
        int selectedEventIndex = -1;
        int selectedTicketIndex = -1;

        enum Tab : byte { Events, addNewEvent, Tickets, orderTickets };

        public ticketShopForm()
        {
            InitializeComponent();
            administration = new Administration();
            tabs = new List<TabPage>();
            saveTabs();
            groupBox_match.Visible = false;
            groupBox_performance.Visible = false;
        }

        private void saveTabs()
        {
            foreach (TabPage t in tabControl_administration.TabPages)
            {
                tabs.Add(t);
            }
            int amountOfTabs = tabControl_administration.TabPages.Count;
            for (int i = 1; i < amountOfTabs; i++)
            {
                tabControl_administration.TabPages.Remove(tabs[i]);
            }
        }

        private void loadEvents()
        {
            listBox_events.Items.Clear();
            foreach (Event e in administration.Events)
            {
                listBox_events.Items.Add(e.ToString());
            }
        }

        private void loadTickets(int index)
        {
            listBox_tickets.Items.Clear();
            foreach (Ticket t in administration.Events[index].Tickets)
            {
                Console.WriteLine(t.ToString());
                listBox_tickets.Items.Add(t.ToString());
            }
        }

        private void loadTab(Tab tabIndex)
        {
            tabControl_administration.TabPages.Add(tabs[(int)tabIndex]);
            tabControl_administration.TabPages.Remove(tabControl_administration.TabPages[0]);
        }

        private void button_newEvent_Click(object sender, EventArgs e)
        {
            loadTab(Tab.addNewEvent);
            comboBox_eventType.SelectedIndex = 0;
        }

        private void button_addNewEvent_Click(object sender, EventArgs e)
        {
            if (findAvailableId(out int id))
            {
                string name = textBox_eventName.Text;
                DateTime date = dateTimePicker_date.Value;
                string location = textBox_eventLocation.Text;
                int seats = (int)numeric_seats.Value;

                Event eventx;
                if (comboBox_eventType.SelectedItem.ToString() == "Match")
                {
                    string player = textBox_player.Text;
                    string opponent = textBox_opponent.Text;
                    eventx = new Match(name, id, date, location, seats, player, opponent);
                }
                else
                {
                    string artist = textBox_eventArtist.Text;
                    string demands = textBox_demands.Text;
                    eventx = new Performance(name, id, date, location, seats, artist, demands);
                }

                eventx.GenerateTickets(numeric_price.Value);
                administration.AddEvent(eventx);
                loadTab(Tab.Events);
                loadEvents();
            }
            else
            {
                MessageBox.Show("Could not add Event, out of Ids");
            }
        }

        private bool findAvailableId(out int id)
        {
            bool foundId = true;
            id = 0;
            for (int i = 0; i < 1000; i++)
            {
                foreach(Event e in administration.Events)
                {
                    if(e.Id == i)
                    {
                        foundId = false;
                        break;
                    }
                    else
                    {
                        foundId = true;
                    }
                }

                if (foundId)
                {
                    id = i;
                    break;
                }
            }
            return foundId;
        }

        private void button_newEventBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Events);
            loadEvents();
        }

        private void comboBox_eventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_eventType.SelectedItem.ToString() == "Match")
            {
                groupBox_match.Visible = true;
                groupBox_performance.Visible = false;
            }
            else
            {
                groupBox_match.Visible = false;
                groupBox_performance.Visible = true;
            }
        }

        private void button_deleteEvent_Click(object sender, EventArgs e)
        {
            if (selectedEventIndex != -1)
            {
                administration.DeleteEvent(selectedEventIndex);
                loadEvents();
            }
            else { MessageBox.Show("Select Event"); }
        }

        private int getIdFromListBoxItem(ListBox data)
        {
            if (data.SelectedItem != null)
            {
                string part = data.SelectedItem.ToString().Split(':')[1].Split(',')[0];
                return Convert.ToInt32(part);
            }
            else { return -1; }
        }

        private void button_showTickets_Click(object sender, EventArgs e)
        {
            
            if (selectedEventIndex != -1)
            {
                loadTab(Tab.Tickets);
                loadTickets(selectedEventIndex);
            }
            else { MessageBox.Show("Select Event"); }
        }

        private void button_ticketsBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Events);
            loadEvents();
        }

        private void button_newTicketBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Tickets);
            loadTickets(selectedEventIndex);
        }

        private void listBox_events_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = getIdFromListBoxItem(listBox_events);
            if(id != -1)
            {
                selectedEventIndex = administration.IndexOf(id);
                label_eventInfo.Text = administration.Events[selectedEventIndex].ToString();
            }
            else
            {
                selectedEventIndex = -1;
            }
            
        }

        private void listBox_tickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = getIdFromListBoxItem(listBox_tickets);
            if (id != -1)
            {
                selectedTicketIndex = administration.Events[selectedEventIndex].IndexOf(id);
            }
            else
            {
                selectedEventIndex = -1;
            }
        }

        private void button_orderTickets_Click(object sender, EventArgs e)
        {

            loadTab(Tab.orderTickets);
            comboBox_class.SelectedIndex = 0;
        }

        private void button_addOrderTickets_Click(object sender, EventArgs e)
        {
            Buyer b = new Buyer(textBox_buyerName.Text, dateTimePicker_buyerBirthday.Value, textBox_buyerAddress.Text);
            int amount = (int)numeric_amountTickets.Value;
            int chairClass = Convert.ToInt32(comboBox_class.SelectedItem.ToString().Trim());

            if (administration.Events[selectedEventIndex].OrderTickets(amount, chairClass, b))
            {
                loadTab(Tab.Tickets);
                loadTickets(selectedEventIndex);
            }
            else { MessageBox.Show("Not enough tickets in that class for your order."); }

            
        }

        private void button_sortEventName_Click(object sender, EventArgs e)
        {
            if (comboBox_order.SelectedItem != null)
            {
                administration.Sort(comboBox_order.SelectedItem.ToString(), null);
                loadEvents();
            }
            else { MessageBox.Show("No Order Selected"); }
            

        }
    }
}
