import { PessoaDados } from './Pessoa';

export class Organizacao {
    id?: string;
    nome: string;
    foto: string;
    descricao: string;
    localizacao: string;
    idUsuario: string;
    idPessoas: Array<string>;
    dataCriacao: Date;
    responsavelCriacao: string;
    dataEdicao?: Date;
    responsavelEdicao?: string;
    pessoas: PessoaDados[];
}

export class OrganizacaoDadosBasicos {
    idOrganizacao: string;
    nomeOrganizacao: string;
}

export class UsuarioOrganizacao {
    idOrganizacao: string;
    idUsuario: string;
    dataCriacao: Date;
    responsavelCriacao: string;
}