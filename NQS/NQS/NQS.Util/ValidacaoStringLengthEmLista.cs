using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Util
{
    public class ValidacaoStringLengthEmLista : ValidationAttribute
    {
        public int TamanhoMaximo { get; set; }
        public string MensagemErro { get; set; }

        public ValidacaoStringLengthEmLista(int tamanhoMaximo, string mensagemErro)
        {
            TamanhoMaximo = tamanhoMaximo;
            MensagemErro = mensagemErro;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var listaString = (List<string>)value;

            foreach(var itemString in listaString)
            {
                if (itemString.Length > TamanhoMaximo)
                    return new ValidationResult(MensagemErro);
            }

            return ValidationResult.Success;
        }
    }
}
