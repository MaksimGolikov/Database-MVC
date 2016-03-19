using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Entity
{
    public class Kettle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int? DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}