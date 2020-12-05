export class Permissao {
    nivelPermissao: NivelPermissao;
    descricao: string;
}

export enum NivelPermissao {
    GoobeeAdmin = 1,
    OrganizationAdmin = 2,
    AgileCoach = 3,
    TeamLeader = 4,
    TeamMember = 5,
}
