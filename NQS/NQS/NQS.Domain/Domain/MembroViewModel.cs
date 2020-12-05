using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class MembroViewModel
    {
        public Guid IdPessoa { get; set; }
        public Guid IdTime { get; set; }
        public Guid IdResponsavelEdicao { get; set; }
        public string Nome { get; set; }
        public string Papel { get; set; }
        public int Horas { get; set; }
    }
}
