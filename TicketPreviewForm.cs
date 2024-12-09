using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Event_management
{
    public partial class TicketPreviewForm : Form
    {
        private List<(string AttendeeName, string EventName, DateTime EventDate, string VenueName, string TicketID)> tickets;
        private string folderPath;
        private long eventId;

        public TicketPreviewForm(List<(string AttendeeName, string EventName, DateTime EventDate, string VenueName, string TicketID)> tickets, string folderPath, long eventId)
        {
            InitializeComponent();
            this.tickets = tickets;
            this.folderPath = folderPath;
            this.eventId = eventId;
            flowLayoutPanelThumbnails.Resize += flowLayoutPanelThumbnails_Resize;




            // Configure FlowLayoutPanel for vertical layout and centering
            flowLayoutPanelThumbnails.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelThumbnails.WrapContents = false; // Ensure vertical alignment
            flowLayoutPanelThumbnails.AutoScroll = true;    // Enable scrolling
            flowLayoutPanelThumbnails.Padding = new Padding(0, 10, 0, 10); // Add padding for spacing
            flowLayoutPanelThumbnails.Dock = DockStyle.Fill; // Fill available space
            flowLayoutPanelThumbnails.HorizontalScroll.Enabled = false; // Disable horizontal scrolling
            flowLayoutPanelThumbnails.HorizontalScroll.Visible = false; // Hide horizontal scrollbar

            // Center the thumbnails
            flowLayoutPanelThumbnails.Margin = new Padding(0); // Remove margin to allow centering
            flowLayoutPanelThumbnails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;


            // Generate thumbnails
            GenerateThumbnails();
        }

        private void GenerateThumbnails()
        {
            // Set a fixed size for the thumbnails
            const int thumbnailWidth = 400;
            const int thumbnailHeight = 200;

            foreach (var ticket in tickets)
            {
                // Generate QR Code
                string qrData = $"Attendee: {ticket.AttendeeName}, Event: {ticket.EventName}, Date: {ticket.EventDate:dd-MM-yyyy}, Venue: {ticket.VenueName}, TicketID: {ticket.TicketID}";
                Bitmap qrCode = GenerateQRCode(qrData);

                // Create ticket image
                Bitmap ticketImage = new Bitmap(thumbnailWidth, thumbnailHeight);
                using (Graphics graphics = Graphics.FromImage(ticketImage))
                {
                    DesignTicket(graphics, ticket.AttendeeName, ticket.EventName, ticket.EventDate, ticket.VenueName, ticket.TicketID, qrCode);
                }

                // Create PictureBox for the thumbnail
                PictureBox pictureBox = new PictureBox
                {
                    Image = ticketImage,
                    SizeMode = PictureBoxSizeMode.Zoom, // Ensures images fit well without distortion
                    Width = thumbnailWidth,
                    Height = thumbnailHeight,
                    Margin = new Padding((flowLayoutPanelThumbnails.ClientSize.Width - thumbnailWidth) / 2, 10, 0, 10) // Centering horizontally
                };

                // Add the PictureBox (thumbnail) to the FlowLayoutPanel
                flowLayoutPanelThumbnails.Controls.Add(pictureBox);
            }
        }
        private void flowLayoutPanelThumbnails_Resize(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanelThumbnails.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.Margin = new Padding((flowLayoutPanelThumbnails.ClientSize.Width - pictureBox.Width) / 2, 10, 0, 10);
                }
            }
        }


        private void SaveTicketImages()
        {
            foreach (var ticket in tickets)
            {
                // Generate QR Code
                string qrData = $"Attendee: {ticket.AttendeeName}, Event: {ticket.EventName}, Date: {ticket.EventDate:dd-MM-yyyy}, Venue: {ticket.VenueName}, TicketID: {ticket.TicketID}";
                Bitmap qrCode = GenerateQRCode(qrData);

                // Create ticket image
                Bitmap ticketImage = new Bitmap(400, 200); // Same size as thumbnails
                using (Graphics graphics = Graphics.FromImage(ticketImage))
                {
                    DesignTicket(graphics, ticket.AttendeeName, ticket.EventName, ticket.EventDate, ticket.VenueName, ticket.TicketID, qrCode);
                }

                // Save image to the selected folder
                string filePath = Path.Combine(folderPath, $"{ticket.TicketID}.png");
                ticketImage.Save(filePath);
            }

            // Show confirmation message
            MessageBox.Show("Tickets generated and saved successfully!");
        }

        private void DesignTicket(Graphics graphics, string attendeeName, string eventName, DateTime eventDate, string venueName, string ticketId, Bitmap qrCode)
        {
            // Set a white background for the ticket
            graphics.Clear(Color.White);

            // Set up font and brush for text
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontDetails = new Font("Arial", 10, FontStyle.Regular);
            Brush textBrush = Brushes.Black;

            // Draw the event name as title
            graphics.DrawString(eventName, fontTitle, textBrush, new PointF(10, 10));

            // Draw other text details
            graphics.DrawString($"Attendee: {attendeeName}", fontDetails, textBrush, new PointF(10, 40));
            graphics.DrawString($"Event Date: {eventDate:dd-MM-yyyy}", fontDetails, textBrush, new PointF(10, 70));
            graphics.DrawString($"Venue: {venueName}", fontDetails, textBrush, new PointF(10, 100));
            graphics.DrawString($"Ticket ID: {ticketId}", fontDetails, textBrush, new PointF(10, 130));

            // Draw QR Code
            graphics.DrawImage(qrCode, 250, 40, 100, 100);
        }

        private Bitmap GenerateQRCode(string qrData)
        {
            // Create a QR Code generator instance
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // Generate QR Code data
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

            // Use the QR Code data to create the QR code
            QRCode qrCode = new QRCode(qrCodeData);

            // Render the QR code as a Bitmap image
            return qrCode.GetGraphic(20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveTicketImages();

            // Close the preview form
            this.Close();
        }
    }
}
