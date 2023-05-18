using MetalowaRura.Properties;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            trayIcon = new NotifyIcon()
            {
                Icon = Resource1.intel,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Wyjdź", Exit)
            }),
                Visible = true
            };

            // Powiadomienie
            new ToastContentBuilder()
.AddText("Metalowa Rura zainicjowana")
.AddText("Made in robcio2137's basement")
.Show();

            // METALOWA RURA!!!!

            // Randomowy czas (Milisekundy)
            Random rnd = new Random();
            int number = rnd.Next(1000, 6000);

            Task.Run(() =>
            {
                while (true)
                {
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
