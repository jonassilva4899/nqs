import { SocialUser } from 'angularx-social-login';
import { Guid } from 'guid-typescript';

export class UsuarioSocialConvite {
    idRecuperarSenha: string;
    idConviteHistorico: Guid;
    usuarioSocial: SocialUser;
}