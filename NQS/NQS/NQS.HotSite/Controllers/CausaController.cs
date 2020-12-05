using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Leega.HotSite.Controllers
{
    public class CausaController : Controller
    {
        private HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public CausaController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);
        }

        [Route("[controller]/[action]/{id}")]
        public IActionResult Detalhe(int id)
        {
            StringContent content = new StringContent(id.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/campanha/detail", content).Result;

            var result = httpResponse.Content.ReadAsStringAsync().Result;

            Dtos.Campanha model = new Dtos.Campanha();

            if (httpResponse.IsSuccessStatusCode)
            {
                model = (Dtos.Campanha)System.Text.Json.JsonSerializer.Deserialize(result, typeof(Dtos.Campanha));

                var qrcode = Util.QRCode.GenerateQRCode(string.Format("{0}://{1}/causa/{2}", HttpContext.Request.Scheme, HttpContext.Request.Host, model.url));

                ViewBag.QRCode = Util.QRCode.ImageToByte2(qrcode);
            }

            return View(model);
        }

        [Route("[controller]/{url}")]
        public IActionResult Detalhe(string url)
        {
            StringContent content = new StringContent(url, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync(string.Format("/campanha/detail/{0}", url), null).Result;

            var result = httpResponse.Content.ReadAsStringAsync().Result;

            Dtos.Campanha model = new Dtos.Campanha();

            if (httpResponse.IsSuccessStatusCode)
            {
                model = (Dtos.Campanha)System.Text.Json.JsonSerializer.Deserialize(result, typeof(Dtos.Campanha));
 
                var qrcode = Util.QRCode.GenerateQRCode(string.Format("{0}://{1}/causa/{2}", HttpContext.Request.Scheme, HttpContext.Request.Host, model.url));

                ViewBag.QRCode = Util.QRCode.ImageToByte2(qrcode);
            }

            return View(model);
        }
    }
}
