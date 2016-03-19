using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models
{
	public interface IState
	{
        bool State { get; set; }

        bool Switch();
    }
}