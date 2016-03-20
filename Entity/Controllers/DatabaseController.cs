using Entity.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entity.Models;


namespace Entity.Controllers
{
    public class DatabaseController : Controller
    {
        private DevicesContext dbconnect = new DevicesContext();
        //
        // GET: /Database/
        public ActionResult Index()
        {

            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            return View(filtrDevice);
        }

        public ActionResult ChouseDevice(string id)
        {           
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
                           
            switch(id)
            {
                case"lamp":

                    Models.Devices.Lamp lamp;
                    
                      var dev1 = dbconnect.Lamp.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev1)
                      {
                          lamp = new Models.Devices.Lamp("0");

                          lamp.Name = l.Name;
                          lamp.Brightness = l.Brightness;
                          lamp.State = l.State;
                          lamp.currentcolor = l.CurrentColor;

                          filtrDevice.Add(l.Id,lamp);                         
                      }


                    break;
                case "tv":

                     Models.Devices.TeleVision tV;
                     Models.Devices.DVD dvd = new Models.Devices.DVD("0");

                      var dev = dbconnect.DVD;
                      var dev2 = dbconnect.TeleVision.Include(p=>p.Device).ToList();    
                            
                      foreach(var l in dev2)
                      {
                          foreach(var d in dev)
                          {                             
                              dvd.IsDiskboxOpen = d.IsDiskboxOpen;
                              dvd.IsPlay = d.IsPlay;
                              dvd.Name = d.Name;
                          }

                          tV = new Models.Devices.TeleVision("0",dvd,Models.Addition.Chanel.ICTV);

                          tV.Name = l.Name;
                          tV.State = l.State;
                          tV.Brightness = l.Brightness;
                          tV.Mode = l.Mode;
                          tV.Volume = l.Volume;

                            switch(l.CurrentChanel)
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

                          filtrDevice.Add(l.Id,tV);                          
                      }

                    break;
                case "tr":

                    Models.Devices.TapRecoder TRec;
                    
                      var dev3 = dbconnect.TapeReoder.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev3)
                      {
                          TRec = new Models.Devices.TapRecoder("0");

                          TRec.Name = l.Name;
                          TRec.State = l.State;
                          TRec.Mode = l.Mode;
                          TRec.Volume = l.Volume;

                          filtrDevice.Add(l.Id,TRec);                          
                      }

                    break;
                case "kettle":

                   Models.Devices.Kettle ket;
                    
                      var dev4 = dbconnect.Kettle.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev4)
                      {
                          ket = new Models.Devices.Kettle("0");

                          ket.Name = l.Name;
                          ket.State = l.State;

                          filtrDevice.Add(l.Id, ket);                         
                      }

                    break;
                case "fridge":

                    Models.Devices.Fridge fridge;
                    
