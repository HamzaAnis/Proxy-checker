using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace Proxy_Checker
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public class Proxy
    {
        public string IP;
        public string Port;
        public bool IsOpen;
        public bool IsSmptOpen;

        public Proxy()
        {
            IP = "";
            Port = "";
            IsOpen = false;
            IsSmptOpen = false;
        }
    }

    public partial class MainWindow : Window
    {
        private string filename;
        public List<Proxy> database = new List<Proxy>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs dialogClosingEventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (dialogClosingEventArgs.Parameter ?? ""));

            //you can cancel the dialog close:
            //eventArgs.Cancel();

            if (!Equals(dialogClosingEventArgs.Parameter, true)) return;

//            if (!string.IsNullOrWhiteSpace(FruitTextBox.Text))
//                FruitListBox.Items.Add(string.Format("{0}  |   {1}", FruitTextBox.Text, "Hamza Ains"));
//            FruitListBox.Items.Add("Column3Text").SubItems.AddRange(new string[] { "col1;row3", "col2;row3", "col3;row3" });
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnFileLoad_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text File (*.txt)|*.txt";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                btnFileLoad.Content = dlg.SafeFileName;
                Task.Run(() =>
                    {
                        string line;
                        Dispatcher.Invoke(() =>
                        {
                            txtbox_Proxydetails.Text = "";
                            System.IO.StreamReader file =
                                new System.IO.StreamReader(filename);
                            while ((line = file.ReadLine()) != null)
                            {
                                Proxy temp = new Proxy();
                                temp.IP = line;
                                database.Add(temp);
//                            txtbox_Proxydetails.Text += line + "\n";
////                            Console.WriteLine(line);
                            }
                            file.Close();
                            Console.WriteLine("The number of Proxies are " + database.Count);
                            Task.Run(() =>
                            {
                                for (int i = 0; i < database.Count; i++)
                                {
                                    Dispatcher.Invoke(() => { txtbox_Proxydetails.Text += database[i].IP + "\n"; });
                                }
                            });
                        });
                    })
                    ;
            }
        }
    }
}