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

         TV tv = new TV();

        public MainWindow()
        {
            InitializeComponent();
            StartWorker();
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
            DataContext = tv;
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
                                txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
                            }
                            break;
                        case "v":
                            if (tv.Source == "TV")
                            {
                                tv.Channeldown();
                                txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
                            }
                            break;
                        case "+":
                            tv.Volumeup();
                            txtblockVolume.Text = "Vol: " + tv.Volume.ToString();
                            break;
                        case "-":
                            tv.Volumedown();
                            txtblockVolume.Text = "Vol: " + tv.Volume.ToString();
                            break;
                        case "SOURCE":
                            tv.Sourcechange();
                            if (tv.Source == "TV")
                            {
                                txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
                            }
                            else
                            {
                                txtblockChannelnr.Text = tv.Source;
                            }
                            break;
                        case "SETTINGS":
                            tv.Settings = !tv.Settings;
                            Settings();
                            break;
                        default:
                            if (tv.Source == "TV")
                            {
                                tv.Channelnumber(int.Parse(sCommando));
                                txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
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
                    txtblockChannelnr.Text = tv.Source;
                }
                else
                {
                    txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
                }
                txtblockVolume.Text = "Vol: " + tv.Volume.ToString();

            }
            else
            {
                Settings();
                tv.Powerbutton(); 
                btnPower.Background = Brushes.Gray;
                txtblockChannelnr.Text = "";
                txtblockVolume.Text = "";
                HideSettings();
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
 
            if (tv.Power)
            {
                tv.Sourcechange();
                if (tv.Source == "TV")
                {
                    txtblockChannelnr.Text = "Ch: " + tv.Channel.ToString();
                }
                else
                {
                    txtblockChannelnr.Text = tv.Source;
                }
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            tv.Settings = !tv.Settings;
            Settings();
        }

        private void Settings()
        {
            if (tv.Power)
            {
  
                if (tv.Settings)
                {
                    labstartupchannel.Visibility = Visibility.Visible;
                    ChkboxUse.Visibility = Visibility.Visible;
                    txtStartupchannel.Visibility = Visibility.Visible;
                    labstartupvolume.Visibility = Visibility.Visible;
                    txtStartupvolume.Visibility = Visibility.Visible;
                    labstartupsource.Visibility = Visibility.Visible;
                    ComboboxSource.Visibility = Visibility.Visible;
                }
                else
                {
                    HideSettings();
                }

                tv.Startupchannel = Int32.Parse(txtStartupchannel.Text);
                tv.Startupvolume = Int32.Parse(txtStartupvolume.Text);
                tv.Startupsource = ComboboxSource.Text;

            }
        }

        private void HideSettings()
        {
            labstartupchannel.Visibility = Visibility.Collapsed;
            ChkboxUse.Visibility = Visibility.Collapsed;
            txtStartupchannel.Visibility = Visibility.Collapsed;
            labstartupvolume.Visibility = Visibility.Collapsed;
            txtStartupvolume.Visibility = Visibility.Collapsed;
            labstartupsource.Visibility = Visibility.Collapsed;
            ComboboxSource.Visibility = Visibility.Collapsed;
            tv.Settings = false;
        }

        private void ChkboxUse_Checked(object sender, RoutedEventArgs e)
        {
            tv.UseStartupsettings = true;
            if (tv.UseStartupsettings)
            {
                tv.Startupchannel = Int32.Parse(txtStartupchannel.Text);
                tv.Startupvolume = Int32.Parse(txtStartupvolume.Text);
                tv.Startupsource = ComboboxSource.Text;
            }
        }

        private void ChkboxUse_Unchecked(object sender, RoutedEventArgs e)
        {
            tv.UseStartupsettings = false;
        }

        private void txtStartupchannel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
