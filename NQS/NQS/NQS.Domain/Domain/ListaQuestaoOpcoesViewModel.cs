using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class ListaQuestaoOpcoesViewModel
    {
        public Guid? IdQuestaoOpcao { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public TemperaturaTermometroEnum TemperaturaTermometro { get; set; }
    }
}
