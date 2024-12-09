namespace Event_management
{
    partial class AddVenue
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
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtname = new RoundedTextBox();
            txtcapacity = new RoundedTextBox();
            txtcost = new RoundedTextBox();
            txtloc = new RoundedTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(197, 67);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "Venue Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(197, 118);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 3;
            label3.Text = "Location";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(197, 170);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 4;
            label2.Text = "Capacity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(197, 228);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 5;
            label4.Text = "Cost";
            // 
            // txtname
            // 
            txtname.BorderRadius = 20;
            txtname.Location = new Point(367, 59);
            txtname.Name = "txtname";
            txtname.Size = new Size(209, 23);
            txtname.TabIndex = 11;
            // 
            // txtcapacity
            // 
            txtcapacity.BorderRadius = 20;
            txtcapacity.Location = new Point(367, 162);
            txtcapacity.Name = "txtcapacity";
            txtcapacity.Size = new Size(209, 23);
            txtcapacity.TabIndex = 12;
            // 
            // txtcost
            // 
            txtcost.BorderRadius = 20;
            txtcost.Location = new Point(367, 220);
            txtcost.Name = "txtcost";
            txtcost.Size = new Size(209, 23);
            txtcost.TabIndex = 13;
            // 
            // txtloc
            // 
            txtloc.BorderRadius = 20;
            txtloc.Location = new Point(367, 110);
            txtloc.Name = "txtloc";
            txtloc.Size = new Size(209, 23);
            txtloc.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(605, 339);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddVenue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtloc);
            Controls.Add(txtcost);
            Controls.Add(txtcapacity);
            Controls.Add(txtname);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "AddVenue";
            Text = "AddVenue";
            FormClosed += AddVenue_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private RoundedTextBox txtname;
        private RoundedTextBox txtcapacity;
        private RoundedTextBox txtcost;
        private RoundedTextBox txtloc;
        private Button button1;
    }
}