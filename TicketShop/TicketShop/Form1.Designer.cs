namespace TicketShop
{
    partial class ticketShopForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl_administration = new System.Windows.Forms.TabControl();
            this.tabPage_events = new System.Windows.Forms.TabPage();
            this.button_deleteEvent = new System.Windows.Forms.Button();
            this.button_newEvent = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.listBox_events = new System.Windows.Forms.ListBox();
            this.tabPage_event = new System.Windows.Forms.TabPage();
            this.groupBox_match = new System.Windows.Forms.GroupBox();
            this.textBox_opponent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_player = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_newEventBack = new System.Windows.Forms.Button();
            this.button_addNewEvent = new System.Windows.Forms.Button();
            this.groupBox_performance = new System.Windows.Forms.GroupBox();
            this.textBox_demands = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_eventArtist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_seats = new System.Windows.Forms.NumericUpDown();
            this.l = new System.Windows.Forms.Label();
            this.textBox_eventLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_date = new System.Windows.Forms.DateTimePicker();
            this.textBox_eventName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_eventType = new System.Windows.Forms.ComboBox();
            this.tabPage_tickets = new System.Windows.Forms.TabPage();
            this.listBox_tickets = new System.Windows.Forms.ListBox();
            this.button_showTickets = new System.Windows.Forms.Button();
            this.button_ticketsBack = new System.Windows.Forms.Button();
            this.tabControl_administration.SuspendLayout();
            this.tabPage_events.SuspendLayout();
            this.tabPage_event.SuspendLayout();
            this.groupBox_match.SuspendLayout();
            this.groupBox_performance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seats)).BeginInit();
            this.tabPage_tickets.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_administration
            // 
            this.tabControl_administration.Controls.Add(this.tabPage_events);
            this.tabControl_administration.Controls.Add(this.tabPage_event);
            this.tabControl_administration.Controls.Add(this.tabPage_tickets);
            this.tabControl_administration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl_administration.Location = new System.Drawing.Point(12, 12);
            this.tabControl_administration.Name = "tabControl_administration";
            this.tabControl_administration.SelectedIndex = 0;
            this.tabControl_administration.Size = new System.Drawing.Size(911, 552);
            this.tabControl_administration.TabIndex = 0;
            // 
            // tabPage_events
            // 
            this.tabPage_events.Controls.Add(this.button_showTickets);
            this.tabPage_events.Controls.Add(this.button_deleteEvent);
            this.tabPage_events.Controls.Add(this.button_newEvent);
            this.tabPage_events.Controls.Add(this.button_load);
            this.tabPage_events.Controls.Add(this.button_export);
            this.tabPage_events.Controls.Add(this.button_save);
            this.tabPage_events.Controls.Add(this.listBox_events);
            this.tabPage_events.Location = new System.Drawing.Point(4, 22);
            this.tabPage_events.Name = "tabPage_events";
            this.tabPage_events.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_events.Size = new System.Drawing.Size(903, 526);
            this.tabPage_events.TabIndex = 0;
            this.tabPage_events.Text = "Events";
            this.tabPage_events.UseVisualStyleBackColor = true;
            // 
            // button_deleteEvent
            // 
            this.button_deleteEvent.Location = new System.Drawing.Point(350, 54);
            this.button_deleteEvent.Name = "button_deleteEvent";
            this.button_deleteEvent.Size = new System.Drawing.Size(121, 32);
            this.button_deleteEvent.TabIndex = 5;
            this.button_deleteEvent.Text = "Delete Event";
            this.button_deleteEvent.UseVisualStyleBackColor = true;
            this.button_deleteEvent.Click += new System.EventHandler(this.button_deleteEvent_Click);
            // 
            // button_newEvent
            // 
            this.button_newEvent.Location = new System.Drawing.Point(351, 7);
            this.button_newEvent.Name = "button_newEvent";
            this.button_newEvent.Size = new System.Drawing.Size(121, 32);
            this.button_newEvent.TabIndex = 4;
            this.button_newEvent.Text = "Add new Event";
            this.button_newEvent.UseVisualStyleBackColor = true;
            this.button_newEvent.Click += new System.EventHandler(this.button_newEvent_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(822, 436);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 3;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(822, 494);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 2;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(822, 465);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // listBox_events
            // 
            this.listBox_events.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_events.FormattingEnabled = true;
            this.listBox_events.HorizontalScrollbar = true;
            this.listBox_events.Location = new System.Drawing.Point(6, 6);
            this.listBox_events.Name = "listBox_events";
            this.listBox_events.Size = new System.Drawing.Size(338, 509);
            this.listBox_events.TabIndex = 0;
            // 
            // tabPage_event
            // 
            this.tabPage_event.Controls.Add(this.groupBox_match);
            this.tabPage_event.Controls.Add(this.button_newEventBack);
            this.tabPage_event.Controls.Add(this.button_addNewEvent);
            this.tabPage_event.Controls.Add(this.groupBox_performance);
            this.tabPage_event.Controls.Add(this.numericUpDown1);
            this.tabPage_event.Controls.Add(this.label5);
            this.tabPage_event.Controls.Add(this.label4);
            this.tabPage_event.Controls.Add(this.numeric_seats);
            this.tabPage_event.Controls.Add(this.l);
            this.tabPage_event.Controls.Add(this.textBox_eventLocation);
            this.tabPage_event.Controls.Add(this.label3);
            this.tabPage_event.Controls.Add(this.dateTimePicker_date);
            this.tabPage_event.Controls.Add(this.textBox_eventName);
            this.tabPage_event.Controls.Add(this.label2);
            this.tabPage_event.Controls.Add(this.label1);
            this.tabPage_event.Controls.Add(this.comboBox_eventType);
            this.tabPage_event.Location = new System.Drawing.Point(4, 22);
            this.tabPage_event.Name = "tabPage_event";
            this.tabPage_event.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_event.Size = new System.Drawing.Size(903, 526);
            this.tabPage_event.TabIndex = 1;
            this.tabPage_event.Text = "Add New Event";
            this.tabPage_event.UseVisualStyleBackColor = true;
            // 
            // groupBox_match
            // 
            this.groupBox_match.Controls.Add(this.textBox_opponent);
            this.groupBox_match.Controls.Add(this.label8);
            this.groupBox_match.Controls.Add(this.textBox_player);
            this.groupBox_match.Controls.Add(this.label9);
            this.groupBox_match.Location = new System.Drawing.Point(338, 117);
            this.groupBox_match.Name = "groupBox_match";
            this.groupBox_match.Size = new System.Drawing.Size(229, 118);
            this.groupBox_match.TabIndex = 13;
            this.groupBox_match.TabStop = false;
            this.groupBox_match.Text = "Match";
            // 
            // textBox_opponent
            // 
            this.textBox_opponent.Location = new System.Drawing.Point(90, 72);
            this.textBox_opponent.Name = "textBox_opponent";
            this.textBox_opponent.Size = new System.Drawing.Size(100, 20);
            this.textBox_opponent.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Opponent:";
            // 
            // textBox_player
            // 
            this.textBox_player.Location = new System.Drawing.Point(90, 36);
            this.textBox_player.Name = "textBox_player";
            this.textBox_player.Size = new System.Drawing.Size(100, 20);
            this.textBox_player.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Player:";
            // 
            // button_newEventBack
            // 
            this.button_newEventBack.Location = new System.Drawing.Point(6, 6);
            this.button_newEventBack.Name = "button_newEventBack";
            this.button_newEventBack.Size = new System.Drawing.Size(97, 32);
            this.button_newEventBack.TabIndex = 14;
            this.button_newEventBack.Text = "<- Back";
            this.button_newEventBack.UseVisualStyleBackColor = true;
            this.button_newEventBack.Click += new System.EventHandler(this.button_newEventBack_Click);
            // 
            // button_addNewEvent
            // 
            this.button_addNewEvent.Location = new System.Drawing.Point(81, 343);
            this.button_addNewEvent.Name = "button_addNewEvent";
            this.button_addNewEvent.Size = new System.Drawing.Size(202, 37);
            this.button_addNewEvent.TabIndex = 13;
            this.button_addNewEvent.Text = "Add New Event";
            this.button_addNewEvent.UseVisualStyleBackColor = true;
            this.button_addNewEvent.Click += new System.EventHandler(this.button_addNewEvent_Click);
            // 
            // groupBox_performance
            // 
            this.groupBox_performance.Controls.Add(this.textBox_demands);
            this.groupBox_performance.Controls.Add(this.label7);
            this.groupBox_performance.Controls.Add(this.textBox_eventArtist);
            this.groupBox_performance.Controls.Add(this.label6);
            this.groupBox_performance.Location = new System.Drawing.Point(338, 117);
            this.groupBox_performance.Name = "groupBox_performance";
            this.groupBox_performance.Size = new System.Drawing.Size(229, 118);
            this.groupBox_performance.TabIndex = 12;
            this.groupBox_performance.TabStop = false;
            this.groupBox_performance.Text = "Performance";
            // 
            // textBox_demands
            // 
            this.textBox_demands.Location = new System.Drawing.Point(90, 72);
            this.textBox_demands.Name = "textBox_demands";
            this.textBox_demands.Size = new System.Drawing.Size(100, 20);
            this.textBox_demands.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Demands:";
            // 
            // textBox_eventArtist
            // 
            this.textBox_eventArtist.Location = new System.Drawing.Point(90, 36);
            this.textBox_eventArtist.Name = "textBox_eventArtist";
            this.textBox_eventArtist.Size = new System.Drawing.Size(100, 20);
            this.textBox_eventArtist.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Artist:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(98, 297);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seats:";
            // 
            // numeric_seats
            // 
            this.numeric_seats.Location = new System.Drawing.Point(98, 267);
            this.numeric_seats.Maximum = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.numeric_seats.Name = "numeric_seats";
            this.numeric_seats.Size = new System.Drawing.Size(121, 20);
            this.numeric_seats.TabIndex = 8;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(41, 229);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(51, 13);
            this.l.TabIndex = 7;
            this.l.Text = "Location:";
            // 
            // textBox_eventLocation
            // 
            this.textBox_eventLocation.Location = new System.Drawing.Point(98, 226);
            this.textBox_eventLocation.Name = "textBox_eventLocation";
            this.textBox_eventLocation.Size = new System.Drawing.Size(100, 20);
            this.textBox_eventLocation.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date:";
            // 
            // dateTimePicker_date
            // 
            this.dateTimePicker_date.CustomFormat = "H:m      dd-MM-yyyy";
            this.dateTimePicker_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_date.Location = new System.Drawing.Point(98, 189);
            this.dateTimePicker_date.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_date.Name = "dateTimePicker_date";
            this.dateTimePicker_date.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker_date.TabIndex = 4;
            // 
            // textBox_eventName
            // 
            this.textBox_eventName.Location = new System.Drawing.Point(98, 150);
            this.textBox_eventName.Name = "textBox_eventName";
            this.textBox_eventName.Size = new System.Drawing.Size(100, 20);
            this.textBox_eventName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event-type:";
            // 
            // comboBox_eventType
            // 
            this.comboBox_eventType.FormattingEnabled = true;
            this.comboBox_eventType.Items.AddRange(new object[] {
            "Performance",
            "Match"});
            this.comboBox_eventType.Location = new System.Drawing.Point(97, 87);
            this.comboBox_eventType.Name = "comboBox_eventType";
            this.comboBox_eventType.Size = new System.Drawing.Size(121, 21);
            this.comboBox_eventType.TabIndex = 0;
            this.comboBox_eventType.SelectedIndexChanged += new System.EventHandler(this.comboBox_eventType_SelectedIndexChanged);
            // 
            // tabPage_tickets
            // 
            this.tabPage_tickets.Controls.Add(this.button_ticketsBack);
            this.tabPage_tickets.Controls.Add(this.listBox_tickets);
            this.tabPage_tickets.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tickets.Name = "tabPage_tickets";
            this.tabPage_tickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tickets.Size = new System.Drawing.Size(903, 526);
            this.tabPage_tickets.TabIndex = 2;
            this.tabPage_tickets.Text = "Tickets";
            this.tabPage_tickets.UseVisualStyleBackColor = true;
            // 
            // listBox_tickets
            // 
            this.listBox_tickets.FormattingEnabled = true;
            this.listBox_tickets.HorizontalScrollbar = true;
            this.listBox_tickets.Location = new System.Drawing.Point(6, 44);
            this.listBox_tickets.Name = "listBox_tickets";
            this.listBox_tickets.Size = new System.Drawing.Size(346, 472);
            this.listBox_tickets.TabIndex = 0;
            // 
            // button_showTickets
            // 
            this.button_showTickets.Location = new System.Drawing.Point(351, 102);
            this.button_showTickets.Name = "button_showTickets";
            this.button_showTickets.Size = new System.Drawing.Size(121, 32);
            this.button_showTickets.TabIndex = 6;
            this.button_showTickets.Text = "Show Tickets";
            this.button_showTickets.UseVisualStyleBackColor = true;
            this.button_showTickets.Click += new System.EventHandler(this.button_showTickets_Click);
            // 
            // button_ticketsBack
            // 
            this.button_ticketsBack.Location = new System.Drawing.Point(6, 6);
            this.button_ticketsBack.Name = "button_ticketsBack";
            this.button_ticketsBack.Size = new System.Drawing.Size(97, 32);
            this.button_ticketsBack.TabIndex = 15;
            this.button_ticketsBack.Text = "<- Back";
            this.button_ticketsBack.UseVisualStyleBackColor = true;
            this.button_ticketsBack.Click += new System.EventHandler(this.button_ticketsBack_Click);
            // 
            // ticketShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 576);
            this.Controls.Add(this.tabControl_administration);
            this.Name = "ticketShopForm";
            this.Text = "TicketShop";
            this.tabControl_administration.ResumeLayout(false);
            this.tabPage_events.ResumeLayout(false);
            this.tabPage_event.ResumeLayout(false);
            this.tabPage_event.PerformLayout();
            this.groupBox_match.ResumeLayout(false);
            this.groupBox_match.PerformLayout();
            this.groupBox_performance.ResumeLayout(false);
            this.groupBox_performance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_seats)).EndInit();
            this.tabPage_tickets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabControl tabControl_administration;
        private System.Windows.Forms.TabPage tabPage_events;
        private System.Windows.Forms.TabPage tabPage_event;
        private System.Windows.Forms.ListBox listBox_events;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_deleteEvent;
        private System.Windows.Forms.Button button_newEvent;
        private System.Windows.Forms.TextBox textBox_eventName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_eventType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_date;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox textBox_eventLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_seats;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_performance;
        private System.Windows.Forms.Button button_addNewEvent;
        private System.Windows.Forms.TextBox textBox_demands;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_eventArtist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_newEventBack;
        private System.Windows.Forms.GroupBox groupBox_match;
        private System.Windows.Forms.TextBox textBox_opponent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_player;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage_tickets;
        private System.Windows.Forms.ListBox listBox_tickets;
        private System.Windows.Forms.Button button_showTickets;
        private System.Windows.Forms.Button button_ticketsBack;
    }
}

