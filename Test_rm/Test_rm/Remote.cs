using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test_rm
{
    public class Remote : INotifyPropertyChanged
    {

        private string _channel;
        public string Channel
        {
            get { return _channel; }
            set {
                    _channel = value;
                    RoepPropertyChangedOp();
                }        
        }

        public string Command { get; set; }


        private ObservableCollection<string> _changelog;
        public ObservableCollection<string> Changelog
        {
            get { return _changelog; }
            set { _changelog = value;
            }
        }

        public Remote()
        {
            Channel = "";
            Changelog = new ObservableCollection<string>();
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        private void RoepPropertyChangedOp([CallerMemberName] string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
