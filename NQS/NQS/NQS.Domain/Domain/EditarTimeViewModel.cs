using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class EditarTimeViewModel
    {
        [Required]
        public string Nome { get; set; }
        public string Logo { get; set; }
        [Required]
        public string Proposito { get; set; }
        [Required]
        public string Valores { get; set; }
        public string Localizacao { get; set; }
        public string BioTime { get; set; }
        public int? Capacity { get; set; }
        public bool Ativo { get; set; }
        [StringLength(8000, ErrorMessage = "Acordos não pode ter mais de 8000 caracteres.")]
        public string Acordos { get; set; }
        public List<PegarGrupoViewModel> Grupos { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid IdResponsavelEdicao { get; set; }
    }
}
