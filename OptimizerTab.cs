using System.Drawing;
using System.Windows.Forms;

namespace defowler_app
{
	public class OptimizerTab : TabPage
	{
		private Label aboutLabel;

		public OptimizerTab()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			aboutLabel = new Label
			{
				Text = "Optimizer Page",
				Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold),
				ForeColor = System.Drawing.Color.FromArgb(64, 64, 64),
				AutoSize = true,
				TextAlign = ContentAlignment.MiddleCenter
			};

			Controls.Add(aboutLabel);
		}
	}
};