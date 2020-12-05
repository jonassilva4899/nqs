import { PontuacaoPlanningPoker } from './Agile';

export class EpicoDados {
    nome: string;
    descricao: string;
    status: EpicoStatus['id'];
    tamanho: PontuacaoPlanningPoker['pontos'];
    dataEntrega: string;
    idOwner: string;
    idResponsavel: string;
}

export class Epico extends EpicoDados {
    idEpico: string;
    nomeOwner: string;
    nomeResponsavel: string;
    qtdCards: number;
}

export class EpicoPOST extends EpicoDados {
    idProjeto: string;
    idResponsavelCriacao: string;
}

export class EpicoPUT extends EpicoDados {
    idEpico: string;
    idResponsavelEdicao: string;
}

export class EpicoStatus {
    id: number;
    descricao: string;
}

export class EpicoDadosBasicos {
    idEpico: string;
    nome: string;
}

export class EpicoFiltroDados {
    idEpico: string;
    nome: string;
    idProjeto: string;
}
