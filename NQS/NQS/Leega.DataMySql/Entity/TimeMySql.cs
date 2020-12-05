using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class TimeMySql : BaseMySql
    {
        public string Nome { get; set; }
        public string Logo { get; set; }
        public string Proposito { get; set; }
        public string Valores { get; set; }
        public string Localizacao { get; set; }
        public string BioTime { get; set; }
        public int? Capacity { get; set; }
        public bool Ativo { get; set; }
        public bool PraticaAgilEmFalta { get; set; }
        public string Acordos { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string ResponsavelEdicao { get; set; }
        public string IdOrganizacao { get; set; }
        public virtual ICollection<TimePessoaMySql> TimePessoas { get; set; }
        public virtual ICollection<ConfiguracaoMySql> Configuracoes { get; set; }
        public virtual ICollection<TimeGrupoMySql> TimeGrupos { get; set; }
    }
}
