using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leega.HotSite.Controllers
{
    public class TipoCausaController : Controller
    {
        private readonly IConfiguration _configuration;

        public TipoCausaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
