export class PegarTimePerfil {
    idPessoa: string;
    timesPessoa: TimesPerfil[];
    todosTimes: TimesPerfil[];
}

export class PegarTimePerfilPUT {
    idPessoa: string;
    timesNovos: TimesPerfil[];
    timesAntigos: TimesPerfil[];
}

export class TimesPerfil {
    id: string;
    nome: string;
    papel: string;
}
