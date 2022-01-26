using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace test_tv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bgWorker; int progress;
        public TV TV { get; set; }
        TV tv = new TV();

        public MainWindow()
        {
            InitializeComponent();
            StartWorker();
            DataContext = tv;
        }
        private void StartWorker()
        {
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;

            progress = 1;
            bgWorker.RunWorkerAsync();
        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var repository = new Repository();
                string sCommando = repository.ReadCommand();
                if (sCommando != "No command")
                {

                    bgWorker.ReportProgress(progress, sCommando); // reports to "ProgressChanged"
                } 

                progress++;
                if (progress == 100)
                {
                    progress = 1;
                }

                 repository.DeleteCommand();
                 Thread.Sleep(100);
            }
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // code here for updating progress
            string sCommando = e.UserState.ToString();
            Checkcommand(sCommando);

        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // code here for shutting down tv (progress == 100)
            MessageBox.Show("Shutting down...");
            Close();
        }



        public void Checkcommand(string sCommando)
        {
            if (sCommando == "POWER")
            {
                Power();
            }
            else
            {
                if (tv.Power)
                {

                    switch (sCommando)
                    {
                        case "^":
                            if (tv.Source == "TV")
                            {
                                tv.Channelup();
                            }
                            break;
                        case "v":
                            if (tv.Source == "TV")
                            {
                                tv.Channeldown();
                            }
                            break;
                        case "+":
                            tv.Volumeup();
                            break;
                        case "-":
                            tv.Volumedown();
                            break;
                        case "SOURCE":
                            tv.Sourcechange();
                            Sourcesettings();
                            break;
                        case "SETTINGS":
                            tv.Settings = !tv.Settings;
                            break;
                        default:
                            if (tv.Source == "TV")
                            {
                                tv.Channelnumber(int.Parse(sCommando));
                            }
                            break;
                    }
                }
            }
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            Power();
        }

        public void Power()
        {
            if (!tv.Power)
            {
                tv.Powerbutton();
                btnPower.Background = Brushes.Green;

                if (tv.UseStartupsettings)
                {
                    tv.Channelnumber(tv.Startupchannel);
                    tv.Volume = tv.Startupvolume;
                    tv.Source = tv.Startupsource;
                }

                if (tv.Source!="TV")
                {
                    txtblockChannelnr.Visibility = Visibility.Collapsed;
                    lblChannel.Visibility = Visibility.Collapsed;
                    lblSource.Visibility = Visibility.Visible;
                }
                else
                {
                    txtblockChannelnr.Visibility = Visibility.Visible;
                    lblChannel.Visibility = Visibility.Visible;
                    lblSource.Visibility = Visibility.Collapsed;
                }

            }
            else
            {
                tv.Powerbutton();
                tv.Settings = false;
                txtblockChannelnr.Visibility = Visibility.Collapsed;
                lblChannel.Visibility = Visibility.Collapsed;
                lblSource.Visibility = Visibility.Collapsed;
                btnPower.Background = Brushes.Gray;
            }
        }

        private void TV_Button_Click(object sender, RoutedEventArgs e)
        {
 
            var button = (Button)sender;
            string sCommand = button.Content.ToString();
            Checkcommand(sCommand);
        }

        private void btnSource_Click(object sender, RoutedEventArgs e)
        {
            Sourcesettings();
        }


        private void Sourcesettings()
        {
            if (tv.Power)
            {
                tv.Sourcechange();
                if (tv.Source == "TV")
                {
                    txtblockChannelnr.Visibility = Visibility.Visible;
                    lblChannel.Visibility = Visibility.Visible;
                    lblSource.Visibility = Visibility.Collapsed;
                }
                else
                {
                    txtblockChannelnr.Visibility = Visibility.Collapsed;
                    lblChannel.Visibility = Visibility.Collapsed;
                    lblSource.Visibility = Visibility.Visible;
                }
            }
        }


        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            tv.Settings = !tv.Settings;
        }

        private void txtStartupchannel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
