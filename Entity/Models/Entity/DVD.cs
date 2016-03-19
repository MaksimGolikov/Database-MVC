using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Entity
{
    public class DVD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public bool IsDiskboxOpen { get; set; }
        public bool IsPlay { get; set; }
        public int? TeleVisionId { get; set; }

        public virtual TeleVision TeleVision { get; set; }
    }
}