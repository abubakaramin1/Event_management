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
            Mainmenu = new MenuStrip();
            registerToolStripMenuItem = new ToolStripMenuItem();
            addOrganizerToolStripMenuItem = new ToolStripMenuItem();
            addOwnerToolStripMenuItem = new ToolStripMenuItem();
            addResourceToolStripMenuItem = new ToolStripMenuItem();
            addVenueToolStripMenuItem = new ToolStripMenuItem();
            viewVenuesToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            addResourceToolStripMenuItem1 = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            eventSummaryReportToolStripMenuItem = new ToolStripMenuItem();
            eventSummaryToolStripMenuItem = new ToolStripMenuItem();
            Mainmenu.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Mainmenu
            // 
            Mainmenu.BackColor = Color.FromArgb(171, 136, 109);
            Mainmenu.Dock = DockStyle.Left;
            Mainmenu.Items.AddRange(new ToolStripItem[] { registerToolStripMenuItem, addOrganizerToolStripMenuItem, addOwnerToolStripMenuItem, addResourceToolStripMenuItem, addVenueToolStripMenuItem, viewVenuesToolStripMenuItem, logOutToolStripMenuItem, addResourceToolStripMenuItem1, eventSummaryToolStripMenuItem });
            Mainmenu.Location = new Point(0, 0);
            Mainmenu.Name = "Mainmenu";
            Mainmenu.Size = new Size(126, 450);
            Mainmenu.TabIndex = 1;
            Mainmenu.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            registerToolStripMenuItem.ForeColor = Color.White;
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(113, 19);
            registerToolStripMenuItem.Text = "Add Event";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // addOrganizerToolStripMenuItem
            // 
            addOrganizerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addOrganizerToolStripMenuItem.ForeColor = Color.White;
            addOrganizerToolStripMenuItem.Name = "addOrganizerToolStripMenuItem";
            addOrganizerToolStripMenuItem.Size = new Size(113, 19);
            addOrganizerToolStripMenuItem.Text = "Add Organizer";
            addOrganizerToolStripMenuItem.Click += addOrganizerToolStripMenuItem_Click;
            // 
            // addOwnerToolStripMenuItem
            // 
            addOwnerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addOwnerToolStripMenuItem.ForeColor = Color.White;
            addOwnerToolStripMenuItem.Name = "addOwnerToolStripMenuItem";
            addOwnerToolStripMenuItem.Size = new Size(113, 19);
            addOwnerToolStripMenuItem.Text = "Add Owner";
            addOwnerToolStripMenuItem.Click += addOwnerToolStripMenuItem_Click;
            // 
            // addResourceToolStripMenuItem
            // 
            addResourceToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addResourceToolStripMenuItem.ForeColor = Color.White;
            addResourceToolStripMenuItem.Name = "addResourceToolStripMenuItem";
            addResourceToolStripMenuItem.Size = new Size(113, 19);
            addResourceToolStripMenuItem.Text = "View Resources";
            addResourceToolStripMenuItem.Click += addResourceToolStripMenuItem_Click;
            // 
            // addVenueToolStripMenuItem
            // 
            addVenueToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addVenueToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            addVenueToolStripMenuItem.ForeColor = Color.White;
            addVenueToolStripMenuItem.Name = "addVenueToolStripMenuItem";
            addVenueToolStripMenuItem.Size = new Size(113, 19);
            addVenueToolStripMenuItem.Text = "Add Venue";
            addVenueToolStripMenuItem.Click += addVenueToolStripMenuItem_Click;
            // 
            // viewVenuesToolStripMenuItem
            // 
            viewVenuesToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            viewVenuesToolStripMenuItem.ForeColor = Color.White;
            viewVenuesToolStripMenuItem.Name = "viewVenuesToolStripMenuItem";
            viewVenuesToolStripMenuItem.Size = new Size(113, 19);
            viewVenuesToolStripMenuItem.Text = "View Venues";
            viewVenuesToolStripMenuItem.Click += viewVenuesToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            logOutToolStripMenuItem.ForeColor = Color.White;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(113, 19);
            logOutToolStripMenuItem.Text = "LogOut";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // addResourceToolStripMenuItem1
            // 
            addResourceToolStripMenuItem1.BackColor = Color.FromArgb(73, 54, 40);
            addResourceToolStripMenuItem1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addResourceToolStripMenuItem1.ForeColor = Color.White;
            addResourceToolStripMenuItem1.Name = "addResourceToolStripMenuItem1";
            addResourceToolStripMenuItem1.Size = new Size(113, 19);
            addResourceToolStripMenuItem1.Text = "Add Resource";
            addResourceToolStripMenuItem1.Click += addResourceToolStripMenuItem1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(171, 136, 109);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(126, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(698, 46);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(204, 43);
            toolStripLabel1.Text = "Serene Settings";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(119, 43);
            toolStripLabel2.Text = "Hello ________!";
            // 
            // eventSummaryReportToolStripMenuItem
            // 
            eventSummaryReportToolStripMenuItem.Name = "eventSummaryReportToolStripMenuItem";
            eventSummaryReportToolStripMenuItem.Size = new Size(133, 19);
            eventSummaryReportToolStripMenuItem.Text = "Event Summary Report";
            // 
            // eventSummaryToolStripMenuItem
            // 
            eventSummaryToolStripMenuItem.Name = "eventSummaryToolStripMenuItem";
            eventSummaryToolStripMenuItem.Size = new Size(113, 19);
            eventSummaryToolStripMenuItem.Text = "Event Summary";
            eventSummaryToolStripMenuItem.Click += eventSummaryToolStripMenuItem_Click;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 450);
            Controls.Add(toolStrip1);
            Controls.Add(Mainmenu);
            IsMdiContainer = true;
            MainMenuStrip = Mainmenu;
            Name = "frm_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frm_Main";
            WindowState = FormWindowState.Maximized;
            FormClosed += frm_Main_FormClosed;
            Load += frm_Main_Load;
            Mainmenu.ResumeLayout(false);
            Mainmenu.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Mainmenu;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem addOrganizerToolStripMenuItem;
        private ToolStripMenuItem addOwnerToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripMenuItem addResourceToolStripMenuItem;
        private ToolStripMenuItem addVenueToolStripMenuItem;
        private ToolStripMenuItem viewVenuesToolStripMenuItem;
        private ToolStripMenuItem addResourceToolStripMenuItem1;
        private ToolStripMenuItem eventSummaryReportToolStripMenuItem;
        private ToolStripMenuItem eventSummaryToolStripMenuItem;
    }
}