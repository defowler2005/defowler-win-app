using System.Drawing;
using System.Windows.Forms;

namespace defowler_app
{
    public class HomeTab : TabPage
    {
        private Label aboutLabel;

        public HomeTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            aboutLabel = new Label
            {
                Text = "Home Page",
                Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(64, 64, 64),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(aboutLabel);
        }
    }
};