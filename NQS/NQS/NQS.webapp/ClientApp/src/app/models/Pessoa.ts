import { Guid } from 'guid-typescript';

export class Pessoa {
    Pessoa: PessoaDados;
    pessoaRequisitando: Guid;
    eUsuario: boolean;
}

export class PessoaDados {
    id?: string;
    nome: string;
    email: string;
    status: boolean;
}

export class FiltrosPessoas {
    nomeColaborador: string;
    idTime: string;
    idGrupo: string;
    idCliente: string;
    idResponsavel: string;
    status: boolean;
    habilidade: string;
    comecaCom: number;
    terminaCom: number;
    idPessoaLogada: string;
}

export class ListaFiltroPessoas {
    id: string;
    nome: string;
}

export class MembroDoTime {
    idMembro: string;
    nomeMembro: string;
}
