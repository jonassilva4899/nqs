import { ProjetoDadosBasicos } from './Projeto';

export class QuadroBoxForm {
    idTime: string;
    nome: string;
    id: string;
}

export class Quadro {
    idQuadro: string;
    nomeQuadro: string;
    qtdMembros: number;
    nomeProjetos: Array<any>;
}

export class Coluna {
    id: string;
    idQuadro: string;
    nome: string;
    indice: number;
    dataCriacao: string;
    responsavelCriacao: string;
    dataEdicao: string;
    responsavelEdicao: string;
    idOrganizacao: string;
    wipLimit: number;
    tipoColuna: TipoColuna;
    colunaCards: CardColuna[];
    cardMovidos: string | number;
}

export class ColunaPOST {
    nome: string;
    indice: number;
    idQuadro: string;
    idResponsavel: string;
}

export class ColunaPUT extends ColunaPOST {
    id: string;
    wipLimit: number;
    tipoColuna: TipoColuna;
}

export class CardColuna {
    constructor(
        public id: string,
        public nome: string,
        public indice: number,
        public idQuadro: string,
        public responsaveis: Responsavel[] = [],
        public etiquetas: EtiquetaCard[] = [],
        public descricao?: string,
        public bloqueado?: boolean,
        public motivoBloqueio?: string,
        public pontuacao?: string | number,
        public projeto?: Projeto,
        public epico?: Epico,
        public iteracao?: Iteracao,
    ) { }
}

export class Card {
    idQuadro: string;
    idCard: string;
    nome: string;
    descricao: string;
    projeto: Projeto;
    epico: Epico;
    iteracao: Iteracao;
    pontuacao: number | string;
    dataCriacao: string;
    dataEdicao: string;
    idResponsavelEdicao: string;
    idOrganizacao: string;
    bloqueado: boolean;
    motivoBloqueio: string;
    status: any;
    cardLogs: LogCard[];
    cardEtiqueta: Array<any>;
    responsavelCards: MembroTime[];
}

export class StatusCard {
    idColuna: string;
    nomeColuna: string;
}

export class Projeto {
    idProjeto: string;
    nome: string;
}

export class Epico {
    idEpico: string;
    nome: string;
}

export class Iteracao {
    idIteracao: string;
    nome: string;
}

export class Responsavel {
    idPessoa: string;
    nome: string;
    foto: string;
}

export class MembroTime {
    idMembro: string;
    nomeMembro: string;
}

export class EtiquetaCard {
    idColunaCard: string;
    idEtiqueta: string;
    cor: string;
    nome: string;
}

export class LogCard {
    dataCriacao: string;
    dataMovimentacao: string;
    idPessoaMoveu: string;
    nomePessoaMoveu: string;
    idColunaDe: string;
    nomeColunaDe: string;
    idColunaPara: string;
    nomeColunaPara: string;
}

export enum TipoColuna {
    Normal = 0,
    Entrada = 1,
    Saida = 2,
}

export class ListaQuadros {
    id: string;
    nome: string;
}

export class ConfiguracaoIndiceColuna {
    idColunaMovida: string;
    idQuadro: string;
    colunas: {
        idColuna: string;
        indice: number;
    }[];
    idResponsavelEdicao: string;
}

export class ComentarioCard {
    idComentario: string;
    idPessoaComentou: string;
    nomePessoaComentou: string;
    dataHoraComentario: string;
    comentario: string;
}
