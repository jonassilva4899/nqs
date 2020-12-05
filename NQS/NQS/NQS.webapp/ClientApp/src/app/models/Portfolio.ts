import { StatusProjetoID } from './Enums';
import { ProjetoDadosBasicos } from './Projeto';

export class DadosPortfolio {
    constructor(
        public receitaPorTotal: string = '',
        public timesComProjeto: number = 0,
        public timesSemProjeto: number = 0,
        public mediaCapacity: string = '',
        public objetivosMetas: string = '',
        public statusProjetos: DadosGraficosPortfolio[] | any = [],
        public statusEpicos: DadosGraficosPortfolio[] | any = [],
    ) {}
}

export class DadosGraficosPortfolio {
    quantidade: number;
    status: number;
}

export class ProjetosPortfolio {
    temObjetivoMeta: boolean;
    nomeProjeto: string;
    progresso: number;
    nomeTime: string;
    qtdEpicos: number;
    qtdCards: string;
    statusProjeto: StatusProjetoID;
}

export class PortfolioOkr {
    ativo: boolean;
    cor: string;
    dataCriacao: string;
    idPortfolioMeta: string;
    idPortfolioObjetivo: string;
    meta: string;
    objetivo: string;
    periodo: string;
    portfolioAcoes: Array<any>;
    projetos: ProjetoDadosBasicos[];
    qtdAcoes: number;
    qtdEpicos: number;
    qtdProjetos: number;
    realizado: string;
}

export class PortfolioOkrObjetivo {
    idPortfolioObjetivo: string;
    objetivo: string;
    cor: string;
}

export class PortfolioOkrCRUD {
    idPortfolioMeta?: string;
    idPortfolioObjetivo: string;
    objetivo: string;
    cor: string;
    meta: string;
    realizado: string;
    idsProjetos: Array<string>;
    periodo: string;
    ativo: boolean;
    idResponsavel: string;
}

export class AcaoPortfolioOkr {
    nome: string;
    descricao: string;
    status: StatusAcaoPortfolioOkr;
    nomePessoaResponsavel: string;
    idPessoaResponsavel: string;
    idPortfolioAcao: string;
}

export enum StatusAcaoPortfolioOkr {
    NaoIniciado = 1,
    Iniciado = 2,
    Concluido = 3,
}

export class AcaoPortfolioOkrCRUD {
    idPortfolioAcao?: string;
    idPortfolioMeta: string;
    nome: string;
    descricao: string;
    idPessoaResponsavel: string;
    status: StatusAcaoPortfolioOkr;
    idResponsavelEdicao?: string;
    idResponsavelCriacao?: string;
}
