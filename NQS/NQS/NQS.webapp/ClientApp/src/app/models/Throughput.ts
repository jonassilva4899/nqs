import { Times } from './Times';
import { Quadro, QuadroBoxForm } from './Quadro';
import { TipoBoxExcelForm } from './Enums';

export class Throughput {
    id: string;
    idTime: string;
    time: Times;
    tipo: TipoBoxExcelForm;
    valorManualMesAtual: number;
    throughputQuadro: ThroughputQuadro[];
    caminhoExcel: string;
    responsavelCriacao: string;
    responsavelEdicao: string;
}

export class ThroughputQuadro {
    id: string;
    idQuadro: string;
    quadro: QuadroBoxForm;
}