import { FuseNavigation } from '@fuse/types';
import { NivelPermissao } from '@models/Permissoes';

export const navigation: FuseNavigation[] = [
    {
        id       : 'home',
        title    : 'Home',
        translate: 'Home',
        type     : 'item',
        icon     : 'home',
        url      : '/home',
    },
    {
        id       : 'pessoas',
        title    : 'Pessoas',
        translate: 'Pessoas',
        type     : 'item',
        icon     : 'person_pin',
        url      : '/pessoas',
       permissions :  [
        NivelPermissao.GoobeeAdmin,
        NivelPermissao.OrganizationAdmin,
        NivelPermissao.AgileCoach,
        NivelPermissao.TeamLeader,
    ]
    },
    {
       id       : 'teste',
       title    : 'Teste',
       translate: 'teste',
       type     : 'item',
       icon     : 'people',
       url      : '/teste'
    //   permissions :  [
    //    NivelPermissao.TeamMember,
    //]
    },
    // {
    //     id       : 'times',
    //     title    : 'Times',
    //     translate: 'Times',
    //     type     : 'item',
    //     icon     : 'people',
    //     url      : '/times',
    //  },
    //{
    //    id       : 'praticas-ageis',
    //    title    : 'Práticas Ágeis',
    //    translate: 'Práticas Ágeis',
    //    type     : 'item',
    //    icon     : 'all_inclusive',
    //    url      : '/praticas-ageis',
    //},
    //{
    //    id       : 'boards',
    //    title    : 'Quadros',
    //    translate: 'Quadros',
    //    type     : 'item',
    //    icon     : 'dashboard',
    //    url      : '/boards',
    //},
    //{
    //    id       : 'projetos',
    //    title    : 'Projetos',
    //    translate: 'Projetos',
    //    type     : 'item',
    //    icon     : 'work',
    //    url      : '/projetos',
    //},
    //{
    //    id       : 'portfolio',
    //    title    : 'Portfólio',
    //    translate: 'Portfólio',
    //    type     : 'item',
    //    icon     : 'assessment',
    //    url      : '/portfolio',
    //},
    //{
    //    id       : 'indicadores',
    //    title    : 'Indicadores',
    //    translate: 'Indicadores',
    //    type     : 'item',
    //    icon     : 'multiline_chart',
    //    url      : '/dashboard-indicadores',
    //},

];
