using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class InformarHumorViewModel
    {
        public Guid? IdSentimentoPessoa { get; set; }
        public SentimentoColaboradorEnum Sentimento { get; set; }
    }
}
