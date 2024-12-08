namespace Event_management
{
    partial class Form5
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
            label1 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            button1 = new Button();
            comboBoxOrganizer = new ComboBox();
            textBox1 = new TextBox();
            comboBoxVenue = new ComboBox();
            buttonSave = new Button();
            button2 = new Button();
            label8 = new Label();
            textBoxProfit = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(71, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(306, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 285);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Venue";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 66);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "Resources";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(438, 96);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(303, 150);
            dataGridView2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(551, 66);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "Attendees";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(162, 344);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 6;
            label4.Text = "Estimated Budget";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(162, 393);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 7;
            label5.Text = "Actual Cost";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(302, 336);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(159, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(302, 385);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(159, 23);
            textBox3.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(71, 26);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 10;
            label6.Text = "Organizer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(414, 26);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 12;
            label7.Text = "Date";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(488, 26);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(166, 23);
            textBox5.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(338, 62);
            button1.Name = "button1";
            button1.Size = new Size(39, 23);
            button1.TabIndex = 14;
            button1.Text = " + ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBoxOrganizer
            // 
            comboBoxOrganizer.FormattingEnabled = true;
            comboBoxOrganizer.Location = new Point(145, 23);
            comboBoxOrganizer.Name = "comboBoxOrganizer";
            comboBoxOrganizer.Size = new Size(148, 23);
            comboBoxOrganizer.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(145, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 23);
            textBox1.TabIndex = 16;
            // 
            // comboBoxVenue
            // 
            comboBoxVenue.FormattingEnabled = true;
            comboBoxVenue.Location = new Point(302, 282);
            comboBoxVenue.Name = "comboBoxVenue";
            comboBoxVenue.Size = new Size(159, 23);
            comboBoxVenue.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(657, 389);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(657, 62);
            button2.Name = "button2";
            button2.Size = new Size(116, 23);
            button2.TabIndex = 19;
            button2.Text = "Import Attendees";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(162, 448);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 20;
            label8.Text = "Profit";
            // 
            // textBoxProfit
            // 
            textBoxProfit.Location = new Point(302, 445);
            textBoxProfit.Name = "textBoxProfit";
            textBoxProfit.Size = new Size(159, 23);
            textBoxProfit.TabIndex = 21;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 495);
            Controls.Add(textBoxProfit);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxVenue);
            Controls.Add(textBox1);
            Controls.Add(comboBoxOrganizer);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form5";
            Text = "Form5";
            WindowState = FormWindowState.Maximized;
            FormClosed += Form5_FormClosed;
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
        private Button button1;
        private ComboBox comboBoxOrganizer;
        private TextBox textBox1;
        private ComboBox comboBoxVenue;
        private Button buttonSave;
        private Button button2;
        private Label label8;
        private TextBox textBoxProfit;
    }
}