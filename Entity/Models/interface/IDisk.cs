using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IDisk
    {
        bool IsDiskboxOpen { get; set; }
        bool IsPlay { get; set; }


        void ChangeDiskbox();
        void PlayPouse();
    }
}
