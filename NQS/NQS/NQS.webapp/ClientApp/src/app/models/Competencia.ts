import { PraticaAgil } from './PraticaAgil';

export class InfoCompetencias {
    qtdCompetencias: number;
    qtdTotalQuestoes: number;
    temCompetencia: boolean;
}

export class Competencia {
    idCompetencia: string;
    nome: string;
    descricao: string;
    praticasAgeis: PraticaAgil[];
}

export class CompetenciaCRUD {
    idCompetencia?: string;
    nome: string;
    descricao: string;
    idsPraticas: string[];
    idResponsavel: string;
}

export class QuestaoCompetencia {
    idCompetenciaQuestao: string;
    tituloQuestao: string;
    mediaPontos?: number;
    descricaoOpcao?: number;
    questaoOpcoes: TemperaturaQuestaoCompetencia[];
}

export class QuestaoCompetenciaCRUD {
    idCompetenciaQuestao?: string;
    idCompetencia?: string;
    tituloQuestao: string;
    questaoOpcoes: TemperaturaQuestaoCompetencia[];
    idResponsavel: string;
}

export class TemperaturaQuestaoCompetencia {
    idQuestaoOpcao?: string;
    descricao: string;
    porcentagemVotado?: string;
    temperaturaTermometro: TemperaturaTermometroEnum;
}

export enum TemperaturaTermometroEnum {
    Congelado = 1,
    Frio = 2,
    Morno = 3,
    Quente = 4,
    Fervendo = 5,
}
