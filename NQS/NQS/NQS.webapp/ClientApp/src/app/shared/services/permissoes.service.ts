import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Permissao, NivelPermissao } from '@models/Permissoes';
import { Usuario } from '@models/Usuario';

@Injectable({
    providedIn: 'root',
})
export class PermissoesService {

    usuario: Usuario;

    constructor() {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    getPermissoes(): Observable<Permissao[]> {
        return new Observable((observer) => {
            const permissoes: Permissao[] = [
                {
                    nivelPermissao: NivelPermissao.GoobeeAdmin,
                    descricao: 'Goobee Admin',
                },
                {
                    nivelPermissao: NivelPermissao.OrganizationAdmin,
                    descricao: 'Organização Admin',
                },
                {
                    nivelPermissao: NivelPermissao.AgileCoach,
                    descricao: 'Agile Coach',
                },
                {
                    nivelPermissao: NivelPermissao.TeamLeader,
                    descricao: 'Team Leader',
                },
                {
                    nivelPermissao: NivelPermissao.TeamMember,
                    descricao: 'Team Member',
                },
            ];

            observer.next(permissoes);
            observer.complete();
        });
    }

    getPermissoesParaUsuarioLogado(): Observable<Permissao[]> {
        return new Observable((observer) => {
            this.getPermissoes()
                .subscribe((permissoes: Permissao[]) => {
                    const index = permissoes.findIndex((p) => p.nivelPermissao === this.usuario.roleEnum);
                    const permissoesFiltro = permissoes.slice(index);

                    observer.next(permissoesFiltro);
                    observer.complete();
                });
        });
    }

}
