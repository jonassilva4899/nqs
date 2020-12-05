using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Leega.UI.Helpers
{
    public class TipoCausa : Base
    {
        public TipoCausa(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }
        public async Task<List<Leega.Dtos.TipoCausa>> List()
        {
            HttpResponseMessage httpResponse = await apiClient.PostAsync("/tipocausa/list", null);

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.TipoCausa> model = JsonSerializer.Deserialize<List<Leega.Dtos.TipoCausa>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }

        public async Task<List<Leega.Dtos.TipoCausa>> List(List<int> tipocausa)
        {
            HttpResponseMessage httpResponse = await apiClient.PostAsync("/tipocausa/list", null);

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Leega.Dtos.TipoCausa> model = JsonSerializer.Deserialize<List<Leega.Dtos.TipoCausa>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }

    }
}
