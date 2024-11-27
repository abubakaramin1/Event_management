using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Event_management
{
    public class RoundedToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.Item.Bounds;
            int radius = 10; // Set the radius of rounded corners
            GraphicsPath path = new GraphicsPath();

            // Add rounded rectangle corners
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Fill the background with the specified color (rgb(73, 54, 40))
            using (Brush brush = new SolidBrush(Color.FromArgb(73, 54, 40)))
            {
                g.FillPath(brush, path); // Fill the rounded area
            }

            // Draw the border (optional)
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawPath(pen, path); // Border around the rounded area
            }

            // If the item is not selected, use the default rendering
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    }
}
