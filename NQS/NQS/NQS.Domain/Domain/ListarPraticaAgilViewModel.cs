using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ListarPraticaAgilViewModel
    {
        public Guid IdPraticaAgil { get; set; }
        public string NomePraticaAgil { get; set; }
        public string Chave { get; set; }
        public bool Selecionada { get; set; }
    }
}
