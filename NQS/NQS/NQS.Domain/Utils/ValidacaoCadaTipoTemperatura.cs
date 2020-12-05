using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Leega.Domain.Utils
{
    class ValidacaoCadaTipoTemperatura : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string mensagemErro = string.Empty;
            var listaQuestaoOpcoes = (List<ListaQuestaoOpcoesViewModel>)value;

            if (listaQuestaoOpcoes == null)
            {
                mensagemErro = "Lista de QuestaoOpcoes esta vazia.";
                return new ValidationResult(mensagemErro);
            }

            foreach (TemperaturaTermometroEnum temperaturaTermometro in Enum.GetValues(typeof(TemperaturaTermometroEnum)))
            {
                if (!listaQuestaoOpcoes.Any(x => x.TemperaturaTermometro == temperaturaTermometro))
                {
                    mensagemErro = "Um dos tipos de temperatura não existe na lista.";
                    return new ValidationResult(mensagemErro);
                }
            }

            return ValidationResult.Success;
        }
    }
}
