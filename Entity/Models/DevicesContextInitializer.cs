using Entity.Models.Entity;
using System.Data.Entity;

namespace Entity.Models
{
    public class DevicesContextInitializer : DropCreateDatabaseIfModelChanges<DevicesContext>
    {
        protected override void Seed(DevicesContext context)
        {
            
             Device d1=new Device {Type="tv",img="~/Content/Images/MainScreen/tv.jpg"};
             Device d2=new Device {Type="lamp",img="~/Content/Images/MainScreen/lamp.jpg"};
             Device d3=new Device {Type="tr",img="~/Content/Images/MainScreen/TR.jpg"};
             Device d4=new Device {Type="kettle",img="~/Content/Images/MainScreen/kettle.jpg"};
             Device d5=new Device {Type="fridge",img="~/Content/Images/MainScreen/fridge.jpg"};
             Device d6=new Device {Type="cond",img="~/Content/Images/MainScreen/cond.jpg"};

             context.Device.Add(d1);
             context.Device.Add(d2);
             context.Device.Add(d3);
             context.Device.Add(d4);
             context.Device.Add(d5);
             context.Device.Add(d6);


             TeleVision tv = new TeleVision { Name = "Телевизор", State = false, CurrentChanel = "ICTV", Volume = 20, Brightness = 30, Mode = false, Device = d1 };
             context.TeleVision.Add(tv);

             Conditioner c = new Conditioner { Name = "Кондиционер", State = false, Programm = 2, Device = d6 };
             DVD d = new DVD {State=false, IsDiskboxOpen=false,IsPlay=false,TeleVision=tv};
             Fridge f = new Fridge { Name = "Холодильник", State = false, StateFrize = false, Programm = 1, Device = d5 };
             Kettle k = new Kettle { Name = "Чайник", State = false, Device = d4 };
             TapRecoder tr = new TapRecoder { Name = "Музыкальный центр", State = false, Mode = false, Volume = 20, Device = d3 };
             Lamp l = new Lamp { Name = "Лампа", State = false, Brightness = 20, CurrentColor = 1, Device = d2 };
                         
             context.Conditioner.Add(c);
             context.DVD.Add(d);
             context.Fridge.Add(f);
             context.Kettle.Add(k);
             context.TapeReoder.Add(tr);
             context.Lamp.Add(l);
            
             context.SaveChanges();           
        }
    }
}