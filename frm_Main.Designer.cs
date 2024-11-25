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
            MIaddevent = new ToolStripMenuItem();
            eventOwnerToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            Mainmenu.SuspendLayout();
            SuspendLayout();
            // 
            // Mainmenu
            // 
            Mainmenu.Items.AddRange(new ToolStripItem[] { registerToolStripMenuItem, logOutToolStripMenuItem });
            Mainmenu.Location = new Point(0, 0);
            Mainmenu.Name = "Mainmenu";
            Mainmenu.Size = new Size(800, 24);
            Mainmenu.TabIndex = 1;
            Mainmenu.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MIaddevent, eventOwnerToolStripMenuItem });
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(61, 20);
            registerToolStripMenuItem.Text = "&Register";
            // 
            // MIaddevent
            // 
            MIaddevent.Name = "MIaddevent";
            MIaddevent.Size = new Size(180, 22);
            MIaddevent.Text = "&Add Event";
            MIaddevent.Click += MIaddevent_Click;
            // 
            // eventOwnerToolStripMenuItem
            // 
            eventOwnerToolStripMenuItem.Name = "eventOwnerToolStripMenuItem";
            eventOwnerToolStripMenuItem.Size = new Size(180, 22);
            eventOwnerToolStripMenuItem.Text = "Event &Owner";
            eventOwnerToolStripMenuItem.Click += eventOwnerToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(59, 20);
            logOutToolStripMenuItem.Text = "LogOut";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Mainmenu;
        private ToolStripMenuItem registerToolStripMenuItem;
        private ToolStripMenuItem MIaddevent;
        private ToolStripMenuItem eventOwnerToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}