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
            button1 = new RoundedButton();
            comboBoxOrganizer = new ComboBox();
            textBox1 = new TextBox();
            comboBoxVenue = new ComboBox();
            buttonSave = new RoundedButton();
            button2 = new RoundedButton();
            label8 = new Label();
            textBoxProfit = new TextBox();
            button3 = new RoundedButton();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            button4 = new RoundedButton();
            label9 = new Label();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(106, 389);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(393, 160);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(214, 192, 179);
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 92);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Venue";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(73, 54, 40);
            label2.Location = new Point(255, 345);
            label2.Name = "label2";
            label2.Size = new Size(86, 21);
            label2.TabIndex = 3;
            label2.Text = "Resources";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(702, 389);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(430, 160);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(73, 54, 40);
            label3.Location = new Point(895, 344);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 5;
            label3.Text = "Attendees";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(214, 192, 179);
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 87);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 6;
            label4.Text = "Estimated Budget";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(214, 192, 179);
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 163);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 7;
            label5.Text = "Actual Cost";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(40, 84);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(186, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(203, 23);
            textBox3.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(214, 192, 179);
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(21, 23);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 10;
            label6.Text = "Organizer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(214, 192, 179);
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 20);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 12;
            label7.Text = "Date";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(40, 17);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(186, 23);
            textBox5.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(73, 54, 40);
            button1.CornerRadius = 30;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(347, 341);
            button1.Name = "button1";
            button1.Size = new Size(39, 31);
            button1.TabIndex = 14;
            button1.Text = " + ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBoxOrganizer
            // 
            comboBoxOrganizer.FormattingEnabled = true;
            comboBoxOrganizer.Location = new Point(26, 20);
            comboBoxOrganizer.Name = "comboBoxOrganizer";
            comboBoxOrganizer.Size = new Size(203, 23);
            comboBoxOrganizer.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 16;
            // 
            // comboBoxVenue
            // 
            comboBoxVenue.FormattingEnabled = true;
            comboBoxVenue.Location = new Point(26, 92);
            comboBoxVenue.Name = "comboBoxVenue";
            comboBoxVenue.Size = new Size(203, 23);
            comboBoxVenue.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(73, 54, 40);
            buttonSave.CornerRadius = 30;
            buttonSave.FlatStyle = FlatStyle.Popup;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSave.ForeColor = SystemColors.ButtonHighlight;
            buttonSave.Location = new Point(572, 604);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 34);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(73, 54, 40);
            button2.CornerRadius = 30;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(1000, 604);
            button2.Name = "button2";
            button2.Size = new Size(132, 34);
            button2.TabIndex = 19;
            button2.Text = "Import Attendees";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(214, 192, 179);
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 154);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 20;
            label8.Text = "Profit Percentage";
            // 
            // textBoxProfit
            // 
            textBoxProfit.Location = new Point(40, 146);
            textBoxProfit.Name = "textBoxProfit";
            textBoxProfit.Size = new Size(186, 23);
            textBoxProfit.TabIndex = 21;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(73, 54, 40);
            button3.CornerRadius = 30;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(93, 604);
            button3.Name = "button3";
            button3.Size = new Size(127, 34);
            button3.TabIndex = 22;
            button3.Text = "Generate Tickets";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(93, 79);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(214, 192, 179);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(171, 136, 109);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(comboBoxOrganizer);
            splitContainer1.Panel2.Controls.Add(comboBoxVenue);
            splitContainer1.Panel2.Controls.Add(textBox3);
            splitContainer1.Size = new Size(421, 200);
            splitContainer1.SplitterDistance = 145;
            splitContainer1.TabIndex = 23;
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(702, 79);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.FromArgb(214, 192, 179);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(label8);
            splitContainer2.Panel1.Controls.Add(label7);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = Color.FromArgb(171, 136, 109);
            splitContainer2.Panel2.Controls.Add(textBoxProfit);
            splitContainer2.Panel2.Controls.Add(textBox2);
            splitContainer2.Panel2.Controls.Add(textBox5);
            splitContainer2.Size = new Size(430, 200);
            splitContainer2.SplitterDistance = 166;
            splitContainer2.TabIndex = 24;
            splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(73, 54, 40);
            button4.CornerRadius = 30;
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(392, 342);
            button4.Name = "button4";
            button4.Size = new Size(37, 31);
            button4.TabIndex = 25;
            button4.Text = "-";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(753, 313);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 26;
            label9.Text = "Profit";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(912, 305);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(186, 23);
            textBox4.TabIndex = 27;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(228, 224, 225);
            ClientSize = new Size(1204, 659);
            Controls.Add(textBox4);
            Controls.Add(label9);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonSave);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(splitContainer1);
            Controls.Add(splitContainer2);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form5";
            Text = "Form5";
            WindowState = FormWindowState.Maximized;
            FormClosed += Form5_FormClosed;
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
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
        private ComboBox comboBoxOrganizer;
        private TextBox textBox1;
        private ComboBox comboBoxVenue;
        private Label label8;
        private TextBox textBoxProfit;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private RoundedButton button1;
        private RoundedButton buttonSave;
        private RoundedButton button2;
        private RoundedButton button3;
        private RoundedButton button4;
        private Label label9;
        private TextBox textBox4;
    }
}