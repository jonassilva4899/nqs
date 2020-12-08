using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Application.ViewModels
{
    public class PacienteMySqlViewModel: BaseMySqlViewModel
    {
        public string DocumentoIdentificacao { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeGenitor { get; set; }
        public Nullable<DateTime> DataNascimento { get; set; }
        public string CartaoSus { get; set; }
        public string Apelido { get; set; }
        public string Rg { get; set; }
        public string NomeGenitor2 { get; set; }

        public string Naturalidade { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }

        public string Nacionalidade { get; set; }

        public string Escolaridade { get; set; }

        public string SituacaoFamiliar { get; set; }

        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Profissao { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string NomeContatoEmergencia { get; set; }

        public string Email { get; set; }

        public string Convenio { get; set; }

        public string Especialidade { get; set; }

        public bool AtendimentoPrioritario { get; set; }

        public string MotivoAtendimento { get; set; }

        public string Impressao { get; set; }

        public string Procedencia { get; set; }

        public string OrigemAtendimento { get; set; }

        public string DesfechoAtendimento { get; set; }
    }
}
