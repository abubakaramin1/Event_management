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
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 41);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Event Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 97);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 143);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Venue";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 204);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 3;
            label4.Text = "Budget";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 257);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 4;
            label5.Text = "Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(103, 319);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 5;
            label6.Text = "Owner";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(103, 387);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 6;
            label7.Text = "Organizer";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(270, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 23);
            textBox1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(270, 91);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(209, 23);
            dateTimePicker1.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(270, 140);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(209, 23);
            comboBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(270, 196);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(270, 254);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(209, 23);
            textBox3.TabIndex = 11;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(270, 311);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(209, 23);
            comboBox2.TabIndex = 12;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(270, 379);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(209, 23);
            comboBox3.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(638, 410);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AdminForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminForm2";
            Text = "Form7";
            Load += AdminForm2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button1;
    }
}