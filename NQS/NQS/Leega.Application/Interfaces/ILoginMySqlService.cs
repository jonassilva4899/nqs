using Leega.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leega.Application.Interfaces
{
    public interface ILoginMySqlService
    {
        Task<UsuarioLogadoMySqlViewModel> AutenticaComGoogle(UsuarioSocialMySqlViewModel login);
        Task<UsuarioLogadoMySqlViewModel> Autentica(LoginMySql login);
    }
}
