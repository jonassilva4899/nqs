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
        public IActionResult Altruista()
        {
            ViewBag.State = false;
            return View();
        }
        [HttpPost]
        public IActionResult Altruista(Leega.Dtos.Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Pessoa)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/pessoa/create", content).Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                ViewBag.State = true;
            }

            return View(model);
        }
        

        [HttpPost]
        public IActionResult Embaixador(Leega.Dtos.Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Pessoa)), Encoding.UTF8, "application/json");

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

        public async Task<IActionResult> PacienteListaAsync()
        {

            //Models.Paciente model = new Models.Paciente();

            //HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");



            HttpResponseMessage httpResponse = await apiClient.GetAsync("/paciente/ListarPacientes");

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.Paciente> model = JsonSerializer.Deserialize<List<Leega.Dtos.Paciente>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


            //List<Leega.Dtos.Estados> model = JsonSerializer.Deserialize<List<Leega.Dtos.Estados>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            ViewBag.State = false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Paciente(Leega.Dtos.Paciente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Paciente)), Encoding.UTF8, "application/json");


            //RestClient restClient = new RestClient("https://localhost:44391");
            //RestRequest request = new RestRequest("Paciente/Adicionar", Method.POST);
            

            ////request.AddParameter("application/json", model, ParameterType.RequestBody);


            ////request.AddParameter("application/json", content, ParameterType.RequestBody);
            //var response = await restClient.ExecuteAsync(request);
            //var content1 = response.Content;


            HttpResponseMessage httpResponse = await apiClient.PostAsync("Paciente/Adicionar", content);
            ViewBag.State = false;
            return View();
        }
    }
}
