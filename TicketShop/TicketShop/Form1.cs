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

        enum Tab : byte { Login, Events, addNewEvent, Tickets, orderTickets, userEvents };


        public ticketShopForm()
        {
            InitializeComponent();
            administration = new Administration();
            tabs = new List<TabPage>();
            saveTabs();
            loadComboboxes();
            groupBox_match.Visible = false;
            groupBox_performance.Visible = false;
        }

        private void loadComboboxes()
        {
            comboBox_order.DataSource = Enum.GetValues(typeof(Administration.Order));
            comboBox_sortBy.DataSource = Enum.GetValues(typeof(Administration.SortBy));
            comboBox_orderTickets.DataSource = Enum.GetValues(typeof(Administration.Order));
            comboBox_sortByTickets.DataSource = Enum.GetValues(typeof(Event.SortBy));
            comboBox_userEventsOrder.DataSource = Enum.GetValues(typeof(Administration.Order));
            comboBox_userEventsSortBy.DataSource = Enum.GetValues(typeof(Administration.SortBy));
        }

        /// <summary>
        /// Voegt en Verwijdert Tabs die wel en niet nodig zijn
        /// </summary>
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

        /// <summary>
        /// Laadt alle events en laat deze zien die onder de categorie vallen die zijn geslecteerd
        /// </summary>
        /// <param name="match">Of de matches getoond moeten worden</param>
        /// <param name="performance">Of de optredens getoond moeten worden</param>
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

        /// <summary>
        /// Laad de tickets zien bij het event
        /// </summary>
        /// <param name="index">de index van het event waar de tickets van moeten worden getoond</param>
        private void loadTickets(int index)
        {
            listBox_tickets.Items.Clear();

            foreach (Ticket t in administration.Events[index].Tickets)
            {
                listBox_tickets.Items.Add(t.ToString());
            }
        }

        /// <summary>
        /// Laad de geselecteerde tab en verwijdert de rest
        /// </summary>
        /// <param name="tabIndex">Het tabblad die je wilt zien</param>
        private void loadTab(Tab tabIndex)
        {
            tabControl_administration.TabPages.Add(tabs[(int)tabIndex]);
            tabControl_administration.TabPages.Remove(tabControl_administration.TabPages[0]);
        }

        /// <summary>
        /// Hier kom je op het veld dat een nieuw event aanmaakt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_newEvent_Click(object sender, EventArgs e)
        {
            loadTab(Tab.addNewEvent);
            comboBox_eventType.SelectedIndex = 0;
        }

        /// <summary>
        /// Hier maak je een nieuw event en bevestig je deze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Hier vul je de gegevens in voor het event dat je gaat maken
        /// </summary>
        /// <param name="name">naam van event</param>
        /// <param name="id">id van event</param>
        /// <param name="date">moment van event</param>
        /// <param name="location">locatie van event</param>
        /// <param name="seats">hoeveel plaatsen er zijn op het event</param>
        /// <returns></returns>
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

        /// <summary>
        /// zoekt naar het laagst beschikbare id
        /// </summary>
        /// <param name="id">het id dat je gaat gebruiken om een nummer aan toe te wijzen</param>
        /// <returns>het laagst mogelijk id</returns>
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

        /// <summary>
        /// Gaat terug naar homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_newEventBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Events);
            loadEvents(true, true);
        }

        /// <summary>
        /// Laat de extra gegevens zien die bij een specifiek event horen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Knop om een event te verwijderen op te starten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_deleteEvent_Click(object sender, EventArgs e)
        {
            if (selectedEventIndex != -1)
            {
                administration.DeleteEvent(GetIdFromListBoxItem(listBox_events));
                loadEvents(true, true);
            }
            else { MessageBox.Show("Select Event"); }
        }

        /// <summary>
        /// Zoekt in listbox naar Id van geselecteerd item
        /// </summary>
        /// <param name="data">alle data</param>
        /// <returns>Het ID van het listbox item of -1 indien niet gevonden</returns>
        private int GetIdFromListBoxItem(ListBox data)
        {
            if (data.SelectedItem != null)
            {
                string part = data.SelectedItem.ToString().Split(':')[1].Split(',')[0];
                return Convert.ToInt32(part);
            }
            else { return -1; }
        }

        /// <summary>
        /// Knop om de pagina waar je de tickets kan selecteren opent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_showTickets_Click(object sender, EventArgs e)
        {

            if (selectedEventIndex != -1)
            {
                loadTab(Tab.Tickets);
                administration.Events[selectedEventIndex].Tickets.Sort();
                loadTickets(selectedEventIndex);
            }
            else { MessageBox.Show("Select Event"); }
        }

        /// <summary>
        /// knop om terug te gaan naar de homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ticketsBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Events);
            loadEvents(true, true);
        }

        /// <summary>
        /// knop om terug te gaan naar de homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_newTicketBack_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Tickets);
            loadTickets(selectedEventIndex);
        }

        /// <summary>
        /// slaat het id tijdelijk op en toont de gegevens van het event op dat geselecteerd op het label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// vraagt het id van de listbox en geeft de index ervan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// knop om naar de order tickets te gaan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_orderTickets_Click(object sender, EventArgs e)
        {
            loadTab(Tab.orderTickets);
            comboBox_class.SelectedIndex = 0;
        }

        /// <summary>
        /// knop om de tickets te bestellen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addOrderTickets_Click(object sender, EventArgs e)
        {
            Buyer b = new Buyer(textBox_buyerName.Text, dateTimePicker_buyerBirthday.Value, textBox_buyerAddress.Text);
            int amount = (int)numeric_amountTickets.Value;
            int chairClass = Convert.ToInt32(comboBox_class.SelectedItem.ToString().Trim());
            try
            {
                if (administration.Events[selectedEventIndex].OrderTickets(amount, chairClass, b))
                {
                    loadTab(Tab.Tickets);
                    loadTickets(selectedEventIndex);
                }
                else { MessageBox.Show("Not enough tickets in that class for your order or buyer is invalid"); }
            }
            catch(CantSetBuyerException)
            {
                MessageBox.Show("Cant set the buyer for the tickets");
            }
        }

        /// <summary>
        /// knop om op event te sorteren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sortEventName_Click(object sender, EventArgs e)
        {
            if (comboBox_order.SelectedItem != null && comboBox_sortBy.SelectedItem != null)
            {
                administration.SortEvents((Administration.Order)comboBox_order.SelectedItem, (Administration.SortBy)comboBox_sortBy.SelectedItem);
                loadEvents(checkBox_match.Checked, checkBox_performance.Checked);
            }
            else { MessageBox.Show("No 'Order' or 'Sort by' selected"); }
        }

        /// <summary>
        /// knop om gegevens op te slaan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog openSave = new SaveFileDialog
            {
                Filter = "Data Files (*.dat) | *.dat",
                InitialDirectory = Application.StartupPath
            };

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

        /// <summary>
        /// knop om gegevens in te laden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openLoad = new OpenFileDialog
            {
                Filter = "Data Files (*.dat) | *.dat",
                InitialDirectory = Application.StartupPath
            };

            try
            {
                DialogResult result = openLoad.ShowDialog();
                if (result == DialogResult.OK)
                {
                    administration.Load(openLoad.FileName);
                }
                administration.Events.Sort();
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

        /// <summary>
        /// knop om gegevens op te slaan en te exporteren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog openSave = new SaveFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt",
                InitialDirectory = Application.StartupPath
            };

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

        /// <summary>
        /// knop om naar de pagina te gaan waar je tickets kan verwijderen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        
        private void button_sortTickets_Click(object sender, EventArgs e)
        {
            if (comboBox_orderTickets.SelectedItem != null && comboBox_sortByTickets.SelectedItem != null)
            {
                administration.Events[selectedEventIndex].SortTickets((Administration.Order)comboBox_orderTickets.SelectedItem, (Event.SortBy)comboBox_sortByTickets.SelectedItem);
                loadTickets(selectedEventIndex);
            }
            else { MessageBox.Show("No 'Order' or 'Sort by' selected"); }
            
        }

        private void button_loginAdmin_Click(object sender, EventArgs e)
        {
            loadTab(Tab.Events);
        }

        private void button_loginUser_Click(object sender, EventArgs e)
        {
            try
            {
                loadTab(Tab.userEvents);
                administration.Load(@"save.dat");
                LoadUserEvents(true, true);
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("No file found with the name 'save.dat' !");
                loadTab(Tab.Login);
            }
            
        }

        private void LoadUserEvents(bool match, bool performance)
        {
            listBox_userEvents.Items.Clear();
            foreach (Event e in administration.Events)
            {
                if (match && performance)
                {
                    listBox_userEvents.Items.Add(e.ToString());
                }
                else if (performance)
                {
                    if (e is Performance) { listBox_userEvents.Items.Add(e.ToString()); }
                }
                else if (match)
                {
                    if (e is Match) { listBox_userEvents.Items.Add(e.ToString()); }
                }

            }
        }

        private void button_userEventsSort_Click(object sender, EventArgs e)
        {
            if (comboBox_userEventsOrder.SelectedItem != null && comboBox_userEventsSortBy.SelectedItem != null)
            {
                administration.SortEvents((Administration.Order)comboBox_userEventsOrder.SelectedItem, (Administration.SortBy)comboBox_userEventsSortBy.SelectedItem);
                LoadUserEvents(checkBox_userEventsMatch.Checked, checkBox_userEventsPerformance.Checked);
            }
            else { MessageBox.Show("No 'Order' or 'Sort by' selected"); }
        }
    }
}
