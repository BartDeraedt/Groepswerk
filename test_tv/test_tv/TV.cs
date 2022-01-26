using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace test_tv
{
    public class TV : INotifyPropertyChanged
    { private bool _power;
        public bool Power
        {
            get { return _power; }
            private set
            {
                _power = value;
                RoepPropertyChangedOp();
            }
        }

    private int _volume;
        public int Volume
        {
            get { return _volume; }
             set { _volume = value;
                    RoepPropertyChangedOp();
                 }
        }

        private int _channel;
        public int Channel
        {
            get { return _channel; }
            private set { _channel = value;
                          RoepPropertyChangedOp();
                        }
        }

        private string _source;
        public string Source
        {
            get { return _source; }
             set { 
                   _source = value;
                   RoepPropertyChangedOp();
                 }
        }

        private bool _settings;
        public bool Settings
        {
            get { return _settings; }
            set { _settings = value;
                RoepPropertyChangedOp();
                }
        }

        private bool _usestartupsettings;
        public bool UseStartupsettings
        {
            get { return _usestartupsettings; }
            set { _usestartupsettings = value;
                RoepPropertyChangedOp();
                }
        }


        private int _startupchannel;
        public int Startupchannel
        {
            get { return _startupchannel; }
            set { _startupchannel = value;
                RoepPropertyChangedOp();
                }
        }

        private int _startupvolume;
        public int Startupvolume
        {
            get { return _startupvolume; }
            set { _startupvolume = value;
                RoepPropertyChangedOp();
            }
        }

        private string _startupsource;
        public string Startupsource
        {
            get { return _startupsource; }
            set { _startupsource = value;
                RoepPropertyChangedOp();
            }
        }


        public TV()
        {
            Power = false;
            Volume = 20;
            Channel = 1;
            Source = "TV";
            Startupchannel = 1;
            Startupvolume = 20;
            Startupsource = "TV";
        }

        public void Powerbutton()
        {
            Power = !Power;
        }

        public void Channelup()
        {
            if (Channel < 999)
            {
                Channel++;
            }
        }
        public void Channeldown()
        {
            if (Channel > 0)
            {
                Channel--;
            }
        }
        public void Volumeup()
        {
            if (Volume < 60)
            {
                Volume++;
            }
        }
        public void Volumedown()
        {
            if (Volume > 0)
            {
                Volume--;
            }
        }
        public void Sourcechange()
        {
            if (Source == "TV")
            {
                Source = "HDMI1";
            }
            else
            {
                if (Source == "HDMI1")
                {
                    {
                        Source = "HDMI2";
                    }
                }
                else
                {
                    if (Source == "HDMI2")
                    {
                        Source = "TV";                      
                    }
                }
            }
        }

        public void Channelnumber(int channel)
        {
            if (channel <= 999)
            {
                Channel = channel;
            }
            else
            {
                Channel = 999;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RoepPropertyChangedOp([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
