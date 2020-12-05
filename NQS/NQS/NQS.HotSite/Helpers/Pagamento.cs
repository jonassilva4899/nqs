using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.HotSite.Helpers
{
    public class Pagamento : Base
    {
        public Pagamento(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }
    }
}
