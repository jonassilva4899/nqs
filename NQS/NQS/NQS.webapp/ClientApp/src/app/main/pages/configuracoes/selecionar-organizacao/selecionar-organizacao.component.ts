import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { Observable } from 'rxjs';

import { OrganizacaoService } from 'app/components/organizacao/organizacao.service';
import { OrganizacaoComponent } from 'app/components/organizacao/organizacao.component';

import { Organizacao } from '@models/Organizacao';
import { Usuario, SolicitacaoToken } from '@models/Usuario';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-selecionar-organizacao',
  templateUrl: './selecionar-organizacao.component.html',
  styleUrls: ['./selecionar-organizacao.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class SelecionarOrganizacaoComponent implements OnInit {

    NivelPermissao = NivelPermissao;

    organizacaoControl = new FormControl('');
    listaOrganizacao$: Observable<Organizacao[]>;

    constructor(
        private _organizacaoService: OrganizacaoService,
        private _matDialog: MatDialog,
    ) { }

    ngOnInit(): void {
        this.listarOrganizacoes();

        this.organizacaoControl.valueChanges.subscribe((organizacao) => {
            this.trocarOrganizacao();
        });
    }

    listarOrganizacoes(): void {
        let usuario: Usuario = new Usuario();
        usuario = JSON.parse(localStorage.getItem('usuario'));
        this.listaOrganizacao$ = this._organizacaoService.listar(usuario.id);
        this.organizacaoControl.setValue(usuario.idOrganizacao);
    }

    trocarOrganizacao(): void {
        this.pegarNovoToken(this.organizacaoControl.value);
    }

    pegarNovoToken(idOrganizacao): void {
        let usuario: Usuario = new Usuario();
        usuario = JSON.parse(localStorage.getItem('usuario'));

        const solicitaToken: SolicitacaoToken = new SolicitacaoToken();
        solicitaToken.idUsuario = usuario.id;
        solicitaToken.idOrganizacao = idOrganizacao;

        this._organizacaoService.novoToken(JSON.stringify(solicitaToken))
            .subscribe(
                data => {
                    localStorage.removeItem('usuario');
                    localStorage.setItem('usuario', JSON.stringify(data));
                    localStorage.removeItem('timeSelecionado');
                    window.location.reload();
                });
    }

    adicionaEditOrg(edit?: boolean): void {
        let valor = null;

        if (edit === true) {
            let usuario: Usuario = new Usuario();
            usuario = JSON.parse(localStorage.getItem('usuario'));
            valor = usuario.idOrganizacao;
        }

        this._matDialog.open(OrganizacaoComponent, {
            autoFocus: false,
            width: '80vw',
            maxHeight: '100vh',
            data: {
                idOrganizacao: valor
            },
        }).afterClosed().subscribe(data => {
            if (data) {
                this.listarOrganizacoes();
            }
        });
    }

}
