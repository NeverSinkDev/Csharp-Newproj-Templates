using TrayConsoleDemo.Extension;
using System;
using System.Windows.Forms;

namespace TrayConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = new System.Drawing.Icon(@"tray.ico");
            icon.Visible = true;

            icon.ShowBalloonMessage("Demo Tray", "Demo Tray Running", 3000);

            var mbItem = new MenuItem("Show me the message", MessageBox_Click);
            var closeItem = new MenuItem("Exit", ((e,v) => Application.Exit()));

            icon.ContextMenu = new ContextMenu();
            icon.ContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { mbItem, closeItem });

            Application.Run();
        }

        private static void MessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MessageBox reporting in.");
        }
    }
}
