using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class Lamp:Device,IState,IBrightness,IColor
    {

        private System.Drawing.Color colorLight;
        private List<System.Drawing.Color> colors;
        public int currentcolor;

        public Lamp(string name)
        {
            this.Name = name;
            this.Id = "lamp";
            this.State = false;
            currentcolor = 0;
        }

        public bool State { get; set; }
        public int Brightness { get; set; }


        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }

        public void BrightnessUp()
        {
            if (this.Brightness < 100)
                this.Brightness += 10;
        }
        public void BrightnessDown()
        {
            if (this.Brightness >10)
                this.Brightness -= 10;
        }

        public void SelectColor(string idColor)
        {
            colors = new List<System.Drawing.Color>();
            colors.Add(System.Drawing.Color.White);
            colors.Add(System.Drawing.Color.Orange);
            colors.Add(System.Drawing.Color.Blue);
            colors.Add(System.Drawing.Color.Red);
            colors.Add(System.Drawing.Color.Yellow);


            switch (idColor)
            {
                case "up":
                    if (currentcolor < colors.Count-1)
                        currentcolor++;
                    break;

                case "down":
                    if (currentcolor>0)
                        currentcolor--;
                    break;
                                  
            }


            colorLight=colors[currentcolor];
        }
        
        

        public string ReturnColor()
        {

            colors = new List<System.Drawing.Color>();
            colors.Add(System.Drawing.Color.White);
            colors.Add(System.Drawing.Color.Orange);
            colors.Add(System.Drawing.Color.Blue);
            colors.Add(System.Drawing.Color.Red);
            colors.Add(System.Drawing.Color.Yellow);

            colorLight = colors[currentcolor];
            return this.colorLight.Name;
        }

        
    }
}