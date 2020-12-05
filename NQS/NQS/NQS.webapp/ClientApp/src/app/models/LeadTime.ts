import { TipoBoxExcelForm } from './Enums';
import { QuadroBoxForm } from './Quadro';

export class LeadTime {
    id: string;
    idTime: string;
    tipo: TipoBoxExcelForm;
    valorManualMesAtual: number;
    leadtimeQuadro: LeadTimeQuadro[];
    urlPlanilha: string;
    responsavelCriacao: string;
    responsavelEdicao: string;
}

export class LeadTimeQuadro {
    id: string;
    idQuadro: string;
    quadro: QuadroBoxForm;
}