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
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            eventSummaryReportToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(171, 136, 109);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(824, 46);
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
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 450);
            Controls.Add(toolStrip1);
            IsMdiContainer = true;
            Name = "frm_Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frm_Main";
            WindowState = FormWindowState.Maximized;
            FormClosed += frm_Main_FormClosed;
            Load += frm_Main_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripMenuItem eventSummaryReportToolStripMenuItem;
    }
}