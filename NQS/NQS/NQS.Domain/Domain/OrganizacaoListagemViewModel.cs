using System;
using System.Collections.Generic;
using Leega.Entity.Entity;

namespace Leega.Domain.Domain
{
    public class OrganizacaoListagemViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadePessoas { get; set; }
    }
}