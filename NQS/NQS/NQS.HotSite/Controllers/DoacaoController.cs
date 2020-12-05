using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leega.HotSite.Controllers
{
    [Authorize]
    public class DoacaoController : Controller
    {
        private HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public DoacaoController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);
        }

        public async Task<IActionResult> Index()
        {
            List<Dtos.Doacao> model = await new Helpers.Doacao(_configuration, HttpContext).ListarPorUsuario();

            return View(model);
        }
        [HttpGet]
        public async Task<List<Dtos.Doacao>> List()
        {
            List<Dtos.Doacao> model = await new Helpers.Doacao(_configuration, HttpContext).ListarPorUsuario();

            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao doacao;

            if (basket != null)
            {
                doacao = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));

                Nullable<Guid> doacaoid = await new Helpers.Doacao(_configuration, HttpContext).Create(doacao);

                if (doacaoid != null)
                {
                    HttpContext.Session.Remove("AltrusBasket");

                    return RedirectToAction("index", "pagamento", new { doacaoid = doacaoid });
                }
            }

            return RedirectToAction("index", "basket");
        }
    }
}
