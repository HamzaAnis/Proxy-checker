using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Proxy_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            Task.Run(() =>
            {
                if (e.NewValue)
                {
                    Thread.Sleep(1000);
                    Process.Start("https://www.freelancer.com/u/khurram4225");
                }
            });
        }
    }
}