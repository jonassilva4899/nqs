import { Periodicidade } from './Enums';

export class RegistraRetrospectiva {
    idRetrospectiva?: string;
    idTime: string;
    idResponsavelRegistro: string;
    idTecnicaUtilizada: string;
    nomeTecnicaUtilizada: string;
    observacao: string;
}

export class ListaRetrospectiva {
    idRetrospectiva: string;
    idResponsavelRegistro: string;
    nomeResponsavelRegistro: string;
    idTecnicaUtilizada: string;
    nomeTecnicaUtilizada: string;
    observacao: string;
    dataCriacao: Date;
    responsavelCriacao: string;
    dataEdicao: Date;
    responsavelEdicao: string;
}

export class ConfiguraRetrospectiva {
    idConfiguracaoRetrospectiva?: string;
    periodicidade: Periodicidade;
    dataPrecursora: Date;
    horarioRetrospectiva: string;
    idTime?: string;
    idResponsavelCriacao: string;
    idResponsavelEdicao: string;
    dataEdicao?: Date;
    realizada: boolean;
}

export class InfoRetrospectiva {
    quantidadeRetrospectivas: number;
    proximaRetrospectiva: Date;
    ultimaRetrospectiva: Date;
    retrospectivaConfigurada: boolean;
}