using Leega.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.Interfaces
{
    public interface IPessoaMySqlService
    {
        void Adicionar(PessoaMySqlViewModel obj, string idOrganizacao);
    }
}