                      var dev5 = dbconnect.Fridge.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev5)
                      {
                          fridge = new Models.Devices.Fridge("0");

                          fridge.Name = l.Name;
                          fridge.State = l.State;
                          fridge.StateFrize = l.StateFrize;
                          fridge.Programm = l.Programm;
                          
                          filtrDevice.Add(l.Id, fridge);
                         
                      }

                    break;
                case "cond":

                   Models.Devices.Conditioner conde;
                    
                      var dev6 = dbconnect.Conditioner.Include(p=>p.Device).ToList();                                
                      foreach(var l in dev6)
                      {
                          conde = new Models.Devices.Conditioner("0");

                          conde.Name = l.Name;
                          conde.State = l.State;
                          conde.Programm = l.Programm;

                          filtrDevice.Add(l.Id, conde);                         
                      }

                    break;
            }
           
            return View("Index",filtrDevice);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("~/Views/AddDevice.cshtml");
        }
        [HttpPost]
        public ActionResult Add(string type, string Namedevice)
        {           
            
            switch (type)
            {
                case "cond":

                    Device d = new Device { Type = "cond", img = "~/Content/Images/MainScreen/cond.jpg" };
                    Conditioner c = new Conditioner { Name = Namedevice, State = false, Programm = 2, Device = d};  
                    

                    Session["Filtr"] = type;  
                    dbconnect.Conditioner.Add(c);
                    dbconnect.SaveChanges();
                    

                    break;
                case "tr":

                    Device d1 = new Device { Type = "tr", img = "~/Content/Images/MainScreen/TR.jpg" };
                    TapRecoder tr = new TapRecoder { Name = Namedevice, State = false, Mode = false, Volume = 20, Device = d1 };                    

                    Session["Filtr"] = type;  
                    dbconnect.TapeReoder.Add(tr);
                    dbconnect.SaveChanges();
                    break;
                case "lamp":

                    Device d2 = new Device { Type = "lamp", img = "~/Content/Images/MainScreen/lamp.jpg" };
                    Lamp l = new Lamp { Name = Namedevice, State = false, Brightness = 20, CurrentColor = 1, Device = d2 };            

                    Session["Filtr"] = type;  
                    dbconnect.Lamp.Add(l);
                    dbconnect.SaveChanges();

                    break;
                case "fridge":

                    Device d3 = new Device { Type = "fridge", img = "~/Content/Images/MainScreen/fridge.jpg" };
                    Fridge f = new Fridge { Name = Namedevice, State = false, StateFrize = false, Programm = 1, Device = d3 };         

                    Session["Filtr"] = type;  
                    dbconnect.Fridge.Add(f);
                    dbconnect.SaveChanges();

                    break;
                case "kettle":

                    Device d4 = new Device { Type = "kettle", img = "~/Content/Images/MainScreen/kettle.jpg" };
                    Kettle k = new Kettle { Name = Namedevice, State = false, Device = d4 };         

                    Session["Filtr"] = type;  
                    dbconnect.Kettle.Add(k);
                    dbconnect.SaveChanges();

                    break;
                case "tv":

                     Device d5 = new Device { Type = "tv", img = "~/Content/Images/MainScreen/tv.jpg" };
                     TeleVision tv = new TeleVision { Name = Namedevice, State = false, CurrentChanel = "ICTV",
                                                      Volume = 20, Brightness = 30, Mode = false, Device = d5 };
                     DVD dvd = new DVD { State = false, IsDiskboxOpen = false, IsPlay = false, TeleVision = tv };

                    Session["Filtr"] = type;  
                    dbconnect.TeleVision.Add(tv);
                    dbconnect.DVD.Add(dvd);
                    dbconnect.SaveChanges();

                    break;


            }



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            return View("Index", filtrDevice);

        }


       
       
        public ActionResult Delete(int id, string chanel)
        {
            IDictionary<int, string> del=new SortedDictionary<int, string>();
            del.Add(id,chanel);
            return View(del);
        }        
        public ActionResult Del(int id, string chanel)
        {
            try
            {
               switch(chanel)
               {
                   case "cond":

                       Conditioner c = dbconnect.Conditioner.Find(id);

                       dbconnect.Conditioner.Remove(c);                      
                       dbconnect.SaveChanges();

                       break;
                   case "tr":

                       TapRecoder tr = dbconnect.TapeReoder.Find(id);
                       dbconnect.TapeReoder.Remove(tr);                      
                       dbconnect.SaveChanges();
                       break;
                   case "lamp":

                       Lamp l = dbconnect.Lamp.Find(id);
                       dbconnect.Lamp.Remove(l);
                       dbconnect.SaveChanges();

                       break;
                   case "fridge":

                       Fridge f = dbconnect.Fridge.Find(id);
                       dbconnect.Fridge.Remove(f);
                       dbconnect.SaveChanges();

                       break;
                   case "kettle":

                       Kettle k = dbconnect.Kettle.Find(id);
                       dbconnect.Kettle.Remove(k);
                       dbconnect.SaveChanges();

                       break;
                   case "tv":

                      
                       TeleVision tv = dbconnect.TeleVision.Include(p => p.DVDs).Where(p => p.Id == id).FirstOrDefault();                   
                      dbconnect.TeleVision.Remove(tv);
                      dbconnect.SaveChanges();

                       break;
               }

               IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
               return View("Index", filtrDevice);
            }
            catch
            {
                IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
                return View("Index", filtrDevice);
            }
        }

        public ActionResult ToWebApi()
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
             
                     Models.Devices.TeleVision tV;
                     Models.Devices.DVD dvd = new Models.Devices.DVD("0");

                      var dev = dbconnect.DVD;
                      var dev2 = dbconnect.TeleVision.Include(p=>p.Device).ToList();    
                            
                      foreach(var l in dev2)
                      {
                          foreach(var d in dev)
                          {                             
                              dvd.IsDiskboxOpen = d.IsDiskboxOpen;
                              dvd.IsPlay = d.IsPlay;
                              dvd.Name = d.Name;
                          }

                          tV = new Models.Devices.TeleVision("0",dvd,Models.Addition.Chanel.ICTV);

                          tV.Name = l.Name;
                          tV.State = l.State;
                          tV.Brightness = l.Brightness;
                          tV.Mode = l.Mode;
                          tV.Volume = l.Volume;

                            switch(l.CurrentChanel)
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


                          filtrDevice.Add(l.Id,tV);                          
                      }
                      return View("~/Views/JS/JS.cshtml", filtrDevice);

        }
    }
}
