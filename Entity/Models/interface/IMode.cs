using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models
{
	public interface IMode
	{
        bool Mode { get; set; }
        void ChangeMod();
        string StateMode();
	}
}