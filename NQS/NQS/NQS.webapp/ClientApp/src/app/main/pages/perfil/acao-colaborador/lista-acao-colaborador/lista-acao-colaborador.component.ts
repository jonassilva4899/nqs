import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatSort, MatTableDataSource, MAT_DIALOG_DATA, MatDialogRef, MatDialog, MatDialogConfig } from '@angular/material';
import { Observable } from 'rxjs';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { PerfilService } from '@pages/perfil/perfil.service';
import { EditaAcaoColaboradorComponent } from '../edita-acao-colaborador/edita-acao-colaborador.component';

import { AcoesColaborador } from '@models/AcoesColaborador';

@Component({
    selector: 'app-lista-acao-colaborador',
    templateUrl: './lista-acao-colaborador.component.html',
    styleUrls: ['./lista-acao-colaborador.component.scss'],
    animations: [
        trigger('detailExpand', [
            state('collapsed', style({height: '0px', minHeight: '0'})),
            state('expanded', style({height: '*'})),
            transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
        ]),
    ],
})
export class ListaAcaoColaboradorComponent implements OnInit {

    displayedColumns = [
        'data-acao',
        'nome-acao',
        'responsavel',
        'nome-criador',
        'estado',
        'acao'
    ];

    dataSource: MatTableDataSource<AcoesColaborador>;
    idPessoa: string;
    idResponsavel: string;
    atualizar = false;
    listaAcoes: Observable<AcoesColaborador[]>;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    constructor(
        private _perfilService: PerfilService,
        @Inject(MAT_DIALOG_DATA) private data,
        private _snackBar: SnackBar,
        private _dialogRef: MatDialogRef<ListaAcaoColaboradorComponent>,
        private _matDialog: MatDialog
    ) {
        this.idPessoa = data.idPessoa;
        this.idResponsavel = data.idResponsavel;
    }

    ngOnInit(): void {
        this.listarAcoesColaborador();
    }

    deletarAcaoColaborador(id): void {
        this.atualizar = true;
        this._perfilService.deletarAcaoColaborador(id)
            .subscribe((res: any) => {
                this._snackBar.abrirSnackBar('Ação colaborador removido com sucesso!', 'Ok');
                this._dialogRef.close(this.atualizar);
            }, (err) => {
                this._snackBar.abrirSnackBar('Falha ao remover acção do colaborador...', 'Ok');
                this._dialogRef.close(this.atualizar);
            });
    }

    formEditarAcao(idAcao): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {
            idPessoa: this.idPessoa,
            idAcao: idAcao
        };

        this._matDialog.open(EditaAcaoColaboradorComponent, dialogConfig)
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.listarAcoesColaborador();
                    }
                }
            );
    }

    listarAcoesColaborador(): void {
        this._perfilService.listaAcoesColaborador(this.idPessoa)
            .subscribe(
                data => {
                    this.dataSource = new MatTableDataSource<AcoesColaborador>(data);
                    this.dataSource.sort = this.sort;
                }
            );
    }

}
