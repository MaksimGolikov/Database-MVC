using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Entity
{
    public class TeleVision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string CurrentChanel { get; set; }
        public int Volume { get; set; }
        public int Brightness { get; set; }
        public bool Mode { get; set; }
        public int? DeviceId { get; set; }

        public virtual ICollection<DVD> DVDs { get; set; }
        public virtual Device Device { get; set; }
       
    }
}