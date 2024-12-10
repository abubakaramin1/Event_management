namespace Event_management
{
    partial class EventSummaryReportForm
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
            dataGridView1 = new DataGridView();
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            comboBoxOrganizers = new ComboBox();
            btnShowResults = new Button();
            comboBoxVenues = new ComboBox();
            comboBoxOwners = new ComboBox();
            lblTotalEvents = new Label();
            lblTotalActualCost = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(800, 357);
            dataGridView1.TabIndex = 0;
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Location = new Point(38, 24);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(200, 23);
            dateTimePickerStartDate.TabIndex = 1;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Location = new Point(253, 23);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(200, 23);
            dateTimePickerEndDate.TabIndex = 2;
            // 
            // comboBoxOrganizers
            // 
            comboBoxOrganizers.FormattingEnabled = true;
            comboBoxOrganizers.Location = new Point(473, 23);
            comboBoxOrganizers.Name = "comboBoxOrganizers";
            comboBoxOrganizers.Size = new Size(121, 23);
            comboBoxOrganizers.TabIndex = 3;
            // 
            // btnShowResults
            // 
            btnShowResults.Location = new Point(725, 64);
            btnShowResults.Name = "btnShowResults";
            btnShowResults.Size = new Size(75, 23);
            btnShowResults.TabIndex = 4;
            btnShowResults.Text = "button1";
            btnShowResults.UseVisualStyleBackColor = true;
            btnShowResults.Click += btnShowResults_Click;
            // 
            // comboBoxVenues
            // 
            comboBoxVenues.FormattingEnabled = true;
            comboBoxVenues.Location = new Point(612, 24);
            comboBoxVenues.Name = "comboBoxVenues";
            comboBoxVenues.Size = new Size(121, 23);
            comboBoxVenues.TabIndex = 5;
            // 
            // comboBoxOwners
            // 
            comboBoxOwners.FormattingEnabled = true;
            comboBoxOwners.Location = new Point(753, 23);
            comboBoxOwners.Name = "comboBoxOwners";
            comboBoxOwners.Size = new Size(121, 23);
            comboBoxOwners.TabIndex = 6;
            // 
            // lblTotalEvents
            // 
            lblTotalEvents.AutoSize = true;
            lblTotalEvents.Location = new Point(72, 489);
            lblTotalEvents.Name = "lblTotalEvents";
            lblTotalEvents.Size = new Size(104, 15);
            lblTotalEvents.TabIndex = 7;
            lblTotalEvents.Text = "Number Of Events";
            // 
            // lblTotalActualCost
            // 
            lblTotalActualCost.AutoSize = true;
            lblTotalActualCost.Location = new Point(200, 489);
            lblTotalActualCost.Name = "lblTotalActualCost";
            lblTotalActualCost.Size = new Size(59, 15);
            lblTotalActualCost.TabIndex = 8;
            lblTotalActualCost.Text = "Total Cost";
            // 
            // EventSummaryReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 532);
            Controls.Add(lblTotalActualCost);
            Controls.Add(lblTotalEvents);
            Controls.Add(comboBoxOwners);
            Controls.Add(comboBoxVenues);
            Controls.Add(btnShowResults);
            Controls.Add(comboBoxOrganizers);
            Controls.Add(dateTimePickerEndDate);
            Controls.Add(dateTimePickerStartDate);
            Controls.Add(dataGridView1);
            Name = "EventSummaryReportForm";
            Text = "EventSummaryReportForm";
            Load += EventSummaryReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private ComboBox comboBoxOrganizers;
        private Button btnShowResults;
        private ComboBox comboBoxVenues;
        private ComboBox comboBoxOwners;
        private Label lblTotalEvents;
        private Label lblTotalActualCost;
    }
}