using System.Drawing;
using System.Windows.Forms;

namespace defowler_app
{
	public class AboutTab : TabPage
	{
		private readonly Label aboutLabel;

		public AboutTab()
		{
            aboutLabel = new Label
            {
                Text = "About Page",
                Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(64, 64, 64),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(aboutLabel);
        }
	}
};