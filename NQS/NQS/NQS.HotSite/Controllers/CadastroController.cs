using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leega.HotSite.Controllers
{
    public class CadastroController : Controller
    {
        private HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public CadastroController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);
        }
        public IActionResult Altruista()
        {
            ViewBag.State = false;
            return View();
        }
        [HttpPost]
        public IActionResult Altruista(Dtos.Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Dtos.Pessoa)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/pessoa/create", content).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                ViewBag.State = true;
            }

            return View(model);
        }
        public IActionResult Embaixador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Embaixador(Dtos.Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Dtos.Pessoa)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/pessoa/create", content).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest();
        }

        public IActionResult Empresa()
        {
            return View();
        }
    }
}
