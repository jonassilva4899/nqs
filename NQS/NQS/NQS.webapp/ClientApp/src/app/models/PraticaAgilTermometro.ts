import { QuestaoCompetencia } from './Competencia';

export class CompetenciaTermometro {
    idCompetencia: string;
    nomeCompetencia: string;
    pontos: number;
}

export class PraticaAgilTermometro {
    nomePraticaAgil: string;
    pontos: number;
}

export class DetalhesCompetenciaTermometro {
    praticasCompetencia: PraticaAgilTermometro[];
    questoesCompetencia: QuestaoCompetencia[];
}
