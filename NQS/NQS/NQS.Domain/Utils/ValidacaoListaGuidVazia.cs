using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain.Utils
{
    class ValidacaoListaGuidVazia : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string mensagemErro = "Lista esta vazia.";
            var listaGuid = (List<Guid>)value;

            if (listaGuid == null)
                return new ValidationResult(mensagemErro);

            if (listaGuid.Count == 0)
                return new ValidationResult(mensagemErro);

            return ValidationResult.Success;
        }
    }
}
