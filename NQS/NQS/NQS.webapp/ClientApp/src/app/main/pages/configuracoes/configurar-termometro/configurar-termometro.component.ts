import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { ConfigurarTermometroService } from './configurar-termometro.service';

import { ListaCompetenciasComponent } from './lista-competencias/lista-competencias.component';
import { ImportarConfiguracoesCompetenciasComponent } from './importar-configuracoes-competencias/importar-configuracoes-competencias.component';
import { InfoCompetencias } from '@models/Competencia';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-configurar-termometro',
  templateUrl: './configurar-termometro.component.html',
  styleUrls: ['./configurar-termometro.component.scss']
})
export class ConfigurarTermometroComponent implements OnInit, OnDestroy {

    NivelPermissao = NivelPermissao;

    infoCompetencias: InfoCompetencias;

    isLoading = {
        infoCompetencias: false,
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _configurarTermometroService: ConfigurarTermometroService,
        private _matDialog: MatDialog,
        private _snackBar: SnackBar,
    ) { }

    ngOnInit(): void {
        this.getInfoCompetencias();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getInfoCompetencias(): void {
        this.isLoading.infoCompetencias = true;
        this._configurarTermometroService.getInfoCompetencias()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (infoCompetencias: any) => {
                    this.infoCompetencias = infoCompetencias;
                    this.isLoading.infoCompetencias = false;
                },
                (err: any) => {
                    this.isLoading.infoCompetencias = false;
                }
            );
    }

    abrirListaDeCompetencias(): void {
        const dialogRef = this._matDialog.open(ListaCompetenciasComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
        });
    }

    abrirImportacaoConfiguracoesCompetencias(): void {
        const dialogRef = this._matDialog.open(ImportarConfiguracoesCompetenciasComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: ['dialog-sm', 'dialog-with-close'],
            autoFocus: false,
        })
            .afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((result) => {
                if (result && result.atualizar) {
                    this.getInfoCompetencias();
                    this._snackBar.abrirSnackBar('Importação realizada com sucesso!', 'OK', 'green');
                }
            });
    }

}
