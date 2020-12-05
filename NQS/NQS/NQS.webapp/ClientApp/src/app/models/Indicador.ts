export class Indicador {
    idIndicador: string;
    titulo: string;
    valorPrincipal: string;
    valorOpcionalUm: string;
    valorOpcionalDois: string;
    arquivoExcelUrl: string;
    exibeDashPratica: boolean;
    tipo: TipoIndicador;
    tipoCalculo: TipoCalculoIndicador;
    listaDadosExcel: IndicadorDadosExcel[];
    nomeBarraA: string;
    nomeBarraB: string;
}

export class IndicadorDadosExcel {
    data: string;
    valorA: number;
    valorB: number;
}

class IndicadorOBJ {
    Titulo: string;
    ValorPrincipal: string;
    ValorOpcionalUm: string;
    ValorOpcionalDois: string;
    'IndicadorExcel.Tipo': TipoIndicador;
    'IndicadorExcel.TipoCalculo': TipoCalculoIndicador;
    'IndicadorExcel.ArquivoExcel': File;
}

export class IndicadorPOST extends IndicadorOBJ {
    IdTime: string;
    IdResponsavelCriacao: string;
}

export class IndicadorPUT extends IndicadorOBJ {
    IdIndicador: string;
    IdResponsavelEdicao: string;
}

export enum TipoIndicador {
    Numero = 1,
    Grafico = 2,
}

export enum TipoCalculoIndicador {
    SomaAMaisB = 1,
    DivideAPorB = 2,
    DivideBPorA = 3,
    SubtraiAMenosB = 4,
    SubtraiBMenosA = 5,
}
