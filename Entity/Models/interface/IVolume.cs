using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IVolume
    {
        int Volume { get; set; }

        void VolumeUp();
        void VolumeDown();
    }
}
