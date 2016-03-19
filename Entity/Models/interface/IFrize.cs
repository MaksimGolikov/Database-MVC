using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IFrize
    {
        bool StateFrize { get; set; }

        bool SwitchFrize();        
    }
}
