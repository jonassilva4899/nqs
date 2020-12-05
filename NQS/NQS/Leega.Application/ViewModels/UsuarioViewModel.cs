using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class UsuarioViewModel : BaseMySqlViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool ContaGoogle { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }

        public virtual ICollection<NotificacaoUsuarioMySqlViewModel> NotificacaoUsuarios { get; set; }
        public virtual ICollection<OrganizacaoUsuarioMySqlViewModel> Organizacoes { get; set; }
    }
}
