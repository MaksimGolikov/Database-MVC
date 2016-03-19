using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IBrightness
    {
        int Brightness { get; set; }

        void BrightnessUp();
        void BrightnessDown();
    }
}
