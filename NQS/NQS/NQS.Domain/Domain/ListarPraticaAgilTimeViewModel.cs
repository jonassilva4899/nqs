using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ListarPraticaAgilTimeViewModel
    {
        public Guid IdPraticaAgil { get; set; }
        public Guid IdTime { get; set; }
        public string NomePraticaAgil { get; set; }
        public DateTime DataInicio { get; set; }
        public EngajamentoEnum Engajamento { get; set; }
        public string Chave { get; set; }
        public bool Status { get; set; }
    }
}
