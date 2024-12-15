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
            lblTotalProfitAmount = new Label();
            statusComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(800, 357);
            dataGridView1.TabIndex = 0;
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Location = new Point(12, 21);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(200, 23);
            dateTimePickerStartDate.TabIndex = 1;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Location = new Point(239, 21);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(200, 23);
            dateTimePickerEndDate.TabIndex = 2;
            // 
            // comboBoxOrganizers
            // 
            comboBoxOrganizers.FormattingEnabled = true;
            comboBoxOrganizers.Location = new Point(460, 21);
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
            comboBoxVenues.Location = new Point(600, 21);
            comboBoxVenues.Name = "comboBoxVenues";
            comboBoxVenues.Size = new Size(121, 23);
            comboBoxVenues.TabIndex = 5;
            // 
            // comboBoxOwners
            // 
            comboBoxOwners.FormattingEnabled = true;
            comboBoxOwners.Location = new Point(738, 21);
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
            lblTotalActualCost.Location = new Point(353, 489);
            lblTotalActualCost.Name = "lblTotalActualCost";
            lblTotalActualCost.Size = new Size(59, 15);
            lblTotalActualCost.TabIndex = 8;
            lblTotalActualCost.Text = "Total Cost";
            // 
            // lblTotalProfitAmount
            // 
            lblTotalProfitAmount.AutoSize = true;
            lblTotalProfitAmount.Location = new Point(650, 489);
            lblTotalProfitAmount.Name = "lblTotalProfitAmount";
            lblTotalProfitAmount.Size = new Size(38, 15);
            lblTotalProfitAmount.TabIndex = 9;
            lblTotalProfitAmount.Text = "label1";
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Items.AddRange(new object[] { "All", "Upcoming", "Ongoing", "Completed" });
            statusComboBox.Location = new Point(875, 21);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(121, 23);
            statusComboBox.TabIndex = 10;
            // 
            // EventSummaryReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 532);
            Controls.Add(statusComboBox);
            Controls.Add(lblTotalProfitAmount);
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
            WindowState = FormWindowState.Maximized;
            FormClosed += EventSummaryReportForm_FormClosed;
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
        private Label lblTotalProfitAmount;
        private ComboBox statusComboBox;
    }
}