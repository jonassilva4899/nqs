using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PlanilhaExcelModel
    {
        public DateTime Data { get; set; }

        public int Valor { get; set; }
    }

    public class PlanilhaLeadTimeExcelModel
    {
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int Valor { get; set; }
    }

    public class PlanilaIndicadoresExcelModel
    {
        public DateTime Data { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
    }

    public class PlanilaNomeColunaExcelModel
    {
        public string Coluna { get; set; }
        public object Valor { get; set; }
        public string Tipo { get; set; }

    }
}
