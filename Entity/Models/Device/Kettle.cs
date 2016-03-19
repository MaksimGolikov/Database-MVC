using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class Kettle:Device,IState
    {

        public Kettle (string name)
        {
            this.Id = "kettle";

            this.Name=name;
            this.State = false;
        }


        public bool State { get; set; }

        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }
                
    }
}