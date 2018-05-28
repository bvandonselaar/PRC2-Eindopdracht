using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;

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
            comboBox_order.DataSource = Enum.GetValues(typeof(Administration.Order));
            comboBox_sortBy.DataSource = Enum.GetValues(typeof(Administration.SortBy));

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

        private void loadEvents(bool match, bool performance)
        {
            listBox_events.Items.Clear();
            foreach (Event e in administration.Events)
            {
                if (match && performance)
                {
                    listBox_events.Items.Add(e.ToString());
                }
                else if (performance)
                {
                    if (e is Performance) { listBox_events.Items.Add(e.ToString()); }
                }
                else if (match)
                {
                    if (e is Match) { listBox_events.Items.Add(e.ToString()); }
                }

            }
        }

        private void loadTickets(int index)
        {
            listBox_tickets.Items.Clear();
            foreach (Ticket t in administration.Events[index].Tickets)
            {
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
            if (FindAvailableId(out int id) && comboBox_eventType.SelectedItem != null)
            {
                string name = textBox_eventName.Text;
                DateTime date = dateTimePicker_date.Value;
                string location = textBox_eventLocation.Text;
                int seats = (int)numeric_seats.Value;

                Event eventx = ConstructEvent(name, id, date, location, seats);
                try
                {
                    eventx.GenerateTickets(numeric_price.Value);
                    administration.AddEvent(eventx);
                    loadTab(Tab.Events);
                    loadEvents(true, true);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Fill in all fields");
                }
            }
            else
            {
                MessageBox.Show("No ids left or invalid Event-type");
            }
        }

        private Event ConstructEvent(string name, int id, DateTime date, string location, int seats)
        {
            if (comboBox_eventType.SelectedItem.ToString() == "Match")
            {
                string player = textBox_player.Text;
                string opponent = textBox_opponent.Text;
                if (!string.IsNullOrEmpty(player) && !string.IsNullOrEmpty(opponent) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location))
                {
                    return new Match(name, id, date, location, seats, player, opponent);
                }
            }
            else
            {
                string artist = textBox_eventArtist.Text;
                string demands = textBox_demands.Text;
                if (!string.IsNullOrEmpty(artist) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(location))
                {
                    return new Performance(name, id, date, location, seats, artist, demands);
                }
            }
            return null;
        }

        private bool FindAvailableId(out int id)
        {
            bool foundId = true;
            id = 0;
            for (int i = 0; i < 1000; i++)
            {
                foreach (Event e in administration.Events)
                {
                    if (e.Id == i)
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
            loadEvents(true, true);
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
                loadEvents(true, true);
            }
            else { MessageBox.Show("Select Event"); }
        }

        private int GetIdFromListBoxItem(ListBox data)
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
            loadEvents(true, true);
        }

        private void button_newTicketBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Tickets);
            loadTickets(selectedEventIndex);
        }

        private void listBox_events_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetIdFromListBoxItem(listBox_events);
            if (id != -1)
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
            int id = GetIdFromListBoxItem(listBox_tickets);
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
            else { MessageBox.Show("Not enough tickets in that class for your order or buyer is invalid"); }


        }

        private void button_sortEventName_Click(object sender, EventArgs e)
        {
            if (comboBox_order.SelectedItem != null && comboBox_sortBy.SelectedItem != null)
            {
                administration.Sort((Administration.Order)comboBox_order.SelectedItem, (Administration.SortBy)comboBox_sortBy.SelectedItem);
                loadEvents(checkBox_match.Checked, checkBox_performance.Checked);
            }
            else { MessageBox.Show("No 'Order' or 'Sort by' selected"); }


        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog openSave = new SaveFileDialog();
            openSave.Filter = "Data Files (*.dat) | *.dat";
            openSave.InitialDirectory = Application.StartupPath;

            try
            {
                DialogResult result = openSave.ShowDialog();
                if (result == DialogResult.OK)
                {
                    administration.Save(openSave.FileName);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("serialisationstream is null");
            }
            catch (SerializationException)
            {
                MessageBox.Show("Can not serialize, because of unserializable attributes");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid path");
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openLoad = new OpenFileDialog();
            openLoad.Filter = "Data Files (*.dat) | *.dat";
            openLoad.InitialDirectory = Application.StartupPath;

            try
            {
                DialogResult result = openLoad.ShowDialog();
                if (result == DialogResult.OK)
                {
                    administration.Load(openLoad.FileName);
                }
                loadEvents(true, true);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The deserializationStream is null");
            }
            catch (SerializationException)
            {
                MessageBox.Show("Can not deserialize, because of wrong values");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid path");
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog openSave = new SaveFileDialog();
            openSave.Filter = "Text Files (*.txt) | *.txt";
            openSave.InitialDirectory = Application.StartupPath;

            try
            {
                DialogResult result = openSave.ShowDialog();
                if (result == DialogResult.OK)
                {
                    administration.Export(openSave.FileName);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Export error");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Path is null");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid path");
            }
        }

        private void button_deleteTickets_Click(object sender, EventArgs e)
        {
            if (comboBox_deleteBy != null)
            {
                try
                {
                    if (comboBox_deleteBy.SelectedItem.ToString() == "Id:")
                    {
                        administration.Events[selectedEventIndex].DeleteTickets(Convert.ToInt32(textBox_deleteTickets.Text));
                    }
                    else
                    {
                        administration.Events[selectedEventIndex].DeleteTickets(textBox_deleteTickets.Text);
                    }
                    loadTickets(selectedEventIndex);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Ticket with that Id is not present");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Insert correct Id");
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Could not find ticket");
                }

            }

        }
    }
}
