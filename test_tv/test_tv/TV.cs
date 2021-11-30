using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace test_tv
{
    class TV
    {
        public bool Power { get; private set; }
        public int Volume { get; private set; }
        public int Channel { get; private set; }
        public string Source { get; private set; }

        public TV()
        {
            Power = false;
            Volume = 20;
            Channel = 1;
            Source = "TV";
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

    }
}
