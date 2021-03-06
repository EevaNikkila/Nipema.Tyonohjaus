﻿using System;
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
using System.Windows.Shapes;

namespace Nipema.Tyonohjaus.Client.Views
{
    /// <summary>
    /// Interaction logic for Exception.xaml
    /// </summary>
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow(Exception ex)
        {
            InitializeComponent();
            this.exceptionLabel.Content = ex.Message;
        }
    }
}
