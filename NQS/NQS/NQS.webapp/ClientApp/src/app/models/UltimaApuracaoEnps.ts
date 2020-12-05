export class UltimaApuracaoEnps {
    idEnpsPesquisa: string;
    media: number;
    total: number;
    quantidadeRespondidos: number;
    quantidadeNaoRespondidos: number;
    dataUltimoEnvio: Date;
    somenteMembros: boolean;
}

export class PerguntaEnps {
    idOrganizacao: string;
    idPesquisaPergunta: string;
    idTime: string;
    texto: string;
    dataCriacao: Date;
    responsavelCriacao: string;
    dataEdicao: Date;
    responsavelEdicao: string;
}
