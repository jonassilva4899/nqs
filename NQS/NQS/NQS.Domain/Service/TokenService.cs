using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Domain.Service
{
    public class TokenService
    {
        public async Task<DateTime> CalculaExpiracao()
        {
            return DateTime.Now.AddHours(48);
        }

        public async Task<string> GerarToken()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
