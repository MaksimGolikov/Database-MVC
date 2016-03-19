using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class TapRecoder:Device,IState,IVolume,IMode
    {
        
        public TapRecoder(string name)
        {
            this.Name = name;
            this.Id = "tr";
            this.State = false;
            this.Volume = 20;
            this.Mode = true; 

        }

        public bool State { get; set; }
        public int Volume { get; set; }
        public bool Mode { get; set; }

        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }

        public void VolumeUp()
        {
            if (Volume < 100)
                Volume++;
        }
        public void VolumeDown()
        {
            if (Volume >1)
                Volume--;
        }

        public void ChangeMod()
        {
            this.Mode = !Mode;
        }
        public string StateMode()
        {

            string mode;

            if (this.Mode)
            {               
                mode = "CD";
            }
            else
            {               
                mode = "Radio";
            }
            return mode;
        }
    }
}