using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Leega.HotSite.Helpers
{
    public class Doacao : Base
    {
        public Doacao(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }
        public async Task<Guid?> Create(Dtos.Doacao doacao)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(doacao, typeof(Dtos.Doacao)), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await apiClient.PostAsync("/doacao/create", content);

            if (httpResponse.IsSuccessStatusCode)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();

                Guid doacaoid = (Guid)JsonSerializer.Deserialize(result, typeof(Guid));

                return doacaoid;
            }

            return null;
        }
        public async Task<List<Dtos.Doacao>> ListarPorUsuario()
        {
            HttpResponseMessage httpResponse = await apiClient.PostAsync("/doacao/listarporusuario", null);

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Dtos.Doacao> model = JsonSerializer.Deserialize<List<Dtos.Doacao>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }

        public async Task<List<Dtos.Campanha>> ListarCampanhas()
        {
            HttpResponseMessage httpResponse = await apiClient.PostAsync("/doacao/listarcampanhas", null);

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Dtos.Campanha> model = JsonSerializer.Deserialize<List<Dtos.Campanha>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }
        public async Task<dynamic> ObterTotalDoacoes(Dtos.FiltroDoacao filtro)
        {
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(filtro, typeof(Dtos.FiltroDoacao)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/doacao/obtertotaldoacoes", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            object model = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            return model;
        }
    }
}
