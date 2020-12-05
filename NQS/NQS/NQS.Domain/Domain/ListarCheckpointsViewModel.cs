using Leega.Entity.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Leega.Domain
{
    public class ListarCheckpointsViewModel
    {
        public List<ListaCheckpointsViewModel> ListaCheckpoints { get; set; }
        public bool TemAgendado { get; set; }
        public List<Guid> IdsTimes { get; set; }
    }

    public class ListaCheckpointsViewModel
    {
        public Guid IdCheckpoint { get; set; }
        public string NomeAnalista { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public DateTime DataAgendamento { get; set; }
        public SentimentoColaboradorEnum SentimentoColaborador { get; set; }
        public SentimentoRhAgilEnum SentimentoRhAgil { get; set; }
        public string Observacoes { get; set; }
        public bool Status { get; set; }

        
    }

    public class ComparadorListaCheckpoints : IComparer<ListaCheckpointsViewModel>
    {
        public int Compare(ListaCheckpointsViewModel x, ListaCheckpointsViewModel y)
        {
            if (x.DataRealizacao == null)
            {
                if (y.DataRealizacao == null)
                {
                    if (x.DataAgendamento >= y.DataAgendamento)
                        return 1;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
            {
                if (y.DataRealizacao == null)
                    return 1;
                else
                {
                    if (x.DataRealizacao >= y.DataRealizacao)
                        return -1;
                    else
                        return 1;
                }
            }
        }
    }
}
