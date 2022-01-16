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

namespace Test_rm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repository = new Repository();
            bool validateRepositoryExists = repository.ValidateRepositoryExists();
            if (!validateRepositoryExists)
            {
                repository.CreateRepository();
            }

        }

        string sChannel="";
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            sChannel += button.Content.ToString();
            txtChannelSend.Text = sChannel;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (sChannel!="")
            { 
                var repository = new Repository();
                repository.RegisterButtonClick(sChannel);
                txtChannelSend.Text = "";
                sChannel = "";
            }

        }

        private void btnCommand_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string sCommand=button.Content.ToString();
            var repository = new Repository();
            repository.RegisterButtonClick(sCommand);
        }

    }
}
