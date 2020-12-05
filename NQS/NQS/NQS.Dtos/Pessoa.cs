using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Leega.Util;

namespace Leega.Dtos
{
    public class Pessoa
    {
        public int id { get; set; }
        [CpfCnpjValido]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obrigatório")]
        [MaxLength(14)]
        public string cpfcnpj { get; set; }
        public string tipo { get; set; }

        [MaxLength(160)]
        public string nome { get; set; }

        [MaxLength(160)]
        public string nomesocial { get; set; }
        public string telefone { get; set; }
        public Nullable<DateTime> nascimento { get; set; }
        [MaxLength(160)]
        public string endereco { get; set; }
        public Nullable<int> numero { get; set; }
        [MaxLength(50)]
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        [MaxLength(2)]
        public string uf { get; set; }

        [MaxLength(50)]
        public string pais { get; set; }

        [MaxLength(300)]
        public string biografia { get; set; }
        [MaxLength(255)]
        public string imagem { get; set; }
        public bool anonimo { get; set; }
        public Dtos.Register register { get; set; }
        public Dtos.Embaixador embaixador { get; set; }
        public Dtos.Contato contato { get; set; }
        public List<Dtos.TipoCausa> tipocausa { get; set; }
    }

    public class CpfCnpjValidoAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"Número inválido";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pessoa = (Dtos.Pessoa)validationContext.ObjectInstance;

            if (!Validacao.CpfCnpjValido(pessoa.cpfcnpj))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
