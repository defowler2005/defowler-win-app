using System.Drawing;
using System.Windows.Forms;

namespace defowler_app
{
    public class HomeTab : TabPage
    {
        private Label helloLabel;

        public HomeTab()
        {
            InitializeComponent();
            ApplyModernStyles();
        }

        private void InitializeComponent()
        {
            helloLabel = new Label
            {
                Text = "Hello",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(helloLabel);
        }

        private void ApplyModernStyles()
        {
            // Modern font
            helloLabel.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            // Modern color
            helloLabel.ForeColor = Color.FromArgb(64, 64, 64);
            // Padding and margins for spacing
            helloLabel.Padding = new Padding(10);
            Margin = new Padding(20);
            // Add more modern styles as needed
        }
    }
}
