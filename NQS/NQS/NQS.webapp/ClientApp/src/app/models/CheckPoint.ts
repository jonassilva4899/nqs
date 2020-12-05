export class Checkpoint {
    idPessoa?: string;
    idCheckpoint: string;
    idAnalista?: string;
    nomeAnalista: string;
    dataRealizacao: Date;
    dataAgendamento: Date;
    sentimentoColaborador: number;
    sentimentoRhAgil: number;
    observacoes: string;
    status: boolean;
    ResponsavelCriacao?: string;
    ResponsavelEdicao?: string;
}

export class ListaCheckpoint {
    idsTimes: string[];
    listaCheckpoints: Checkpoint[];
    temAgendado: boolean;
}

export class Filtro {
    idPessoa: string;
    idPessoaLogada: string;
    dataInicio: Date;
    dataFim: Date;
}

export class IndicadorCheckpoints {
    constructor(
        public grafico: IndicadorCheckpointDados[] = [],
        public porcentagemRecebidos: number = 0,
        public qtdPessoasReceberamCheckpoint: number = 0,
        public qtdTotalDePessoas: number = 0,
    ) { }
}

export class IndicadorCheckpointDados {
    mes: number;
    ano: number;
    quantidadeCheckpoint: number;
}
