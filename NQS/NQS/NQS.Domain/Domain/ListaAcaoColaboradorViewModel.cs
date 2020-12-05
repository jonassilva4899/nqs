using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class ListaAcaoColaboradorViewModel
    {
        public Guid Id { get; set; }
        public string NomeAcao { get; set; }
        public string DetalheAcao { get; set; }
        public DateTime Data { get; set; }
        public Guid? IdPessoaCriacao { get; set; }
        public string NomePessoaCriacao { get; set; }
        [Required]
        public Guid? IdResponsavel { get; set; }
        public string NomeResponsavel { get; set; }
        public StatusAcaoEnum Status { get; set; }
    }
}
