namespace Event_management
{
    partial class AdminForm2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new RoundedTextBox();
            textBox2 = new RoundedTextBox();
            textBox3 = new RoundedTextBox();
            comboBox1 = new RoundedComboBox();
            comboBox2 = new RoundedComboBox();
            comboBox3 = new RoundedComboBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new RoundedButton();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 43);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Event Name:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(42, 91);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(42, 136);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Venue";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(39, 187);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 3;
            label4.Text = "Budget";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(39, 236);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 4;
            label5.Text = "Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(42, 280);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 5;
            label6.Text = "Owner";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(42, 324);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 6;
            label7.Text = "Organizer";
            // 
            // textBox1
            // 
            textBox1.BorderRadius = 30;
            textBox1.Cursor = Cursors.No;
            textBox1.Location = new Point(55, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 23);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.BorderRadius = 20;
            textBox2.Location = new Point(55, 184);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.BorderRadius = 20;
            textBox3.Location = new Point(55, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(209, 23);
            textBox3.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.BorderRadius = 20;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(55, 133);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(209, 24);
            comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.BorderRadius = 20;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(55, 277);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(209, 24);
            comboBox2.TabIndex = 12;
            // 
            // comboBox3
            // 
            comboBox3.BorderRadius = 20;
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(55, 321);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(209, 24);
            comboBox3.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(55, 85);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(209, 23);
            dateTimePicker1.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(73, 54, 40);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.CornerRadius = 25;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(686, 407);
            button1.Name = "button1";
            button1.Size = new Size(90, 31);
            button1.TabIndex = 14;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(153, 31);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(214, 192, 174);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(171, 136, 109);
            splitContainer1.Panel2.Controls.Add(comboBox3);
            splitContainer1.Panel2.Controls.Add(comboBox2);
            splitContainer1.Panel2.Controls.Add(textBox3);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(dateTimePicker1);
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Size = new Size(510, 374);
            splitContainer1.SplitterDistance = 170;
            splitContainer1.TabIndex = 15;
            // 
            // AdminForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(228, 224, 225);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(splitContainer1);
            Name = "AdminForm2";
            Text = "Form7";
            Load += AdminForm2_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private RoundedTextBox textBox1;
        private RoundedTextBox textBox2;
        private RoundedTextBox textBox3;
        private RoundedComboBox comboBox1;
        private RoundedComboBox comboBox2;
        private RoundedComboBox comboBox3;

        private DateTimePicker dateTimePicker1;

        private Event_management.RoundedButton button1;
        private SplitContainer splitContainer1;
    }
}