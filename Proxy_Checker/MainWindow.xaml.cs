using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
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
        public bool IsOpen;
        public bool IsSmptOpen;
        public string Port;

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
        public int bad;

        public bool checkSmtp;
        public double chunkSize;
        public List<Proxy> database = new List<Proxy>();
        private string filename;
        public Proxy globalTemp;

        public int good;
        public int processed;
        private List<BackgroundWorker> proxyWorker = new List<BackgroundWorker>();
        public int smptCount;
        public int threadCompleted;
        public int threads;

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
                statusProgress.Visibility = Visibility.Visible;
                lblStatus.Visibility = Visibility.Visible;
                filename = dlg.FileName;
                btnFileLoad.Content = dlg.SafeFileName;
                Task.Run(() =>
                {
                    string line;
                    var bw = new BackgroundWorker();
                    bw.WorkerSupportsCancellation = true;
                    bw.WorkerReportsProgress = true;

                    bw.DoWork += readFile;
                    bw.ProgressChanged +=
                        bw_ProgressChanged;
                    bw.RunWorkerCompleted +=
                        bw_RunWorkerCompleted;
                    if (bw.IsBusy != true)
                        bw.RunWorkerAsync();
                });
            }
        }

        private void readFile(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            Dispatcher.Invoke(() =>
            {
                statusProgress.IsIndeterminate = true;
                lblStatus.Content = "Reading File";
            });


            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                string line;
                var append = "";
                //                    txtbox_Proxydetails.Items.Clear();
                var file =
                    new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    var temp = new Proxy();
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
                                listButton.Visibility = Visibility.Visible;
                                textButton.Visibility = Visibility.Visible;
                            }));
                    });
            }
        }


        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
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
                    statusProgress.Visibility = Visibility.Hidden;
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
                    var append = "";
                    for (var i = 0; i < database.Count; i++)
                        append += database[i].IP + ":" + database[i].Port + "\n";
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
                    var append = $"{"IP",15}{"Port",15}" + "\n";
                    for (var i = 0; i < database.Count; i++)
                        append += $"{database[i].IP,15}{database[i].Port,15}" + "\n";
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
                    for (var i = 0; i < database.Count; i++)
                    {
//                        txtbox_Proxydetails.Items.Add($"{database[i].IP,15}{database[i].Port,15}");
                    }
                    prgrsBar.IsIndeterminate = false;
                });
            });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            good = 0;
            processed = 0;
            bad = 0;
            smptCount = 0;
            database.Clear();
            if ((bool) chckBox.IsChecked)
                checkSmtp = true;
            else
                checkSmtp = false;

            statisticsTXT.Text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", database.Count, database.Count - processed,
                good, bad,
                smptCount);
            var open = 0;
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
                    threads = int.Parse(txtBoxThread.Text);
                    if (!(threads > 1 && threads < 100))
                    {
                        MessageBox.Show("The thread range is between 1 and 100", "Thread Range");
                    }
                    else
                    {
                        Dispatcher.Invoke(() =>
                        {
                            statusProgress.Visibility = Visibility.Visible;
                            lblStatus.Visibility = Visibility.Visible;
                            prgrsBar.IsIndeterminate = true;
                            statusProgress.IsIndeterminate = true;
                            lblStatus.Content = "Checking Proxies";
                        });
                        chunkSize = Math.Round(database.Count / (double) threads);
                        if (chunkSize > 0)
                            for (var i = 0; i < threads; i++)
                            {
                                var temp = new BackgroundWorker();
                                temp.WorkerSupportsCancellation = true;
                                temp.WorkerReportsProgress = true;

                                temp.DoWork +=
                                    CheckProxyStatus;
                                if (temp.IsBusy != true)
                                    temp.RunWorkerAsync(i);
                            }
                        else
                            MessageBox.Show("The threads are more than the IP's. Please select valid threads");
                    }
                }
            }
        }

        public void CheckProxyStatus(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var number = (int) e.Argument;
                var startingIndex = 0;
                if (number != 0)
                    startingIndex = number * (int) chunkSize;
                var endIndex = startingIndex + (int) chunkSize;
                Console.Write("The number of the thread is " + number + "  and it will check from " +
                              (startingIndex + 1) + "  to" + endIndex + "\n");
                var ping = new Ping();
                for (var j = startingIndex; j < endIndex; j++)
                {
                    if (j < database.Count)
                    {
                        var request = (HttpWebRequest) WebRequest.Create("http://google.com");
                        request.Proxy = new WebProxy(database[j].IP, int.Parse(database[j].Port));
                        request.UserAgent =
                            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
                        request.Timeout = 2000;

                        try
                        {
                            var response = request.GetResponse();
                            database[j].IsOpen = true;
                            Console.WriteLine(database[j].IP + "     Port = " + database[j].Port +
                                              "  :  Port open");
                            good++;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("It is not made " + database[j].IP + ":" + database[j].Port);
                        }
//                        var pingCount = 0;
//                        while (pingCount != 3)
//                        {
//                            var client = new TcpClient();
//                            if (!client.ConnectAsync(database[j].IP, int.Parse(database[j].Port)).Wait(1000))
//                            {
//                                Console.WriteLine(database[j].IP + "     Port = " + database[j].Port +
//                                                  "   :Port closed");
//                                // connection failure
//                            }
//                            else
//                            {
//                                Console.WriteLine(database[j].IP + "     Port = " + database[j].Port +
//                                                  "  :  Port open");
//                                database[j].IsOpen = true;
//                                good++;
//                                break;
//                            }
//                            pingCount++;
//                        }
//                        if (checkSmtp)
//                            while (pingCount != 3)
//                            {
//                                var client = new TcpClient();
//                                if (!client.ConnectAsync(database[j].IP, 25).Wait(1000))
//                                {
//                                    Console.WriteLine(database[j].IP + " SMTP    Port = " + 25 +
//                                                      "   :Port closed");
//                                }
//                                else
//                                {
//                                    Console.WriteLine(database[j].IP + " SMTP   Port = " + 25 +
//                                                      "  :  Port open");
//                                    database[j].IsSmptOpen = true;
//                                    smptCount++;
//                                    break;
//                                }
//                                pingCount++;
//                            }
                    }
                    processed++;

                    if (processed % 4 == 0)
                        Dispatcher.Invoke(
                            () =>
                            {
                                statisticsTXT.Text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", database.Count,
                                    database.Count - processed, good, processed - good, smptCount);
                            });
                }
                threadCompleted++;
                if (threadCompleted == threads)
                    Dispatcher.Invoke(() =>
                    {
                        statisticsTXT.Text = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", database.Count, 0, good,
                            processed - good, smptCount);
                        lblStatus.Content = "Task Completed";
                        statusProgress.IsIndeterminate = false;
                        statusProgress.Visibility = Visibility.Hidden;
                        prgrsBar.IsIndeterminate = false;
                    });
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (lblStatus.Content.Equals("Task Completed"))
            {
                var file = @"Report_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".csv";

                using (var stream = File.CreateText(file))
                {
                    for (var i = 0; i < database.Count; i++)
                    {
                        if (i == 0)
                            stream.WriteLine("{0},{1},{2}", "IP", "PORT", "Status");
                        if (database[i].IsOpen || database[i].IsSmptOpen)
                        {
                            var first = database[i].IP;
                            var second = database[i].Port;
                            var status = database[i].IsOpen.ToString();
                            var smtpStatus = database[i].IsSmptOpen.ToString();
                            var csvRow = string.Format("{0},{1},{2}", first, second, status);
                            stream.WriteLine(csvRow);
                        }
                    }
                }
                MessageBox.Show("File is saved at location : " + Assembly.GetEntryAssembly().Location + file);
            }
            else
            {
                MessageBox.Show("Start the task and wait for completion");
            }
        }
    }
}