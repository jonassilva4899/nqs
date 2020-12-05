using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarMelhoriaContinuaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdTime { get; set; }
        public string Acao { get; set; }
        public string Descricao { get; set; }
        public OrigemEnum Origem { get; set; }
        public CompetenciaEnum Competencia { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataInclusao { get; set; }
        public Guid IdResponsavelMelhoriaContinua { get; set; }
        public string NomeResponsavelMelhoriaContinua { get; set; }
        public bool porcetagemMenor { get; set; }
    }
}
