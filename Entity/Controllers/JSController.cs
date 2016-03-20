using Entity.Models;
using Entity.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace Entity.Controllers
{
    public class JSController : ApiController
    {
        private DevicesContext dbconnect = new DevicesContext();

        
        public string Put(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            filtrDevice = CreateObject(id);
            string ansver = "";

            switch (chanel)
            {
                case "switch":
                    ((Models.IState)filtrDevice[0]).Switch();
                    ansver = ((Models.IState)filtrDevice[0]).State.ToString();
                    break;
                case "mode":
                    ((Models.IMode)filtrDevice[0]).ChangeMod();
                    ansver = ((Models.IMode)filtrDevice[0]).Mode.ToString();
                    break;
                case "volumD":
                    ((Models.IVolume)filtrDevice[0]).VolumeDown();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Volume.ToString();
                    break;
                case "volumU":
                    ((Models.IVolume)filtrDevice[0]).VolumeUp();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Volume.ToString();
                    break;
                case "brigU":
                    ((Models.IBrightness)filtrDevice[0]).BrightnessUp();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Brightness.ToString();
                    break;
                case "brigD":
                    ((Models.IBrightness)filtrDevice[0]).BrightnessDown();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Brightness.ToString();
                    break;
                case "chanelU":
                    ((Models.IChanel)filtrDevice[0]).ChanelUp();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Chanel.ToString();
                    break;
                case "chanelD":
                    ((Models.IChanel)filtrDevice[0]).ChanelDown();
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).Chanel.ToString();
                    break;
                case "play":
                    ((Models.Devices.TeleVision)filtrDevice[0]).DVDcommand(chanel);
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).DVDstate(chanel).ToString();
                    break;
                case "diskbox":
                    ((Models.Devices.TeleVision)filtrDevice[0]).DVDcommand(chanel);
                    ansver = ((Models.Devices.TeleVision)filtrDevice[0]).DVDstate(chanel).ToString();
                    break;
            }
            SaveChange(id,filtrDevice);

            return ansver;
        }
       
         public void Delete(int id)
         {             
            try
            {               
                TeleVision tv = dbconnect.TeleVision.Include(p => p.DVDs).Where(p => p.Id == id).FirstOrDefault();                   
                dbconnect.TeleVision.Remove(tv);
                dbconnect.SaveChanges();                                     

               IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();               
            }
            catch
            {
                IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();                
            }        
          }



        private IDictionary<int, Models.Devices.Device> CreateObject(int id)
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            int ID = id;
                      

                    Models.Devices.TeleVision tV;
                    Models.Devices.DVD dvd = new Models.Devices.DVD("0");


                    var dev2 = dbconnect.TeleVision.Find(ID);
                    var dev = dbconnect.DVD.Find(1);

                    dvd.IsDiskboxOpen = dev.IsDiskboxOpen;
                    dvd.IsPlay = dev.IsPlay;
                    dvd.Name = dev.Name;


                    tV = new Models.Devices.TeleVision("0", dvd, Models.Addition.Chanel.ICTV);

                    tV.Name = dev2.Name;
                    tV.State = dev2.State;
                    tV.Brightness = dev2.Brightness;
                    tV.Mode = dev2.Mode;
                    tV.Volume = dev2.Volume;

                    switch (dev2.CurrentChanel)
                    {
                        case "ICTV":
                            tV.Chanel = Models.Addition.Chanel.ICTV;
                            break;
                        case "NationalGeographics":
                            tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                            break;
                        case "M1":
                            tV.Chanel = Models.Addition.Chanel.M1;
                            break;
                        case "Інтер":
                            tV.Chanel = Models.Addition.Chanel.Інтер;
                            break;
                        case "Україна":
                            tV.Chanel = Models.Addition.Chanel.Україна;
                            break;
                    }


                    filtrDevice.Add(0, tV);
            
            return filtrDevice;
        }
        private void SaveChange(int id,IDictionary<int, Models.Devices.Device> device)
           {           
                
                    TeleVision tv = dbconnect.TeleVision.Find(id);

                    tv.State = ((Models.Devices.TeleVision)device[0]).State;
                    tv.Mode = ((Models.Devices.TeleVision)device[0]).Mode;
                    tv.Volume = ((Models.Devices.TeleVision)device[0]).Volume;
                    tv.CurrentChanel = ((Models.Devices.TeleVision)device[0]).Chanel.ToString();
                    tv.Brightness = ((Models.Devices.TeleVision)device[0]).Brightness;

                    dbconnect.SaveChanges();
                               
            }        
        public IDictionary<int, Models.Devices.Device> ChouseDevice()
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

                    Models.Devices.TeleVision tV;
                    Models.Devices.DVD dvd = new Models.Devices.DVD("0");

                    var dev = dbconnect.DVD;
                    var dev2 = dbconnect.TeleVision.Include(p => p.Device).ToList();

                    foreach (var l in dev2)
                    {
                        foreach (var d in dev)
                        {
                            dvd.IsDiskboxOpen = d.IsDiskboxOpen;
                            dvd.IsPlay = d.IsPlay;
                            dvd.Name = d.Name;
                        }

                        tV = new Models.Devices.TeleVision("0", dvd, Models.Addition.Chanel.ICTV);

                        tV.Name = l.Name;
                        tV.State = l.State;
                        tV.Brightness = l.Brightness;
                        tV.Mode = l.Mode;
                        tV.Volume = l.Volume;

                        switch (l.CurrentChanel)
                        {
                            case "ICTV":
                                tV.Chanel = Models.Addition.Chanel.ICTV;
                                break;
                            case "NationalGeographics":
                                tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                                break;
                            case "M1":
                                tV.Chanel = Models.Addition.Chanel.M1;
                                break;
                            case "Інтер":
                                tV.Chanel = Models.Addition.Chanel.Інтер;
                                break;
                            case "Україна":
                                tV.Chanel = Models.Addition.Chanel.Україна;
                                break;
                        }
                        filtrDevice.Add(l.Id, tV);                        
                    }  
            return filtrDevice;
        }
    }
}
