export class PraticaAgil {
    idPraticaAgil: string;
    nomePraticaAgil: string;
    chave?: string;
    selecionada?: boolean;
}

export class PraticaAgilTime extends PraticaAgil {
    idTime: string;
    dataInicio: string;
    engajamento: number;
    status: boolean;
}
