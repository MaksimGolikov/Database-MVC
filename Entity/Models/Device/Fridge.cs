using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class Fridge:Device,IState,IFrize,IProgramm
    {


        public Fridge(string name)
        {
            this.Name = name;
            this.Id = "fridge";
            this.State = false;
            this.StateFrize = false;
            this.Programm = 1;
        }

        public bool State { get; set; }
        public bool StateFrize { get; set; }
        public int Programm { get; set; }


        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }

        public bool SwitchFrize()
        {
            if (StateFrize)
                StateFrize = false;
            else
                StateFrize = true;

            return StateFrize;
        }

        public void ProgrammUp()
        {
            if (Programm < 5)
                Programm++;
        }
        public void ProgrammDown()
        {
            if (Programm > 1)
                Programm--;
        }

        public string ProgrammState()
        {
            return Convert.ToString(Programm);
        }
    }
}