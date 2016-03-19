using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class Conditioner:Device,IProgramm,IState
    {
        public Conditioner(string name)
        {
            this.Name = name;
            this.Id = "cond";
            this.State = false;
            this.Programm = 1;
        }

        public bool State { get; set; }
        public int Programm { get; set; }


        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }


        public void ProgrammUp()
        {
            if (Programm < 3)
                Programm++;
        }
        public void ProgrammDown()
        {
            if (Programm > 1)
                Programm--;
        }

        public string ProgrammState()
        {
            string program="";

            switch(Programm)
            {
                case 1:
                    program = "охлаждение";
                    break;                    
                case 2:
                    program = "проветривание";
                    break;
                case 3:
                    program = "нагрев";
                    break;
            }
             return program;
        }
    }
}