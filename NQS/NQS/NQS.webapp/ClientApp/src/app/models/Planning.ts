import { Periodicidade } from './Enums';

export class RegistrarPlanning {
    idPlanning?: string;
    idTime: string;
    idResponsavelRegistro: string;
    idTecnicaUtilizada: string;
    nomeTecnicaUtilizada: string;
    observacao: string;
    objetivos: ObjetivoPlanning[];
}

export class ListaPlanning {
    idPlanning: string;
    idResponsavelRegistro: string;
    nomeResponsavelRegistro: string;
    idTecnicaUtilizada: string;
    nomeTecnicaUtilizada: string;
    observacao: string;
    dataCriacao: Date;
    responsavelCriacao: string;
    dataEdicao: Date;
    responsavelEdicao: string;
    objetivos: ObjetivoPlanning[];
}

export class PlanningDadosBasicos {
    idPlanning: string;
    dataHoraRegistro: string;
    objetivos: ObjetivoPlanning[];
}

export class ConfigurarPlanning {
    idTime: string;
    periodicidade: Periodicidade;
    dataPrecursora: string;
    horarioPlanning: string;
    idResponsavelCriacao: string;
    realizada?: boolean;
}

export class InfoPlanning {
    quantidadePlannings: number;
    proximaPlanning: string;
    ultimaPlanning: string;
    planningConfigurada: boolean;
}

export class TecnicaPlanning {
    idTecnicaPlanning: string;
    nomeTecnica: string;
}

export class ObjetivoPlanning {
    idObjetivo: number;
    objetivo: string;
    statusObjetivo?: StatusObjetivoPlanning;
}

export enum StatusObjetivoPlanning {
    NaoRealizado = 0,
    RealizadoParcial = 50,
    Realizado = 100,
}

export class ReviewPlanning {
    dataPlanning: string;
    dataReview: string;
    idPlanning: string;
    idReview: string;
    objetivosPlanning: ObjetivoPlanning[];
}

export class TaxaSucessoPlanning {
    reviewsPlannings: ReviewPlanning[];
    taxaSucesso: number;
}
