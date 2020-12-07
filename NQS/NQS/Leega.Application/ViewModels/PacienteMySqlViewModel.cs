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

        public int Naturalidade { get; set; }
        public int Raca { get; set; }
        public int Sexo { get; set; }

        public int Nacionalidade { get; set; }

        public int Escolaridade { get; set; }

        public int SituacaoFamiliar { get; set; }

        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Profissao { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string NomeContatoEmergencia { get; set; }

        public string Email { get; set; }

        public int Convenio { get; set; }

        public int Especialidade { get; set; }

        public bool AtendimentoPrioritario { get; set; }

        public int MotivoAtendimento { get; set; }

        public int Impressao { get; set; }

        public int Procedencia { get; set; }

        public int OrigemAtendimento { get; set; }

        public string DesfechoAtendimento { get; set; }
    }
}
