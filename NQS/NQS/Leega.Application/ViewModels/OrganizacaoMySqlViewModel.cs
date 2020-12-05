using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class OrganizacaoMySqlViewModel
    {
        public string Id { get; set; }
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public List<string> IdPessoas { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public List<ResumoPessoaMySqlViewModel> Pessoas { get; set; }
    }
}
