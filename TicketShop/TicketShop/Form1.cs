﻿using System;
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
                Console.WriteLine(amountOfTabs);
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

        private void loadTab(int tabIndex)
        {
            tabControl_administration.TabPages.Add(tabs[tabIndex]);
            tabControl_administration.TabPages.Remove(tabControl_administration.TabPages[0]);
        }

        private void button_newEvent_Click(object sender, EventArgs e)
        {
            loadTab(1);
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

                administration.AddEvent(eventx);
                loadTab(0);
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
            loadTab(0);
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
            if (listBox_events.SelectedItem != null)
            {
                string[] parts = listBox_events.SelectedItem.ToString().Split(':')[1].Split(',');
                administration.DeleteEvent(Convert.ToInt32(parts[0]));
                loadEvents();
            }
            else { MessageBox.Show("Select event"); }
        }

        private void button_showTickets_Click(object sender, EventArgs e)
        {
            loadTab(2);
        }

        private void button_ticketsBack_Click(object sender, EventArgs e)
        {
            loadTab(0);
        }
    }
}
