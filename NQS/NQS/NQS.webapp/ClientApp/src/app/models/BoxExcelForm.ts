import { Observable } from 'rxjs';

import { TimeDadosBasicos } from './Times';
import { ListaQuadros } from './Quadro';
import { TipoBoxExcelForm } from './Enums';

export class BoxExcelForm {
    idConfiguracao: string;
    tipo: TipoBoxExcelForm;
    arquivoExcel: File;
    nomeArquivoExcel?: string;
    urlArquivoExcel?: string;
    valorManual: number;
    idsQuadros: Array<string>;
    listaQuadros: ListaQuadros[] = [];
    idReponsavel: string;
    idTime: string;
}

export class BoxExcelFormConfig {
    titulo: string;
    timeSelecionado: TimeDadosBasicos;
    tituloExemploExcel?: Array<string>;
    exemploExcel?: Array<string>;
    listaQuadros$?: Observable<ListaQuadros[]>;
}
