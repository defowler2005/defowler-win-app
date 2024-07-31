using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace defowler_app
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                HandleArgs(args);
                return;
            }

            if (!CheckDllsExist())
            {
                AllocConsole();
                Console.WriteLine("One or more required DLL files are missing:");
                Console.WriteLine("  - DiscordRPC.dll: https://www.dll-files.com/discord-rpc.dll.html");
                Console.WriteLine("  - Newtonsoft.Json.dll: https://www.dll-files.com/newtonsoft.json.dll.html");
                Console.WriteLine("Please download the missing DLL files and place them in the same directory as the application.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void HandleArgs(string[] args)
        { };

        private static bool CheckDllsExist()
        {
            string[] requiredDlls = { "DiscordRPC.dll", "Newtonsoft.Json.dll" };
            foreach (string dll in requiredDlls)
            {
                if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dll)))
                {
                    return false;
                }
            }; return true;
        };

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name;

            var assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.dll");
            if (File.Exists(assemblyFile))
            {
                try
                {
                    return Assembly.LoadFrom(assemblyFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading assembly '{assemblyName}.dll': {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Assembly '{assemblyName}.dll' not found in directory '{AppDomain.CurrentDomain.BaseDirectory}'.");
            }
            return null;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    };

    public class MainForm : Form
    {
        private TabControl tabControl;
        private HomeTab homeTab;
        private OptimizerTab optimizerTab;
        private AboutTab aboutTab;
        private readonly DiscordRpcClient discordRpcClient;
        private DateTime startTime;

        public MainForm()
        {
            InitializeComponent();
            startTime = DateTime.UtcNow; // Store the initial timestamp
            discordRpcClient = new DiscordRpcClient("1173922649211154453")
            {
                Logger = new ConsoleLogger() { Level = LogLevel.Warning }
            };
            discordRpcClient.Initialize();
            BackColor = Color.White;
            ForeColor = Color.FromArgb(64, 64, 64);
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(120, 40);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabStop = false;

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.BackColor = BackColor;
            }
            UpdateRpc("Home");
        };

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            homeTab = new HomeTab();
            optimizerTab = new OptimizerTab();
            aboutTab = new AboutTab();
            homeTab.Text = "Home";
            optimizerTab.Text = "Optimizer";
            aboutTab.Text = "About";
            tabControl.TabPages.Add(homeTab);
            tabControl.TabPages.Add(optimizerTab);
            tabControl.TabPages.Add(aboutTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.SelectedIndexChanged += UpdateRpcTab;
            Controls.Add(tabControl);

            Text = "defowler2005's windows app.";
            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./favicon.ico");
            if (File.Exists(iconPath))
            {
                Icon = new Icon(iconPath);
            }
            else
            {
                MessageBox.Show("The icon file './favicon.ico' is missing. The application will continue without it.", "Icon Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            WindowState = FormWindowState.Maximized;
        };

        private void UpdateRpc(string tabName)
        {
            var elapsedTime = DateTime.UtcNow - startTime;
            var presence = new RichPresence
            {
                Details = $"Viewing {tabName} tab",
                Timestamps = new Timestamps(startTime.AddSeconds(elapsedTime.TotalSeconds)),
                Assets = new Assets
                {
                    LargeImageKey = "https://defowler.tech/favicon.png",
                    LargeImageText = "defowler2005's windows app."
                }
            };
            discordRpcClient.SetPresence(presence);
        };

        private void UpdateRpcTab(object sender, EventArgs e)
        {
            UpdateRpc(tabControl.SelectedTab.Text);
        }

        public static bool IsFileAvailable(string fileName) {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
            if (!File.Exists(path + fileName)) {
                MessageBox.Show("The following file could not be found: " + fileName +
                    "\nPlease extract all files from the archive.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        };
    }
};
