using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class FiltrosListarPessoasViewModel
    {
        public string NomeColaborador { get; set; }
        public Guid? IdTime { get; set; }
        public Guid? IdGrupo { get; set; }
        public Guid? IdCliente { get; set; }
        public Guid? IdResponsavel { get; set; }
        public bool? Status { get; set; }
        public string Habilidade { get; set; }
        public int ComecaCom { get; set; }
        public int TerminaCom { get; set; }
        [Required]
        public Guid IdPessoaLogada { get; set; }
    }
}
