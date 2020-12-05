using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarMovimentoViewModel
    {
        public Guid? IdMovimentoConfiguracao { get; set; }
        public string QtdMovimento { get; set; }
        public PegarEditarMovimentoViewModel PegarEditarMovimento { get; set; }
    }

    public class PegarEditarMovimentoViewModel
    {
        public Guid IdTime { get; set; }
        public TipoMovimentoEnum Tipo { get; set; }
        public string CaminhoExcel { get; set; }
        public string ValorManual { get; set; }
        public List<ListaTodosQuadrosViewModel> MovimentoQuadros { get; set; }
    }
}
