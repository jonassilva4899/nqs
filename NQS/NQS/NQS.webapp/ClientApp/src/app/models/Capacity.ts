import { TipoBoxExcelForm } from './Enums';
import { QuadroBoxForm, ListaQuadros } from './Quadro';

export class Capacity {
    idCapacityConfiguracao: string;
    qtdCapacity: string;
    pegarEditarCapacity: EditarCapacity;
}

export class EditarCapacity {
    idTime: string;
    tipo: TipoBoxExcelForm;
    caminhoExcel: string;
    valorManual?: number;
    capacityQuadros: ListaQuadros[];
}
