import { Guid } from 'guid-typescript';

export class TimeDetalhe {
    exibicaoMensagem: string;
    objeto: TimeDetalheDados;
}

export class TimeDetalheDados {
    logo: string;
    nome: string;
    proposito: string;
    valores: string;
    localizacao: string;
    acordos?: string;
    bioTime: string;
    ativo: boolean;
    capacity?: number;
    membros?: Membros[];
    grupos?: TimeGrupo[];
}

export class Membros {
    idPessoa: string;
    idTime: string;
    idResponsavelEdicao: string;
    nome: string;
    papel: string;
    email: string;
    horas: number;
}

export class EditarTime {
    logo: string;
    nome: string;
    proposito: string;
    valores: string;
    localizacao: string;
    grupos?: TimeGrupo[];
    idResponsavelEdicao: string;
    dataEdicao: Date;
    bioTime: string;
    acordos?: TimeGrupo[];
    capacity?: number;
    ativo: boolean;
}

export class TimeGrupo {
    idGrupo: string;
    nome: string;
}
