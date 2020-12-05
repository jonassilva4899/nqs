using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Domain.Service
{
    public interface ITimePessoaService<Tv, Te>
    {
        Task<List<Guid>> Add(Tv view);
    }
}