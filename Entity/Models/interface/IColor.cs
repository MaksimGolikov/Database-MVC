using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public interface IColor
    {
        void SelectColor(string idColor);
        string ReturnColor();
    }
}
