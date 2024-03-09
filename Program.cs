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

            TabControl tabControl = new TabControl();
            tabControl.TabPages.Add(new TabPage("Tab 1"));
            tabControl.TabPages.Add(new TabPage("Tab 2"));

            tabControl.TabPages[0].Controls.Add(new Label
            {
                Text = "Content for Tab 1",
                AutoSize = true,
                Location = new System.Drawing.Point(50, 50)
            });

            tabControl.TabPages[1].Controls.Add(new Label
            {
                Text = "Content for Tab 2",
                AutoSize = true,
                Location = new System.Drawing.Point(50, 50)
            });

            tabControl.TabPages[2].Controls.Add(new Label
            {
                Text = "Content for Tab 3",
                AutoSize = true,
                Location = new System.Drawing.Point(50, 50)
            });

            tabControl.Dock = DockStyle.Top;

            Form form = new Form
            {
                Text = "defowler005's windows app.",
                Size = new System.Drawing.Size(300, 200),
                Icon = new Icon("./favicon.ico"),
                BackgroundImage = Image.FromFile("./background.png")
            };

            form.Controls.Add(tabControl);
            form.Controls.Add(helloLabel);
            Application.Run(form);
        }
    }
};
