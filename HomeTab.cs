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
		}

		private void InitializeComponent()
		{
			helloLabel = new Label
			{
				Text = "Hello",
				Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold),
				ForeColor = System.Drawing.Color.FromArgb(64, 64, 64),
				AutoSize = true,
				TextAlign = ContentAlignment.MiddleCenter
			};

			Controls.Add(helloLabel);
		}
	}
};