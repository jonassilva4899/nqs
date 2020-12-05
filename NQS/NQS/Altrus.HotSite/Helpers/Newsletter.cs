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
    public class Newsletter : Base
    {
        public Newsletter(IConfiguration configuration, HttpContext httpContext) : base(configuration, httpContext)
        {
        }

        public async Task<bool> Create(Leega.Dtos.Newsletter model)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Leega.Dtos.Newsletter)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/newsletter/create", content);

            return httpResponse.IsSuccessStatusCode;

        }
    }
}
