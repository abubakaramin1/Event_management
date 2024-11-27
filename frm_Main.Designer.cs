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
            logOutToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            Mainmenu.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Mainmenu
            // 
            Mainmenu.BackColor = Color.FromArgb(228, 224, 225);
            Mainmenu.Dock = DockStyle.Left;
            Mainmenu.Items.AddRange(new ToolStripItem[] { registerToolStripMenuItem, addOrganizerToolStripMenuItem, addOwnerToolStripMenuItem, logOutToolStripMenuItem });
            Mainmenu.Location = new Point(0, 0);
            Mainmenu.Name = "Mainmenu";
            Mainmenu.Size = new Size(101, 450);
            Mainmenu.TabIndex = 1;
            Mainmenu.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            registerToolStripMenuItem.ForeColor = Color.White;
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(88, 19);
            registerToolStripMenuItem.Text = "Add Event";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // addOrganizerToolStripMenuItem
            // 
            addOrganizerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addOrganizerToolStripMenuItem.ForeColor = Color.White;
            addOrganizerToolStripMenuItem.Name = "addOrganizerToolStripMenuItem";
            addOrganizerToolStripMenuItem.Size = new Size(88, 19);
            addOrganizerToolStripMenuItem.Text = "Add Organizer";
            addOrganizerToolStripMenuItem.Click += addOrganizerToolStripMenuItem_Click;
            // 
            // addOwnerToolStripMenuItem
            // 
            addOwnerToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            addOwnerToolStripMenuItem.ForeColor = Color.White;
            addOwnerToolStripMenuItem.Name = "addOwnerToolStripMenuItem";
            addOwnerToolStripMenuItem.Size = new Size(88, 19);
            addOwnerToolStripMenuItem.Text = "Add Owner";
            addOwnerToolStripMenuItem.Click += addOwnerToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.BackColor = Color.FromArgb(73, 54, 40);
            logOutToolStripMenuItem.ForeColor = Color.White;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(88, 19);
            logOutToolStripMenuItem.Text = "LogOut";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(228, 224, 225);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(101, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(723, 46);
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
    }
}