using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Leega.Domain
{
    public class PessoaViewModel : BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        public string Foto { get; set; }
        [Required]
        public string FuncaoPrincipal { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string MiniBio { get; set; }
        public bool Status { get; set; }
        public bool GoobeeAdmin { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public Guid ResponsavelEdicao { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        //public virtual ICollection<ProjetoViewModel> ResponsaveisComercial { get; set; }
        public virtual ICollection<RecuperarSenhaViewModel> RecuperarSenhas { get; set; }
        //public virtual ICollection<ConviteViewModel> Convites { get; set; }
        //public virtual ICollection<ConviteHistoricoViewModel> ConvitesHistorico { get; set; }
        //public virtual ICollection<TimePessoaViewModel> TimePessoas { get; set; }
        //public virtual ICollection<CheckpointViewModel> PessoaCheckpoints { get; set; }
        //public virtual ICollection<CheckpointViewModel> AnalistaCheckpoints { get; set; }
        public virtual ICollection<PessoaClienteViewModel> PessoaClientes { get; set; }
        public virtual ICollection<PersonalMappingTituloViewModel> PersonalMappingTitulos { get; set; }
        //public virtual ICollection<MelhoriaContinuaViewModel> MelhoriasContinuas { get; set; }
        public virtual ICollection<PessoaHabilidadeViewModel> PessoaHabilidades { get; set; }
        //public virtual ICollection<AcaoViewModel> AcoesPessoa { get; set; }
        //public virtual ICollection<AcaoViewModel> AcoesResponsavel { get; set; }
        public virtual ICollection<PessoaMotivadorViewModel> PessoaMotivadores { get; set; }
        //public virtual ICollection<DailyViewModel> DailiesRegistradas { get; set; }
        //public virtual ICollection<RetrospectivaViewModel> RetrospectivasRegistradas { get; set; }
        //public virtual ICollection<SentimentoPessoaViewModel> SentimentosPessoa { get; set; }
        //public virtual ICollection<DelegationBoardViewModel> DelegationBoardsSupervisor { get; set; }
        //public virtual ICollection<DelegationBoardViewModel> DelegationBoardsResponsavel { get; set; }
        //public virtual ICollection<ResponsavelProjetoViewModel> ResponsavelProjetos { get; set; }
        //public virtual ICollection<ResponsavelCardViewModel> ResponsavelCards { get; set; }
        //public virtual ICollection<CardLogViewModel> CardMovidos { get; set; }
        public virtual ICollection<OrganizacaoPessoaViewModel> Organizacoes { get; set; }
        //        public virtual ICollection<PlanningViewModel> PlanningsRegistradas { get; set; }
        //        public virtual ICollection<EpicoViewModel> EpicosOwner { get; set; }
        //        public virtual ICollection<EpicoViewModel> EpicosResponsavel { get; set; }
        //        public virtual ICollection<CardComentarioViewModel> CardComentarios { get; set; }
        //        public virtual ICollection<CardAnexoViewModel> CardAnexos { get; set; }
    }
}
