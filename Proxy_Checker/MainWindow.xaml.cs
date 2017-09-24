using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Proxy globalTemp;
        public int threads;

        List<BackgroundWorker> proxyWorker = new List<BackgroundWorker>();

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

            if (!Equals(dialogClosingEventArgs.Parameter, true)) return;
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
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerSupportsCancellation = true;
                    bw.WorkerReportsProgress = true;

                    bw.DoWork +=
                        new DoWorkEventHandler(readFile);
                    bw.ProgressChanged +=
                        new ProgressChangedEventHandler(bw_ProgressChanged);
                    bw.RunWorkerCompleted +=
                        new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    if (bw.IsBusy != true)
                    {
                        bw.RunWorkerAsync();
                    }
                });
            }
        }

        private void readFile(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Dispatcher.Invoke(() =>
            {
                statusProgress.IsIndeterminate = true;
                lblStatus.Content = "Reading File";
            });


            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else
            {
                string line;
                string append = "";
                //                    txtbox_Proxydetails.Items.Clear();
                System.IO.StreamReader file =
                    new System.IO.StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    Proxy temp = new Proxy();
                    var subline = line.Split(':');
                    temp.IP = subline[0];
                    temp.Port = subline[1];
                    append += line + "\n";
                    globalTemp = temp;

                    database.Add(temp);
//                    Console.WriteLine(line);
                }
                file.Close();

                Task.Run(
                    () =>
                    {
                        Dispatcher.BeginInvoke(
                            new Action(() =>
                            {
                                txtbox_Proxydetails.Text = append;
//                                txtbox_Proxydetails.Items=checking.Items; 
//                                Console.Write("Added");
                                listButton.Visibility = System.Windows.Visibility.Visible;
                                textButton.Visibility = System.Windows.Visibility.Visible;
                            }));
                    });
            }
        }


        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
            }

            else if (!(e.Error == null))
            {
            }

            else
            {
                Dispatcher.Invoke(() =>
                {
                    statusProgress.IsIndeterminate = false;
                    statusProgress.Visibility = System.Windows.Visibility.Hidden;
                    lblStatus.Content = "File loaded";
                });
            }
        }


        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            statusProgress.IsIndeterminate = true;
            lblStatus.Content = " Converting to list";
            prgrsBar.IsIndeterminate = true;
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    string append = "";
                    for (int i = 0; i < database.Count; i++)
                    {
                        append += database[i].IP + ":" + database[i].Port + "\n";
                    }
                    txtbox_Proxydetails.Text = append;
                    prgrsBar.IsIndeterminate = false;
                    statusProgress.IsIndeterminate = false;
                    lblStatus.Content = "Text Converted";
                });
            });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            statusProgress.IsIndeterminate = true;
            lblStatus.Content = " Converting to Text";
            prgrsBar.IsIndeterminate = true;
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    string append = "";
                    for (int i = 0; i < database.Count; i++)
                    {
                        append += $"{database[i].IP,15}{database[i].Port,15}" + "\n";
                    }
                    txtbox_Proxydetails.Text = append;
                    prgrsBar.IsIndeterminate = false;
                    statusProgress.IsIndeterminate = false;
                    lblStatus.Content = "List Converted";
                });
            });


            prgrsBar.IsIndeterminate = true;
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
//                    txtbox_Proxydetails.Items.Clear();
//                    txtbox_Proxydetails.Items.Add($"{"IP",10}{"PORT",10}");
                    for (int i = 0; i < database.Count; i++)
                    {
//                        txtbox_Proxydetails.Items.Add($"{database[i].IP,15}{database[i].Port,15}");
                    }
                    prgrsBar.IsIndeterminate = false;
                });
            });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (btnFileLoad.Content.Equals("Load List"))
            {
                MessageBox.Show("Please load a file", "Exception");
            }
            else
            {
                int parsedValue;
                if (txtBoxThread.Text.Equals(""))
                {
                    MessageBox.Show("Please enter value of thread.", "Enter threads");
                }
                else if (!int.TryParse(txtBoxThread.Text, out parsedValue))
                {
                    MessageBox.Show("This is a number only field", "Only numbers");
                }
                else
                {
                    threads = Int32.Parse(txtBoxThread.Text);
                    if (threads > 1 && threads < 100)
                    {
                    }
                    else
                    {
                        MessageBox.Show("The thread range is between 1 and 100", "Thread Range");
                    }
                }
            }
        }
    }
}