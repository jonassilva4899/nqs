import { Guid } from 'guid-typescript';

export class RegistroInfoGet {
    objeto = new RegistroInfo();
    exibicaoMensagem: string;
}

class RegistroInfo {
    idRecuperarSenha: Guid;
    idConviteHistorico: Guid;
    nome: string;
    email: string;
    existeErroLogin: false;
    mensagemErro: string;
    mensagemSucesso: string;
    novaSenha: string;
    confirmacaoNovaSenha: string;
    contaGoogle: boolean;
}