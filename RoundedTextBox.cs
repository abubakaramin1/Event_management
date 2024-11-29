using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : TextBox
{
    public int BorderRadius { get; set; } = 15; // Default radius

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = this.ClientRectangle;
        rect.Inflate(-1, -1);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(rect.X, rect.Y, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Y, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(rect.Right - BorderRadius, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();

            using (Pen pen = new Pen(Color.Gray, 1)) // Border color and thickness
            {
                g.DrawPath(pen, path);
            }

            Region = new Region(path);
        }
    }
}
