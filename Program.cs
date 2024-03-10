using System;
using System.Drawing;
using System.Windows.Forms;

namespace defowler2005_app
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                foreach (string arg in args)
                {
                    if (arg.StartsWith("/test="))
                    {
                        string testValue = arg.Substring("/test=".Length);

                        MessageBox.Show($"Test value: {testValue}", "Test Argument");
                    }
                }
            }

            MainForm mainForm = new MainForm
            {
                Visible = true
            };
            Application.Run(mainForm);
        }
    }

    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "defowler2005's App";
            Icon = new Icon("../../favicon.ico");
            AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
            Label label = new Label
            {
                Text = "Welcome to defowler2005's App!",
                AutoSize = true,
                Location = new System.Drawing.Point(50, 50)
            };
            Controls.Add(label);
        }
    }
};