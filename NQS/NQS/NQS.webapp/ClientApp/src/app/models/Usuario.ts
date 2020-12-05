import { NivelPermissao } from './Permissoes';

export class Usuario {
    nome: string;
    email: string;
    permissoes: [];
    token: string;
    id: string;
    idPessoa: string;
    foto?: string;
    idOrganizacao: string;
    roleEnum: NivelPermissao;
    idsTimes: string[];
}

export class SolicitacaoToken {
    idUsuario: string;
    idOrganizacao: string;
}
