using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class PegarInfoUltimoAssessmentViewModel
    {
        public Guid? IdAssessmentPesquisa { get; set; }
        public int TotalColaboradores { get; set; }
        public int ColaboradoresResponderam { get; set; }
        public int ColaboradoresRespondendo { get; set; }
        public int ColaboradoresNaoResponderam { get; set; }
        public DateTime? DataDisparo { get; set; }
        public double MediaNota { get; set; }
        public List<AssessmentPessoaViewModel> AssessmentPessoas { get; set; }
    }

    public class AssessmentPessoaViewModel
    {
        public Guid IdPessoa { get; set; }
        public string Nome { get; set; }
        public StatusAssessmentEnum Status { get; set; }
    }
}
