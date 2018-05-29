using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Ninject;
using Nipema.Tyonohjaus.Client.ViewModels;

namespace Nipema.Tyonohjaus.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class TyonohjausNinjectModule : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                Bind<ICompactOhjeVM>().To<CompactOhjeVM>();
            }
        }

        public MainWindow()
        {
            InitializeNinject();
            InitializeComponent();
        }
        
        private void InitializeNinject()
        {
            var kernel = new StandardKernel(new TyonohjausNinjectModule());
            kernel.Load(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
