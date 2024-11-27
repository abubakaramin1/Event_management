using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Event_management
{
    // Custom Button with rounded corners
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 30; // Default corner radius

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Create a rounded rectangle path
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = this.ClientRectangle;
                int radius = CornerRadius;

                // Add the rounded corners to the path
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                // Set the button's region to the rounded rectangle
                this.Region = new Region(path);

                // Optional: Draw a border around the button
                using (Pen pen = new Pen(Color.Black, 2)) // Set border color and thickness
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Apply smoothing for rounded corners
                    pevent.Graphics.DrawPath(pen, path); // Draw the border
                }

                // Optional: Draw the button text
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, this.BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
