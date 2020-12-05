using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class EditarPersonalMappingViewModel
    {
        [Required]
        public Guid IdPessoa { get; set; }
        [Required]
        public Guid IdTitulo { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public List<PegarPersonalMappingItemViewModel> Itens { get; set; }
        [Required]
        public Guid IdResponsavel { get; set; }
    }
}
