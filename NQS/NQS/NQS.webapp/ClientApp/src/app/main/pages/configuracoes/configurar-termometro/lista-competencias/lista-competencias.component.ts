import { Component, OnInit, ViewChild, Inject, OnDestroy } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatTableDataSource, MatSort, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { ConfirmaDeleteComponent } from 'app/components/confirma-delete/confirma-delete.component';

import { ConfigurarTermometroService } from '../configurar-termometro.service';
import { CompetenciaFormComponent } from '../competencia-form/competencia-form.component';
import { ListaQuestoesCompetenciaComponent } from '../lista-questoes-competencia/lista-questoes-competencia.component';

import { Competencia } from '@models/Competencia';
import { Acao } from '@models/Enums';

@Component({
    selector: 'app-lista-competencias',
    templateUrl: './lista-competencias.component.html',
    styleUrls: ['./lista-competencias.component.scss'],
    animations: [
        trigger('detailExpand', [
            state('collapsed', style({height: '0px', minHeight: '0'})),
            state('expanded', style({height: '*'})),
            transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
        ]),
    ],
})
export class ListaCompetenciasComponent implements OnInit, OnDestroy {

    Acao = Acao;
    listaCompetencias: Competencia[] = [];

    displayedColumns = [
        'nome',
        'acoes',
    ];

    dataSource: MatTableDataSource<any>;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    expandedElement: any;

    isLoading = {
        listaCompetencias: false,
        apagar: [],
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _configurarTermometroService: ConfigurarTermometroService,
        private _snackBar: SnackBar,
        private _matDialog: MatDialog,
        public dialogRef: MatDialogRef<ListaCompetenciasComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) { }

    ngOnInit(): void {
        this.getCompetencias();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getCompetencias(): void {
        this.isLoading.listaCompetencias = true;
        this._configurarTermometroService.getCompetencias()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (competencias: Competencia[]) => {
                    this.listaCompetencias = competencias;
                    this.dataSource = new MatTableDataSource<Competencia>(this.listaCompetencias);
                    this.dataSource.sort = this.sort;
                    this.isLoading.listaCompetencias = false;
                },
                (err: any) => {
                    this._snackBar.abrirSnackBar('Falha ao buscar competências', 'OK', 'red');
                    this.isLoading.listaCompetencias = false;
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

    abrirFormCompetencia(acao: Acao, competencia?: Competencia): void {
        this.dialogRef.close();

        const dialogRef = this._matDialog.open(CompetenciaFormComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                acao,
                competencia,
            }
        });

        dialogRef
            .afterClosed()
            .subscribe((result) => {
                this.abrirListaDeCompetencias();
            });
    }

    abrirListaQuestoesCompetencia(competencia: Competencia): void {
        this.dialogRef.close();

        const dialogRef = this._matDialog.open(ListaQuestoesCompetenciaComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                competencia,
            }
        });

        dialogRef
            .afterClosed()
            .subscribe((result) => {
                const naoAbrirCompetencias = result && result.hasOwnProperty('naoAbrirCompetencias');
                if (!result && !naoAbrirCompetencias) {
                    this.abrirListaDeCompetencias();
                }
            });
    }

    apagarCompetencia(competencia: Competencia, i: number, event: Event): void {
        event.stopPropagation();

        this._matDialog.open(ConfirmaDeleteComponent, {
            data: {
                notificacaoDetalhe: {
                    titulo: `Deseja apagar a competência ${competencia.nome}?`,
                    detalhes: '',
                }
            }
        }).afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(data => {
                if (data) {
                    this.isLoading.apagar[i] = true;

                    this._configurarTermometroService.apagarCompetencia(competencia)
                        .pipe(takeUntil(this._unsubscribeAll))
                        .subscribe(
                            (res: any) => {
                                this.listaCompetencias.splice(i, 1);
                                this.dataSource.data = this.listaCompetencias;
                                this.isLoading.apagar[i] = false;
                            },
                            (err: any) => {
                                this.isLoading.apagar[i] = false;
                                this._snackBar.abrirSnackBar('Falha ao apagar competência...', 'OK', 'red');
                            },
                        );
                }
            }
        );
    }

}
