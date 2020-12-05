import { BoxExcelForm } from './BoxExcelForm';
import { TipoBoxExcelForm } from './Enums';
import { ListaQuadros } from './Quadro';

export class PegaMovimento {
    idMovimentoConfiguracao: string;
    qtdMovimento: string;
    pegarEditarMovimento?: PegarEditaMovimento;
}

export class PegarEditaMovimento {
    idTime: string;
    tipo: TipoBoxExcelForm;
    caminhoExcel: string;
    valorManual: number;
    movimentoQuadros: ListaQuadros[];
}
