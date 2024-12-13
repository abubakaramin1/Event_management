namespace Event_management
{
    partial class frm_Main
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            eventSummaryReportToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            roundedButton7 = new RoundedButton();
            roundedButton6 = new RoundedButton();
            roundedButton5 = new RoundedButton();
            roundedButton4 = new RoundedButton();
            roundedButton3 = new RoundedButton();
            roundedButton2 = new RoundedButton();
            roundedButton1 = new RoundedButton();
            pictureBox1 = new PictureBox();
            imageList1 = new ImageList(components);
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(171, 136, 109);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(942, 57);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(259, 54);
            toolStripLabel1.Text = "Serene Settings";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(142, 54);
            toolStripLabel2.Text = "Hello ________!";
            // 
            // eventSummaryReportToolStripMenuItem
            // 
            eventSummaryReportToolStripMenuItem.Name = "eventSummaryReportToolStripMenuItem";
            eventSummaryReportToolStripMenuItem.Size = new Size(139, 24);
            eventSummaryReportToolStripMenuItem.Text = "Event Summary Report";
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton7);
            panel1.Controls.Add(roundedButton6);
            panel1.Controls.Add(roundedButton5);
            panel1.Controls.Add(roundedButton4);
            panel1.Controls.Add(roundedButton3);
            panel1.Controls.Add(roundedButton2);
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 543);
            panel1.TabIndex = 5;
            // 
            // roundedButton7
            // 
            roundedButton7.CornerRadius = 30;
            roundedButton7.Location = new Point(39, 448);
            roundedButton7.Name = "roundedButton7";
            roundedButton7.Size = new Size(94, 29);
            roundedButton7.TabIndex = 7;
            roundedButton7.Text = "Log Out";
            roundedButton7.UseVisualStyleBackColor = true;
            roundedButton7.Click += roundedButton7_Click;
            // 
            // roundedButton6
            // 
            roundedButton6.CornerRadius = 30;
            roundedButton6.Location = new Point(39, 393);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Size = new Size(94, 29);
            roundedButton6.TabIndex = 6;
            roundedButton6.Text = "Event Summary";
            roundedButton6.UseVisualStyleBackColor = true;
            roundedButton6.Click += roundedButton6_Click;
            // 
            // roundedButton5
            // 
            roundedButton5.CornerRadius = 30;
            roundedButton5.Location = new Point(39, 342);
            roundedButton5.Name = "roundedButton5";
            roundedButton5.Size = new Size(94, 29);
            roundedButton5.TabIndex = 5;
            roundedButton5.Text = "Manage Resources";
            roundedButton5.UseVisualStyleBackColor = true;
            roundedButton5.Click += roundedButton5_Click;
            // 
            // roundedButton4
            // 
            roundedButton4.CornerRadius = 30;
            roundedButton4.Location = new Point(39, 290);
            roundedButton4.Name = "roundedButton4";
            roundedButton4.Size = new Size(94, 29);
            roundedButton4.TabIndex = 4;
            roundedButton4.Text = "Manange Venues";
            roundedButton4.UseVisualStyleBackColor = true;
            roundedButton4.Click += roundedButton4_Click;
            // 
            // roundedButton3
            // 
            roundedButton3.CornerRadius = 30;
            roundedButton3.Location = new Point(39, 235);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Size = new Size(94, 29);
            roundedButton3.TabIndex = 3;
            roundedButton3.Text = "Add Owner";
            roundedButton3.UseVisualStyleBackColor = true;
            roundedButton3.Click += roundedButton3_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.CornerRadius = 30;
            roundedButton2.Location = new Point(39, 175);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(94, 29);
            roundedButton2.TabIndex = 2;
            roundedButton2.Text = "Add Organizer";
            roundedButton2.UseVisualStyleBackColor = true;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // roundedButton1
            // 
            roundedButton1.CornerRadius = 30;
            roundedButton1.Location = new Point(39, 118);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(94, 29);
            roundedButton1.TabIndex = 1;
            roundedButton1.Text = "Add Event";
            roundedButton1.UseVisualStyleBackColor = true;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(22, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 600);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frm_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            WindowState = FormWindowState.Maximized;
            FormClosed += frm_Main_FormClosed;
            Load += frm_Main_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripMenuItem eventSummaryReportToolStripMenuItem;
        private Panel panel1;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private RoundedButton roundedButton7;
        private RoundedButton roundedButton6;
        private RoundedButton roundedButton5;
        private RoundedButton roundedButton4;
        private RoundedButton roundedButton3;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton1;
    }
}