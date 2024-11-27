using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_management
{
    public class ShadowPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a LinearGradientBrush for the shadow
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(100, 0, 0, 0),  // Dark shadow color
                Color.FromArgb(0, 0, 0, 0),    // Transparent color
                45f)) // 45 degree angle for shadow direction
            {
                e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
            }
        }
    }

}
