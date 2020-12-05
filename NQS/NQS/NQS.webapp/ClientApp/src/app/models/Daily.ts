export class Daily {
    idDaily: string;
    dataHoraRegistro: string;
    observacao: string;
    nomeResponsavelRegistro: string;
}

export class DailyConfig {
    idConfiguracaoDaily: string;
    horarioDaily: string;
    realizada: boolean;
    ultimaDaily: string;
    proximaDaily: string;
}
