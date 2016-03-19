using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class DVD:Device,IDisk
    {
        public DVD(string name)
        {
            this.Name = name;
            this.Id = "dvd";           
            this.IsPlay = false;
            this.IsDiskboxOpen = false;
        }

        public bool State { get; set; }       
        public bool IsDiskboxOpen { get; set; }
        public bool IsPlay { get; set; }


        public bool Switch()
        {
            if (this.State)
                this.State = false;
            else
                this.State = true;

            return State;
        }
              

        public void ChangeDiskbox()
        {
            if (this.IsDiskboxOpen)
                this.IsDiskboxOpen = false;
            else
                this.IsDiskboxOpen = true;
        }
        public void PlayPouse()
        {
            if (this.IsPlay)
                this.IsPlay = false;
            else
                this.IsPlay = true;
        }
    }
}