using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Leega.UI.Helpers
{
    public class Causas : Base
    {
        public Causas(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }

        public async Task<List<Leega.Dtos.Campanha>> Carrosel()
        {
            HttpResponseMessage httpResponse = await apiClient.GetAsync("/campanha/carrosel");

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.Campanha> model = JsonSerializer.Deserialize<List<Leega.Dtos.Campanha>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }

        public async Task<List<Leega.Dtos.Campanha>> List()
        {
            HttpResponseMessage httpResponse = await apiClient.GetAsync("/campanha/list");

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.Campanha> model = JsonSerializer.Deserialize<List<Leega.Dtos.Campanha>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }
        public async Task<List<Leega.Dtos.Campanha>> ObterPor(Leega.Dtos.FiltroCampanha filtro)
        {
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(filtro, typeof(Leega.Dtos.FiltroCampanha)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/campanha/list", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.Campanha> model = System.Text.Json.JsonSerializer.Deserialize<List<Leega.Dtos.Campanha>>(result, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }
    }
}
