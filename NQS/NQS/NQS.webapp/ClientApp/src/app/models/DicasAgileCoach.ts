import { StatusDicaAgileCoach } from './Enums';

export class DicasAgileCoachNumeros {
    constructor(
        public qtdDicasAceitas: number = 0,
        public qtdDicasRespondidas: number = 0,
        public qtdTotalDicas: number = 0,
    ) {}
}

export class DicaAgileCoach {
    idDicaAgileCoach: string;
    tema: string;
    dateEnvioDica: string;
    categorias: TagDicaAgileCoach[];
    descricao: string;
    statusDicaAgileCoach: StatusDicaAgileCoach;
}

export class DicaAgileCoachPOST {
    tema: string;
    descricao: string;
    categorias: TagDicaAgileCoach[];
    idResponsavel: string;
    idTime: string;
}

export class DicaAgileCoachPUT extends DicaAgileCoachPOST {
    idDicaAgileCoach: string;
}

export class TagDicaAgileCoach {
    idCategoria: string;
    nomeCategoria: string;
}
