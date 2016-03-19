using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IChanel
    {
        Addition.Chanel Chanel { get; set; }

        void ChanelUp();
        void ChanelDown();
        void ChuseChanel(string chanel);

    }
}
