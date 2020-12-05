export class Motivador {
    id: string;
    nome: string;
    indice: number;
}

export class Motivadores {
    idPessoa: string;
    motivadores: Motivador[];
}

export class MotivadorPUT {
    idMotivador: string;
    indice: number;
}

export class MotivadoresPUT {
    idPessoa: string;
    motivadoresEditados: MotivadorPUT[];
    idResponsavelEdicao: string;
}
