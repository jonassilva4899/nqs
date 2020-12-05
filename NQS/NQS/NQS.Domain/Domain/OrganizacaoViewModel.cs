using System;
using System.Collections.Generic;
using Leega.Entity.Entity;

namespace Leega.Domain.Domain
{
    public class OrganizacaoViewModel
    {
        public Guid? Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public List<Guid> IdPessoas { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public Guid? ResponsavelEdicao { get; set; }
        public List<ResumoPessoaViewModel> Pessoas { get; set; }
    }

    public class ResumoPessoaViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}