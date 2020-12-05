using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Leega.HotSite.Helpers
{
    public class Estados : Base
    {
        public Estados(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }

        public async Task<List<Dtos.Estados>> List()
        {
            HttpResponseMessage httpResponse = await apiClient.GetAsync("/estados/list");

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Dtos.Estados> model = JsonSerializer.Deserialize<List<Dtos.Estados>>(content, new JsonSerializerOptions() { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return model;
        }
    }
}
