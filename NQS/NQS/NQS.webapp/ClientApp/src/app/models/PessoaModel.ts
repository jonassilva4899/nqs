import { Guid } from 'guid-typescript';

export class ListaPessoas {
    nome: string;
    id: Guid;
    idOrganizacao: Guid;
    status: boolean;
    funcaoPrincipal: string;
    email: string;
    foto: string;
    ultimoCheckpoint: string;
    proximoCheckpoint: string;
    idsTimes: string[];
}
