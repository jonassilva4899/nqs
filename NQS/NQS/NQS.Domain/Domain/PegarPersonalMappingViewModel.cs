using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarPersonalMappingViewModel
    {
        public Guid IdTitulo { get; set; }
        public string Titulo { get; set; }
        public List<PegarPersonalMappingItemViewModel> Itens { get; set; }
    }
}
