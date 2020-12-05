using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leega.UI.Models
{
    public class Paciente
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Text, ErrorMessage = "Informe um documento de identificação")]
        public string DocumentoIdentificacao { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Text, ErrorMessage = "Informe o nome completo")]
        public string NomeCompleto { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Text, ErrorMessage = "Informe o nome do Genitor")]
        public string NomeGenitor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Informe a data de nascimento")]
        public Nullable<DateTime> DataNascimento { get; set; }


        
        public string CartaoSus { get; set; }
        public string Apelido { get; set; }        
        public string Rg { get; set; }
        public string NomeGenitor2 { get; set; }

        public Naturalidade Naturalidade { get; set; }
        public Raca Raca { get; set; }
        public Sexo Sexo { get; set; }

        public Nacionalidade Nacionalidade { get; set; }

        public Escolaridade Escolaridade { get; set; }

        public SituacaoFamiliar SituacaoFamiliar { get; set; }        

        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Profissao { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string NomeContatoEmergencia { get; set; }

        public string Email { get; set; }

        public Convenio Convenio { get; set; }

        public Especialidade Especialidade { get; set; }

        public bool AtendimentoPrioritario { get; set; }

        public MotivoAtendimento MotivoAtendimento { get; set; }

        public Impressao Impressao { get; set; }

        public Procedencia Procedencia { get; set; }

        public OrigemAtendimento OrigemAtendimento { get; set; }

        public string DesfechoAtendimento { get; set; }
    }
}
