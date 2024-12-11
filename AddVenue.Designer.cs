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
            label1.Location = new Point(38, 46);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "Venue Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 120);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 3;
            label3.Text = "Location";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 200);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 4;
            label2.Text = "Capacity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(39, 274);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 5;
            label4.Text = "Cost";
            // 
            // txtname
            // 
            txtname.BorderRadius = 20;
            txtname.Location = new Point(67, 43);
            txtname.Name = "txtname";
            txtname.Size = new Size(209, 23);
            txtname.TabIndex = 11;
            // 
            // txtcapacity
            // 
            txtcapacity.BorderRadius = 20;
            txtcapacity.Location = new Point(67, 197);
            txtcapacity.Name = "txtcapacity";
            txtcapacity.Size = new Size(209, 23);
            txtcapacity.TabIndex = 12;
            // 
            // txtcost
            // 
            txtcost.BorderRadius = 20;
            txtcost.Location = new Point(67, 271);
            txtcost.Name = "txtcost";
            txtcost.Size = new Size(209, 23);
            txtcost.TabIndex = 13;
            // 
            // txtloc
            // 
            txtloc.BorderRadius = 20;
            txtloc.Location = new Point(67, 117);
            txtloc.Name = "txtloc";
            txtloc.Size = new Size(209, 23);
            txtloc.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(73, 54, 40);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.CornerRadius = 30;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(692, 397);
            button1.Name = "button1";
            button1.Size = new Size(75, 28);
            button1.TabIndex = 15;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(177, 41);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(214, 192, 174);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(171, 136, 109);
            splitContainer1.Panel2.Controls.Add(txtname);
            splitContainer1.Panel2.Controls.Add(txtcost);
            splitContainer1.Panel2.Controls.Add(txtloc);
            splitContainer1.Panel2.Controls.Add(txtcapacity);
            splitContainer1.Size = new Size(478, 340);
            splitContainer1.SplitterDistance = 159;
            splitContainer1.TabIndex = 16;
            // 
            // AddVenue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(splitContainer1);
            Name = "AddVenue";
            Text = "AddVenue";
            FormClosed += AddVenue_FormClosed;
            Load += AddVenue_Load;
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
        private Label label3;
        private Label label2;
        private Label label4;
        private RoundedTextBox txtname;
        private RoundedTextBox txtcapacity;
        private RoundedTextBox txtcost;
        private RoundedTextBox txtloc;
        private SplitContainer splitContainer1;
        private RoundedButton button1;
    }
}