using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.HotSite.Models
{
    public class Pessoa : Dtos.Pessoa
    {
        public string returnUrl { get; set; }
    }
}
