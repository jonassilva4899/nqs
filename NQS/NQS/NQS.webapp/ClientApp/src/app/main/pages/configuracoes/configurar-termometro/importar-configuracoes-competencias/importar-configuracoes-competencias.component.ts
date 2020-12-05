import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { ConfigurarTermometroService } from '../configurar-termometro.service';

import { OrganizacaoDadosBasicos } from '@models/Organizacao';

@Component({
  selector: 'app-importar-configuracoes-competencias',
  templateUrl: './importar-configuracoes-competencias.component.html',
  styleUrls: ['./importar-configuracoes-competencias.component.scss']
})
export class ImportarConfiguracoesCompetenciasComponent implements OnInit, OnDestroy {

    organizacao = new FormControl('', [Validators.required]);
    listaOrganizacoes: OrganizacaoDadosBasicos[] = [];

    isLoading = {
        salvar: false,
        listaOrganizacoes: false,
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _configurarTermometroService: ConfigurarTermometroService,
        private _snackBar: SnackBar,
        public dialogRef: MatDialogRef<ImportarConfiguracoesCompetenciasComponent>,
    ) {
    }

    ngOnInit(): void {
        this.getOrganizacoes();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getOrganizacoes(): void {
        this.isLoading.listaOrganizacoes = true;
        this._configurarTermometroService.getOrganizacoesComCompetencias()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (organizacoes: OrganizacaoDadosBasicos[]) => {
                    this.listaOrganizacoes = organizacoes;
                    this.isLoading.listaOrganizacoes = false;
                },
                (err: any) => {
                    this.isLoading.listaOrganizacoes = false;
                    this._snackBar.abrirSnackBar('Falha ao buscar organizações...', 'OK', 'red');
                },
            );
    }

    importarConfiguracoesCompetencias(): void {
        if (this.organizacao.invalid) {
            this.organizacao.markAllAsTouched();
            return;
        }

        const formData = this.organizacao.value;
        this.isLoading.salvar = true;
        this._configurarTermometroService.importarConfiguracoesCompetencias(formData)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (res: any) => {
                    this.isLoading.salvar = false;
                    this.dialogRef.close({atualizar: true});
                },
                (err: any) => {
                    this.isLoading.salvar = false;
                    this._snackBar.abrirSnackBar('Falha ao importar configurações...', 'OK', 'red');
                },
            );
    }

}
