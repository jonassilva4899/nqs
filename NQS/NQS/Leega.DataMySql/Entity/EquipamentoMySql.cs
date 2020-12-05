using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Entity
{
    public class EquipamentoMySql : BaseMySql
    {
        public string Cnes { get; set; }
        public string CnpjEstabelecimento { get; set; }
        public string CnpjMantedora { get; set; }
        public string TipoEstabelecimento { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Fax { get; set; }
        public string Telefone { get; set; }
        public int Quantidade { get; set; }
        public string Email { get; set; }
        public string EsferaAdministrativa { get; set; }
        public string NaturezaOrganizacao { get; set; }
        public string RetencaoTruibutos { get; set; }
        public string AtividadeEnsino { get; set; }
        public string NivelHierarquia { get; set; }
        public string FluxoClientela { get; set; }
        public string TurnoAtendimento { get; set; }
        public string TipoAtendimentoPres { get; set; }
        public string InstalacaoFisicaPAE { get; set; }
        public string Recepcao { get; set; }
        public string Setor { get; set; }
        public string Servicos { get; set; }
        public string CadastroMotivoDA { get; set; }
        public string Trabalho { get; set; }
        public string CadastroOrigens { get; set; }
        public string CadastroEspecialidades { get; set; }
        public string CadastroLinkLE { get; set; }
        public string CadastroMedicamentos { get; set; }
        public string CadastroExames { get; set; }
        public string CadastroTipoDieta { get; set; }
        public string CadastroPSatisfacao { get; set; }
        public string Protocolos { get; set; }
        public string Cadastro { get; set; }
    }
}

