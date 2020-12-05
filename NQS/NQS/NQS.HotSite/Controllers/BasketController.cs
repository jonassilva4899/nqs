using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leega.HotSite.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao model = new Dtos.Doacao();

            if (basket != null)
            {
                model = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Get()
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao result = new Dtos.Doacao();

            if (basket != null)
            {
                result = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Dtos.DoacaoCampanha model)
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao doacao = new Dtos.Doacao();
            doacao.recorrencia = 1;

            if (basket != null)
            {
                doacao = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));
            }

            if (doacao.campanhas.Where(i => i.campanhaid == model.campanhaid).SingleOrDefault() == null)
            {
                model.campanha = new Dtos.Campanha()
                {
                    id = model.campanhaid,
                    valorminimo = model.valor
                };
                doacao.campanhas.Add(model);
            }

            doacao.valor = doacao.campanhas.Select(i => i.valor).Sum();

            string content = JsonSerializer.Serialize(doacao, typeof(Dtos.Doacao));

            HttpContext.Session.SetString("AltrusBasket", content);

            return Ok();
        }

        [HttpPost]
        public IActionResult Change(int campanhaid, double valor)
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao doacao = new Dtos.Doacao();

            if (basket != null)
            {
                doacao = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));
            }

            var campanha = doacao.campanhas.FindIndex(i => i.campanhaid == campanhaid);

            if (campanha > -1)
            {
                doacao.campanhas[campanha].valor = valor;
            }

            doacao.valor = doacao.campanhas.Select(i => i.valor).Sum();

            string content = JsonSerializer.Serialize(doacao, typeof(Dtos.Doacao));

            HttpContext.Session.SetString("AltrusBasket", content);

            return Ok();
        }

        [HttpPost]
        public IActionResult SetRecurrence(int recurrence)
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao doacao = new Dtos.Doacao();

            if (basket != null)
            {
                doacao = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));
                doacao.recorrencia = recurrence;
            }

            string content = JsonSerializer.Serialize(doacao, typeof(Dtos.Doacao));

            HttpContext.Session.SetString("AltrusBasket", content);

            return Ok();
        }

        [HttpPost]
        public IActionResult Update(Dtos.DoacaoCampanha model)
        {
            Remove(model.campanhaid);
            Add(model);

            return Ok();
        }

        [HttpPost]
        public IActionResult Remove(int campanhaid)
        {
            var basket = HttpContext.Session.GetString("AltrusBasket");
            Dtos.Doacao doacao = new Dtos.Doacao();

            if (basket != null)
            {
                doacao = (Dtos.Doacao)JsonSerializer.Deserialize(basket, typeof(Dtos.Doacao));

                var campanha = doacao.campanhas.Where(i => i.campanhaid == campanhaid).SingleOrDefault();
                if (campanha != null)
                {
                    doacao.campanhas.Remove(campanha);
                }
            }

            doacao.valor = doacao.campanhas.Select(i => i.valor).Sum();

            string content = JsonSerializer.Serialize(doacao, typeof(Dtos.Doacao));

            HttpContext.Session.SetString("AltrusBasket", content);

            return Ok();
        }

        [HttpPost]
        public IActionResult Clean()
        {
            HttpContext.Session.Remove("AltrusBasket");
            return Ok();
        }
    }
}
