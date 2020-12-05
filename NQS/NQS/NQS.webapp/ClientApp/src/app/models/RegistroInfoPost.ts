import { Guid } from 'guid-typescript';

export interface RegistroInfoPost {
    idRecuperarSenha: Guid;
    idConviteHistorico: Guid;
    nome: string;
    email: string;
    existeErroLogin: boolean;
    mensagemErro: string;
    mensagemSucesso: string;
    novaSenha: string;
    confirmacaoNovaSenha: string;
}