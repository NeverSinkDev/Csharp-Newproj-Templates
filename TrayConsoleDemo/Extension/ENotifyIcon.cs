using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TrayConsoleDemo.Extension
{
    public static class ENotifyIcon
    {
        public static void ShowBalloonMessage(this NotifyIcon icon, string title, string message, int duration = 3000)
        {
            icon.BalloonTipText = title;
            icon.BalloonTipTitle = message;
            icon.BalloonTipIcon = ToolTipIcon.Info;
            icon.ShowBalloonTip(duration);
        }
    }
}
