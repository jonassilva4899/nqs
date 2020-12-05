using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class UsuarioMySqlViewModel : BaseMySqlViewModel
    {
        public string IdOrganizacao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdPessoa { get; set; }
        public virtual PessoaMySqlViewModel Pessoa { get; set; }
        public virtual ICollection<NotificacaoUsuarioMySqlViewModel> NotificacaoUsuarios { get; set; }
    }
}
