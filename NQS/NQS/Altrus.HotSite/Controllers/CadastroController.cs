using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Leega.Dtos;



namespace Leega.UI.Controllers
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
       
        

        //[HttpPost]
        //public IActionResult Embaixador(Leega.Dtos.Pessoa model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Pessoa)), Encoding.UTF8, "application/json");

        //    HttpResponseMessage httpResponse = apiClient.PostAsync("/pessoa/create", content).Result;

        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        public IActionResult Empresa()
        {
            return View();
        }

        public IActionResult Paciente()
        {
            ViewBag.State = false;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PacienteEditar(Guid id)
        {

            HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/Obter/"+ id);

            var content = await httpResponse.Content.ReadAsStringAsync();

            Leega.Dtos.Paciente model = JsonSerializer.Deserialize<Leega.Dtos.Paciente>(content, new JsonSerializerOptions() { IgnoreNullValues = false, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


            ViewBag.State = false;
            return View(model);
        }

        [HttpGet("RetornaListaPacienteGrid")]
        private async Task<JsonResult> RetornaListaPacienteGrid()
        {
            //int maxRows = 5;

            HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");

            var content = await httpResponse.Content.ReadAsStringAsync();
            List<Leega.Dtos.Paciente> model = JsonSerializer.Deserialize<List<Leega.Dtos.Paciente>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            
            
            return Json(new { data = model });
        }

        public async Task<IActionResult> PacienteLista()
        {
            HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");            
            //List<EquipamentoMySql> clienteMySqls = _equipamentoMySqlRepository.ListarTodos().ToList();


            var result = await httpResponse.Content.ReadAsStringAsync();
            List<Leega.Dtos.Paciente> model = System.Text.Json.JsonSerializer.Deserialize<List<Leega.Dtos.Paciente>>(result, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


            return View(model);
        }

        private async Task<Leega.Dtos.ListaPacientes> RetornaListaPaciente(int currentPage)
        {
            int maxRows = 5;

            HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");

            var content = await httpResponse.Content.ReadAsStringAsync();
            List<Leega.Dtos.Paciente> model = JsonSerializer.Deserialize<List<Leega.Dtos.Paciente>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            double pageCount = (double)((decimal)model.Count() / Convert.ToDecimal(maxRows));

            model = model.OrderBy(paciente => paciente.NomeCompleto)
                .Skip(maxRows * (currentPage - 1))
                .Take(maxRows).ToList();
                //.Skip((currentPage - 1) * maxRows)
                  //  .Take(maxRows).ToList();


            Leega.Dtos.ListaPacientes lista = new Leega.Dtos.ListaPacientes();

            lista.Paciente= model;
            lista.CurrentPageIndex = currentPage;
            lista.PageCount = (int)Math.Ceiling(pageCount);

            return lista;
        }
        [HttpGet]

        //public async Task<IActionResult> PacienteLista()
        //{

        //    //HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");

        //    //var content = await httpResponse.Content.ReadAsStringAsync();

        //    //List<Leega.Dtos.Paciente> model = JsonSerializer.Deserialize<List<Leega.Dtos.Paciente>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        //    var model = await RetornaListaPaciente(1);

        //    ViewBag.State = false;
        //    return View(model);
        //}

        //[HttpGet("PacienteLista/{currentPage}")]
        //public async Task<IActionResult> PacienteLista(int currentPage)
        //{

        //    /*var model = await RetornaListaPaciente(currentPage);*/

        //    ViewBag.State = false;
        //    //return View(model);
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Paciente(Leega.Dtos.Paciente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Id = Guid.NewGuid().ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Paciente)), Encoding.UTF8, "application/json");


            //RestClient restClient = new RestClient("https://localhost:44391");
            //RestRequest request = new RestRequest("Paciente/Adicionar", Method.POST);
            

            ////request.AddParameter("application/json", model, ParameterType.RequestBody);


            ////request.AddParameter("application/json", content, ParameterType.RequestBody);
            //var response = await restClient.ExecuteAsync(request);
            //var content1 = response.Content;


            HttpResponseMessage httpResponse = await apiClient.PostAsync("Paciente/Adicionar", content);
            ViewBag.State = false;
            //return View();

            return RedirectToAction("PacienteEditar", "Cadastro", new { id = model.Id});
        }

        [HttpPost]
        public async Task<IActionResult> PacienteEditar(Leega.Dtos.Paciente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //model.Id = Guid.NewGuid().ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Paciente)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PutAsync("Paciente/Atualizar", content);
            ViewBag.State = false;
                
            return View();

            //return RedirectToAction("PacienteEditar", "Cadastro", new { id = model.Id });
        }
    }
}
