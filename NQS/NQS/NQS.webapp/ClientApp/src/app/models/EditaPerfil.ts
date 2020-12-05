import { NivelPermissao } from './Permissoes';

export class EditaPerfil {
    idPessoa: string;
    foto: string;
    nome: string;
    funcaoPrincipal: string;
    email: string;
    telefone: string;
    miniBio: string;
    idResponsavelEdicao: string;
    eUsuario: boolean;
    status: boolean;
    nivelPermissao: NivelPermissao;
    eContaGoogle: boolean;
}
