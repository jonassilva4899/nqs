import { Periodicidade } from './Enums';
import { ObjetivoPlanning } from './Planning';

export class RegistrarReview {
    idReview?: string;
    idTime: string;
    idResponsavelRegistro: string;
    idPlanning: string;
    observacao: string;
    objetivos: ObjetivoPlanning[];
}

export class ListaReview {
    idReview: string;
    idPlanning: string;
    dataCriacao: Date;
    dataHoraRealizacaoPlanning: string;
    nomeResponsavelRegistro: string;
    objetivos: ObjetivoPlanning[];
    observacao: string;
    idResponsavelRegistro: string;
}

export class ConfiguracaoReview {
    idConfiguracaoReview?: boolean;
    idTime: string;
    periodicidade: Periodicidade;
    dataPrecursora: string;
    horarioReview: string;
    idResponsavelCriacao: string;
    realizada?: boolean;
}

export class InfoReview {
    quantidadeReviews: number;
    proximaReview: string;
    ultimaReview: string;
    reviewConfigurada: boolean;
}
