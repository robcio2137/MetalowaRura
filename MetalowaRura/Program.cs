using MetalowaRura.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalowaRura
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Rura());
        }
    }


    public class Rura : ApplicationContext
    {

        private NotifyIcon trayIcon;

        public Rura()
        {
            // Initialize Tray Icon
            // Powiadomienie
            trayIcon = new NotifyIcon()
            {
                Icon = Resource1.intel,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Wyjdź", Exit)
                }),
                Visible = true,
            };
            trayIcon.ShowBalloonTip(3000, "Metalowa Rura zainicjowana", "Made in robcio2137's basement.", ToolTipIcon.Warning);
                // METALOWA RURA!!!!
            

            Task.Run(() =>
            {
                Random rnd = new Random();
                while (true)
                {
                    // Randomowy czas
                    int number = rnd.Next(1000, 5000);

                    System.Threading.Thread.Sleep(number * 60);
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resource1.Stable);
                    player.Play();
                }
            });

        }

        void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
