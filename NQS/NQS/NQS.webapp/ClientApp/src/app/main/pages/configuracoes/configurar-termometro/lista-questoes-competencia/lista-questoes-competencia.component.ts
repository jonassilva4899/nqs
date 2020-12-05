import { Component, OnInit, ViewChild, Inject, OnDestroy } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatTableDataSource, MatSort, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { ConfirmaDeleteComponent } from 'app/components/confirma-delete/confirma-delete.component';

import { ConfigurarTermometroService } from '../configurar-termometro.service';
import { ListaCompetenciasComponent } from '../lista-competencias/lista-competencias.component';
import { QuestaoCompetenciaFormComponent } from '../questao-competencia-form/questao-competencia-form.component';

import { Competencia, QuestaoCompetencia, TemperaturaTermometroEnum } from '@models/Competencia';
import { Acao } from '@models/Enums';

@Component({
    selector: 'app-lista-questoes-competencia',
    templateUrl: './lista-questoes-competencia.component.html',
    styleUrls: ['./lista-questoes-competencia.component.scss'],
    animations: [
        trigger('detailExpand', [
            state('collapsed', style({height: '0px', minHeight: '0'})),
            state('expanded', style({height: '*'})),
            transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
        ]),
    ],
})
export class ListaQuestoesCompetenciaComponent implements OnInit, OnDestroy {

    Acao = Acao;
    TemperaturaTermometroEnum = TemperaturaTermometroEnum;
    competencia: Competencia;
    listaQuestoes: QuestaoCompetencia[] = [];

    displayedColumns = [
        'tituloQuestao',
        'acoes',
    ];

    dataSource: MatTableDataSource<any>;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    expandedElement: any;

    isLoading = {
        listaQuestoes: false,
        apagar: [],
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _configurarTermometroService: ConfigurarTermometroService,
        private _snackBar: SnackBar,
        private _matDialog: MatDialog,
        public dialogRef: MatDialogRef<ListaCompetenciasComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) {
        this.competencia = data.competencia;
    }

    ngOnInit(): void {
        this.getQuestoesCompetencia();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getQuestoesCompetencia(): void {
        this.isLoading.listaQuestoes = true;
        this._configurarTermometroService.getQuestoesCompetencia(this.competencia)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (questoes: QuestaoCompetencia[]) => {
                    this.listaQuestoes = questoes;
                    this.dataSource = new MatTableDataSource<QuestaoCompetencia>(this.listaQuestoes);
                    this.dataSource.sort = this.sort;
                    this.isLoading.listaQuestoes = false;
                },
                (err: any) => {
                    this._snackBar.abrirSnackBar('Falha ao buscar questões...', 'OK', 'red');
                    this.isLoading.listaQuestoes = false;
                }
            );
    }

    retornaDescricaoTemperatura(questao: QuestaoCompetencia, temperatura: TemperaturaTermometroEnum): string {
        const temperaturaQuestao = questao.questaoOpcoes.find((temp) => temp.temperaturaTermometro === temperatura);
        return temperaturaQuestao.descricao;
    }

    apagarQuestaoCompetencia(questaoCompetencia: QuestaoCompetencia, i: number, event: Event): void {
        event.stopPropagation();

        this._matDialog.open(ConfirmaDeleteComponent, {
            data: {
                notificacaoDetalhe: {
                    titulo: `Deseja apagar a questão ${questaoCompetencia.tituloQuestao}?`,
                    detalhes: '',
                }
            }
        }).afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(data => {
                if (data) {
                    this.isLoading.apagar[i] = true;

                    this._configurarTermometroService.apagarQuestaoCompetencia(questaoCompetencia)
                        .pipe(takeUntil(this._unsubscribeAll))
                        .subscribe(
                            (res: any) => {
                                this.listaQuestoes.splice(i, 1);
                                this.dataSource.data = this.listaQuestoes;
                                this.isLoading.apagar[i] = false;
                            },
                            (err: any) => {
                                this.isLoading.apagar[i] = false;
                                this._snackBar.abrirSnackBar('Falha ao apagar questão...', 'OK', 'red');
                            },
                        );
                }
            }
        );
    }

    abrirFormQuestao(acao: Acao, questaoCompetencia?: QuestaoCompetencia): void {
        this.dialogRef.close({naoAbrirCompetencias: true});

        const dialogRef = this._matDialog.open(QuestaoCompetenciaFormComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                acao,
                questaoCompetencia,
                competencia: this.competencia,
            }
        });

        dialogRef
            .afterClosed()
            .subscribe((result) => {
                this.abrirListaQuestoesCompetencia(this.competencia);
            });
    }

    abrirListaQuestoesCompetencia(competencia: Competencia): void {
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

    abrirListaDeCompetencias(): void {
        const dialogRef = this._matDialog.open(ListaCompetenciasComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
        });
    }

}
