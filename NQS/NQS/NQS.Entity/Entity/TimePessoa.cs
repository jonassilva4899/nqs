using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Leega.Entity
{
    public class TimePessoa
    {
        public Guid IdTime { get; set; }
        public Guid IdPessoa { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string Papel { get; set; }
        public bool Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Time Time { get; set; }
    }
}
