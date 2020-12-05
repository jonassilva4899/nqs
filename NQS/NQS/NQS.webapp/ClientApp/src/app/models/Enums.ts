export enum Acao {
    Cadastro = 1,
    Edicao = 2,
}

export enum Engajamento {
    Bom = 1,
    Medio = 2,
    Ruim = 3,
}

export enum SentimentoEnum {
    SemSentimento = 0,
    Feliz = 1,
    Neutro = 2,
    Irritado = 3,
}

export enum CompetenciaEnum {
    Lideranca = 1,
    Cultura = 2,
    Framework = 3,
    Qualidade = 4,
    Cliente = 5,
    PraticasAgeis = 6,
    Metricas = 7,
    Planejamento = 8,
    AtendimentoCliente = 9,
}

export enum OrigemEnum {
    Retrospectiva = 1,
    Daily = 2,
    AgileCoach = 3,
    Healthcheck = 4,
}

export enum StatusEnum {
    NaoIniciado = 1,
    Iniciado = 2,
    Concluido = 3,
    Bloqueado = 4,
}

export enum PraticaAgilChave {
    Daily = 'DAILY',
    Review = 'REVIEW',
    Planning = 'PLNNNG',
    Retrospectiva = 'RTSPCTV',
    TaxaSucessoPlanning = 'TX_SCSS_PLNNNG',
    MelhoriaContinua = 'MLR_CTN',
    TeamMood = 'TM_NC',
    DicasAgileCoach = 'DICA_AC',
    Delegation_Board = 'DLGTN_BRD',
    Indicador = 'INDCDR',
    Movimento = 'MVMT',
    Throughput = 'THRGHPUT',
    Throughput3Meses = 'THRGHPUT3MESES',
    Leadtime  = 'LDTM',
    Capacity = 'CPCTY',
    Proposito = 'PPST',
}

export enum MotivadoresEnum {
    Status = 'Status',
    Aceitacao = 'Aceitação',
    Ordem = 'Ordem',
    Maestria = 'Maestria',
    Poder = 'Poder',
    Meta = 'Meta',
    Relacaoo = 'Relação',
    Liberdade = 'Liberdade',
    Honra = 'Honra',
    Curiosidade = 'Curiosidade',
}

export enum DelegacaoEnum {
    Dizer = 1,
    Vender = 2,
    Consultar = 3,
    Concordar = 4,
    Aconselhar = 5,
    Perguntar = 6,
    Delegar = 7,
}

export enum Periodicidade {
    Semanalmente = 1,
    Quinzenalmente = 2,
    Mensalmente = 3,
}

export enum StatusDicaAgileCoach {
    Indefinido = 0,
    Aceita = 1,
    Rejeitada = 2,
    NaoLida = 3,
}

export enum StatusProjeto {
    Aprovado = 'Aprovado',
    Reprovado = 'Reprovado',
    Pendente = 'Pendente',
    EmAndamento = 'Em Andamento',
    Bloqueado = 'Bloqueado',
    Finalizado = 'Finalizado',
}

export enum StatusProjetoID {
    Aprovado = 0,
    Reprovado = 1,
    Pendente = 2,
    EmAndamento = 3,
    Bloqueado = 4,
    Finalizado = 5,
}

export enum CategoriaProjeto {
    Projeto = 'Projeto',
    TimeEstendido = 'Time Estendido',
    TalentX = 'TalentX',
    OperacoesDeTI = 'Operações de TI',
    RPA = 'RPA',
    LGPD = 'LGPD',
    IA = 'IA',
    UX = 'UX',
}

export enum DeliveryProjeto {
    LigaAgil = 'Liga Ágil',
    OperacoesDeTI = 'Operações de TI',
    DeliveryCenter = 'Delivery Center',
    TalentX = 'TalentX'
}

export enum MovimentacaoCapacity {
    Movimentacao = 1,
    Capactity = 2,
}

export enum TipoBoxExcelForm {
    ValorManual = 1,
    Planilha = 2,
    Quadro = 3
}

export enum TermometroAgilEnum {
    Congelado = 'Congelado',
    Frio = 'Frio',
    Morno = 'Morno',
    Quente = 'Quente',
    Fervendo = 'Fervendo',
}

export enum ThroughputMeses {
    'Mes' = 1,
    '3Meses' = 3,
}

export enum TipoSelecaoFiltroToolbar {
    Time = 1,
    Grupo = 1,
    Organizacao = 1,
}
