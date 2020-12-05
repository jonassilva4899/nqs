using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Leega.HotSite.Helpers
{
    public class Base
    {
        public HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public Base(IConfiguration configuration, HttpContext httpContext)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);

            string token = httpContext.User.Claims.Where(c => c.Type == "token").Select(c => c.Value).FirstOrDefault();
            if (token != null)
            {
                apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
