using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity.Controllers
{
    public class SmartHouseController : Controller
    {
       private int id;
       private  SelectListItem[] deviceListItem;

       private DevicesContext dbconnect = new DevicesContext();

       

        //
        // GET: /SmartHouse/
        public ActionResult Index()
        {
            IDictionary<int, Models.Devices.Device> deviceList;

            if (Session["Figures"] == null)
            {
                deviceList = new SortedDictionary<int, Models.Devices.Device>();


                deviceList.Add(0, new Models.Devices.Lamp("Лампа"));
                deviceList.Add(1, new Models.Devices.Fridge("Холодильник"));
                deviceList.Add(2, new Models.Devices.TapRecoder("Музыкальный центр"));
                deviceList.Add(3, new Models.Devices.Conditioner("Кондиционер"));
                deviceList.Add(4, new Models.Devices.TeleVision("Телевизор",new Models.Devices.DVD("dvd"),Models.Addition.Chanel.ICTV));
                deviceList.Add(5, new Models.Devices.Kettle("Чайник"));



                Session["Devices"] = deviceList;
                Session["nextID"] = 6;                
               
            }
            else
            {
                deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            }

            deviceListItem = new SelectListItem[5];
            deviceListItem[0] = new SelectListItem { Text = " ICTV", Value = " ictv", Selected = true };
            deviceListItem[1] = new SelectListItem { Text = "NationalGeographics", Value = "NG" };
            deviceListItem[2] = new SelectListItem { Text = "M1", Value = "m1" };
            deviceListItem[3] = new SelectListItem { Text = "Інтер", Value = "inter" };
            deviceListItem[4] = new SelectListItem { Text = "Україна", Value = "Ukr" };

            ViewBag.DeviceListItem = deviceListItem;
            Session["DropDown"] = deviceListItem;


            return View(deviceList);
                     
        }

        public ActionResult ChouseDevice(string id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            IDictionary<int, Models.Devices.Device> filtrDevice=new SortedDictionary<int, Models.Devices.Device>();

            
            Session["Filtr"] = id;

            foreach(var item in deviceList)
            {
                if (item.Value.Id == id)
                    filtrDevice.Add(item.Key,item.Value);
            }

            return View("Index",filtrDevice);
        }

        public ActionResult Delete(int id)
        {
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

             string filtr = Convert.ToString(Session["Filtr"]);
             deviceList.Remove(id);

             foreach (var item in deviceList)
             {
                 if (item.Value.Id == filtr)
                     filtrDevice.Add(item.Key, item.Value);
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
            IDictionary<int, Models.Devices.Device> deviceList = (SortedDictionary<int, Models.Devices.Device>)Session["Devices"];
            int ID = Convert.ToInt32(Session["nextID"]);

            switch(type)
            {
                case"cond":
                    deviceList.Add(ID, new Models.Devices.Conditioner(Namedevice)); 
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;
                case "tr":
                    deviceList.Add(ID, new Models.Devices.TapRecoder(Namedevice)); 
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;
                case "lamp":
                    deviceList.Add(ID, new Models.Devices.Lamp(Namedevice)); 
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;
                case "fridge":
                    deviceList.Add(ID, new Models.Devices.Fridge(Namedevice));
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;
                case "kettle":
                    deviceList.Add(ID, new Models.Devices.Kettle(Namedevice));  
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;
                case "tv":
                    deviceList.Add(ID, new Models.Devices.TeleVision(Namedevice, new Models.Devices.DVD(Namedevice + ID), Models.Addition.Chanel.ICTV));  
                     ID++;
                    Session["nextID"] = ID;
                    Session["Devices"] = deviceList;
                    break;


            }



            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();
            string filtr = type;
            Session["Filtr"] = filtr;

            foreach (var item in deviceList)
            {
                if (item.Value.Id == filtr)
                    filtrDevice.Add(item.Key, item.Value);
            }
            return View("Index", filtrDevice);
           
        }
                
	}
}