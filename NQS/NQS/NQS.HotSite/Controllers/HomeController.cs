using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Leega.HotSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leega.HotSite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //    HttpContext.Session.Remove("companyid");

            //    List<Dtos.Campanha> model = await new Helpers.Causas(_configuration, HttpContext).Carrosel();

            //    model = model.OrderBy(x => Guid.NewGuid()).ToList();

            //    return View(model);

            return View();
        }

        [AllowAnonymous]
        public IActionResult Sobre()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Causas()
        {
            Models.Causa model = new Causa();

            List<Dtos.Campanha> campanhas = await new Helpers.Causas(_configuration, HttpContext).List();

            model.campanhas = campanhas.OrderBy(x => Guid.NewGuid()).ToList();

            List<Dtos.TipoCausa> tiposcausa = await new Helpers.TipoCausa(_configuration, HttpContext).List();

            model.tiposcausa = tiposcausa.Select(item => new Models.TipoCausa()
            {
                descricao = item.descricao,
                id = item.id,
                imagem = item.imagem
            }).ToList();

            List<Dtos.Estados> estados = await new Helpers.Estados(_configuration, HttpContext).List();

            model.estado = estados.Select(item => new Models.Estados()
            {
                ddd = item.ddd,
                uf = item.uf,
                ibge = item.ibge,
                id = item.id,
                nome = item.nome,
                sl = item.sl
            }).ToList();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Causas(Models.Causa model)
        {
            Dtos.FiltroCampanha filtro = new Dtos.FiltroCampanha()
            {
                nome = model.campanha,
                tipo = model.tiposcausa.Where(t => t.selecionado).Select(t => t.id).ToList(),
                uf = model.estado.Where(t => t.selecionado).Select(t => t.uf).ToList()
            };

            List<Dtos.Campanha> campanhas = await new Helpers.Causas(_configuration, HttpContext).ObterPor(filtro);
            model.campanhas = campanhas;
            return View(model);
        }
        public async Task<IActionResult> Dashboard()
        {
            List<Dtos.Campanha> model = await new Helpers.Causas(_configuration, HttpContext).Carrosel();

            model = model.OrderBy(x => Guid.NewGuid()).ToList();

            return View(model);
        }




        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogInterna()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Faq()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Consultoria()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult HealtTech()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Cursos()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Contato(string mensagem)
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult WhiteLabel()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NewsLetter()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> NewsLetter(Dtos.Newsletter model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            model.result.Success = await new Helpers.Newsletter(_configuration, HttpContext).Create(model);

            if (model.result.Success)
            {
                return Ok(model);
            }

            return BadRequest();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Transparencia()
        {
            Models.Tranparencia model = new Tranparencia();

            Dtos.FiltroDoacao filtro = new Dtos.FiltroDoacao();
            List<Dtos.Campanha> campanhas = await new Helpers.Doacao(_configuration, HttpContext).ListarCampanhas();

            model.campanhas = campanhas.Select(c => new Campanha { id = c.id, nome = c.nome }).ToList();
            model.ongs = campanhas.Select(c => new Ong { id = c.ong.id, razaosocial = c.ong.razaosocial }).ToList();

            model.totais = await new Helpers.Doacao(_configuration, HttpContext).ObterTotalDoacoes(filtro);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Transparencia(Models.Tranparencia model)
        {
            Dtos.FiltroDoacao filtro = new Dtos.FiltroDoacao();
            filtro.campanhaid = model.campanhas.Where(c => c.selecionado).Select(c => c.id).ToList();
            filtro.ongid = model.ongs.Where(c => c.selecionado).Select(c => c.id).ToList();

            model.totais = await new Helpers.Doacao(_configuration, HttpContext).ObterTotalDoacoes(filtro);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
