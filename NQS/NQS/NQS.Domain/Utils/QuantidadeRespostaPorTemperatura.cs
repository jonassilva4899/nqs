using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain.Utils
{
    public class QuantidadeRespostaPorTemperatura
    {
        public TemperaturaTermometroEnum TemperaturaTermometro { get; set; }
        public int QuantidadeResposta { get; set; }
    }
}
