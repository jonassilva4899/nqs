import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ExibirParaNiveisDirective } from '@shared/directives/exibir-para-niveis.directive';
import { NivelPermissao } from '@models/Permissoes';

@Injectable({ providedIn: 'root' })
export class RouteGuard implements CanActivate {

    exibirParaNiveis = new ExibirParaNiveisDirective();

    constructor(
        private router: Router,
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const exibirParaNiveis = route.data.exibirParaNiveis;
        const ouSeTeamLeader = route.data.ouSeTeamLeader ?
            [route.paramMap.get(route.data.parametroIdTime)] : [];
        const ouSeTeamMember =  route.data.ouSeTeamMember ?
            route.paramMap.get(route.data.parametroIdTime) : '';

        this.exibirParaNiveis.exibirParaNiveis = exibirParaNiveis;

        if (ouSeTeamLeader) {
            this.exibirParaNiveis.exibirParaNiveisOuSeTeamLeader = ouSeTeamLeader;
        }

        if (ouSeTeamMember) {
            this.exibirParaNiveis.exibirParaNiveisOuSeTeamMember = ouSeTeamMember;
        }

        if (this.exibirParaNiveis.temPermissao) {
            return true;
        } else {
            this.router.navigate(['/home']);
        }

        return false;
    }
}
