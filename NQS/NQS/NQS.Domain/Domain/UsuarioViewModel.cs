using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class UsuarioViewModel : BaseDomain
    {
        public Guid IdOrganizacao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdPessoa { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        //public virtual ICollection<SeguidorViewModel> Seguidores { get; set; }
        public virtual ICollection<NotificacaoUsuarioViewModel> NotificacaoUsuarios { get; set; }

    }
}
