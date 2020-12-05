import { SentimentoEnum } from './Enums';

export class Sentimento {
    constructor(
        public idSentimentoPessoa = '',
        public sentimento: SentimentoEnum = SentimentoEnum.SemSentimento,
    ) {}
}

export class SentimentoTime {
    constructor(
        public sentimento: SentimentoEnum = SentimentoEnum.SemSentimento,
    ) {}
}

export class SentimentoCalendario {
    sentimento: number;
    dia: number;
    dataCompleta: string;
}

export class SentimentoPessoaCalendario {
    idPessoa: string;
    nomePessoa: string;
    mediaSentimento: SentimentoEnum;
    sentimentoDias: SentimentoCalendario[];
}
