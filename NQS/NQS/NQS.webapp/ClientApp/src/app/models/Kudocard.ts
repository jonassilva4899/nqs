export class KudoCard {
    id: string | number;
    nome: string;
    imagem: string;
}

export enum KudoCardID {
    ObrigadoPelaForca = 1,
    ParabensMestre = 2,
    QueMaravilha = 3,
    QueTrabalhoIncrivel = 4,
    VoceEImbativel = 5,
    SuperTrabalho = 6,
    TimePoderoso = 7,
}

export class KudoCardsNumeros {
    constructor(
        public enviados = 0,
        public recebidos = 0,
    ) {}
}

export class KudoCardDados {
    tipoKudoCard: KudoCardID;
    mensagemBoxKudoCard: string;
    mensagemKudoCard: string;
    destinatario?: string;
    remetente?: string;
}

export class KudoCardEnviadosRecebidos {
    constructor(
        public enviados: KudoCardDados[] = [],
        public recebidos: KudoCardDados[] = [],
    ) {}
}

export class EnvioKudoCard {
    idTime?: string;
    de: string;
    para?: string;
    mensagem: string;
    tipoDestinatario: KudoCardTipoDestinatario;
    tipoKudoCard: KudoCardID;
}

export enum KudoCardTipoDestinatario {
    Pessoa = 1,
    Time = 2,
}
