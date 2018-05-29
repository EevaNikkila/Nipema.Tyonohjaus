using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nipema.Tyonohjaus.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Tyonohjaus _tyonohjaus;

        public void Tyonohjaus_Startup(object sender, StartupEventArgs e)
        {
            _tyonohjaus = new Tyonohjaus();

            DispatcherUnhandledException += _tyonohjaus.HandleException;
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
