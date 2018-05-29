using Nipema.Tyonohjaus.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Nipema.Tyonohjaus.Client
{
    public class Tyonohjaus
    {
        public Tyonohjaus()
        {
        }

        public void HandleException(object sender, Exception e)
        {
            // Jotain
        }

        public void Log()
        {
            // Jotain
        }

        internal void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            new ExceptionWindow(e.Exception).Show();

        }
    }
}
