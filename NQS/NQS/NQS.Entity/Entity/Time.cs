using Leega.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Leega.Entity.Entity;

namespace Leega.Entity
{
    public class Time : BaseEntity
    {
        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }
        public string Logo { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string Proposito { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string Valores { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Localizacao { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string BioTime { get; set; }
        public int? Capacity { get; set; }
        public bool Ativo { get; set; }
        public bool PraticaAgilEmFalta { get; set; }
        [Column(TypeName = "VARCHAR(8000)")]
        public string Acordos { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public Guid IdOrganizacao { get; set; }
        //public virtual DailyConfiguracao DailyConfiguracao { get; set; }
        //public virtual RetrospectivaConfiguracao RetrospectivaConfiguracao { get; set; }
        ////public virtual PlanningConfiguracao PlanningConfiguracao { get; set; }
        //public virtual ReviewConfiguracao ReviewConfiguracao { get; set; }
        //public virtual MovimentoConfiguracao MovimentoConfiguracao { get; set; }
        //public virtual CapacityConfiguracao CapacityConfiguracao { get; set; }
        //public virtual ICollection<Seguidor> Seguidores { get; set; }
        public virtual ICollection<TimePessoa> TimePessoas { get; set; }
        public virtual ICollection<Configuracao> Configuracoes { get; set; }
        //public virtual ICollection<PraticaAgilTime> PraticaAgilTimes { get; set; }
        //public virtual ICollection<MelhoriaContinua> MelhoriasContinuas { get; set; }
        //public virtual ICollection<Daily> Dailies { get; set; }
        //public virtual ICollection<Retrospectiva> Retrospectivas { get; set; }
        //public virtual ICollection<TimeDicaAgileCoach> TimeDicasAgileCoach { get; set; }
        //public virtual ICollection<DelegationBoard> DelegationBoards { get; set; }
        //public virtual ICollection<TimeProjeto> TimeProjetos { get; set; }
        //public virtual ICollection<Quadro> Quadros { get; set; }
        //public virtual ICollection<Indicador> Indicadores { get; set; }
        //public virtual ICollection<Planning> Plannings { get; set; }
        //public virtual ICollection<BoxKudoCard> KudoCardTime { get; set; }
        //public virtual ICollection<NotificacaoPraticaAgil> NotificacaoPraticaAgil { get; set; }
        public virtual ICollection<TimeGrupo> TimeGrupos { get; set; }
        //public virtual ICollection<Review> Reviews { get; set; }
    }
}
