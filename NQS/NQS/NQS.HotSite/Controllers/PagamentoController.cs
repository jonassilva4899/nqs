using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leega.HotSite.Controllers
{
    [Authorize]
    public class PagamentoController : Controller
    {
        private HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public PagamentoController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);
        }

        public IActionResult Index(Guid doacaoid)
        {
            string token = HttpContext.User.Claims.Where(c => c.Type == "token").Select(c => c.Value).FirstOrDefault();
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Dtos.Doacao doacao = new Dtos.Doacao();

            // Obter doação
            StringContent content = new StringContent(JsonSerializer.Serialize(doacaoid), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = apiClient.PostAsync("/doacao/get", content).Result;
            doacao = (Dtos.Doacao)JsonSerializer.Deserialize(httpResponse.Content.ReadAsStringAsync().Result, typeof(Dtos.Doacao));

            Dtos.DoacaoPagamento model = new Dtos.DoacaoPagamento()
            {
                doacao = doacao
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Dtos.DoacaoPagamento model)
        {
            string token = HttpContext.User.Claims.Where(c => c.Type == "token").Select(c => c.Value).FirstOrDefault();
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string rqcontent = JsonSerializer.Serialize(model, typeof(Dtos.DoacaoPagamento));

            StringContent content = new StringContent(rqcontent, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/pagamento/create", content).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                model.result.Success = true;
            }
            else
            {
                model.result.Success = true;
                ModelState.AddModelError(string.Empty, "Houve um problema durante o processo. Revise seus dados e tente novamente.");
            }

            return View(model);
        }
    }
}
