import { Component, OnInit, ViewChild, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { Observable } from 'rxjs';

import { TratarStringService } from '@shared/services/tratar-string.service';
import { TimeService } from '../../time.service';

import { AdicionaMembroFormComponent } from '../adiciona-membro-form/adiciona-membro-form.component';
import { ConfirmaDeleteComponent } from 'app/components/confirma-delete/confirma-delete.component';

import { NotificacaoDelete } from '@models/ConfirmaDelete';
import { Usuario } from '@models/Usuario';
import { NivelPermissao } from '@models/Permissoes';
import { TimeDetalhe, Membros } from '@models/TimeDetalhe';

export interface MembrosDados {
    nome: string;
    papel: string;
    informacao: string;
}

@Component({
    selector: 'card-membros-time',
    styleUrls: ['card-membros-time.component.scss'],
    templateUrl: 'card-membros-time.component.html',
})
export class CardMembrosTimeComponent implements OnInit, OnChanges {

    NivelPermissao = NivelPermissao;

    idRoute: string;
    colunasExibir: string[] = ['nome', 'papel', 'informacao'];
    dadosMembros: MatTableDataSource<Membros>;
    listaMembros: Membros[] = [];
    actions: [];
    tokenPessoa: Usuario = new Usuario();
    private dialogRef: any;
    receberDetalheTime$: Observable<TimeDetalhe>;

    @Input() idTime: string;

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    constructor(
        private _matDialog: MatDialog,
        private _snackBar: SnackBar,
        private route: ActivatedRoute,
        private _timeService: TimeService) {
        this.tokenPessoa = JSON.parse(localStorage.getItem('usuario'));
    }


    ngOnInit(): void {
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.idRoute = this.route.snapshot.params['id'];

        this._timeService.pegaTimeEspecifico(this.idTime).subscribe(
            data => {
                this.listaMembros = data.objeto.membros;
                this.dadosMembros = new MatTableDataSource<Membros>(this.listaMembros);
                this.dadosMembros.paginator = this.paginator;
                this.dadosMembros.sort = this.sort;
                this.dadosMembros.filterPredicate = (d, filter) => {
                    return !filter || TratarStringService.busca(JSON.stringify(d)).includes(filter);
                };
            });

        this.paginator._intl.itemsPerPageLabel = 'Membros por página';
        this.paginator._intl.getRangeLabel = coberturaMembros;
    }

    aplicaFiltro(filterValue: string): void {
        this.dadosMembros.filter = TratarStringService.busca(filterValue);

        if (this.dadosMembros.paginator) {
            this.dadosMembros.paginator.firstPage();
        }
    }

    adicionarMembro(): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.autoFocus = false;
        dialogConfig.data = {
            idRoute: this.idRoute
        };

        this.dialogRef = this._matDialog.open(AdicionaMembroFormComponent, dialogConfig);
        this.dialogRef.afterClosed()
            .subscribe(() => {
                this.buscaListaDeMembros();
            });
    }

    buscaListaDeMembros(): void {
        this._timeService.pegaTimeEspecifico(this.idTime).subscribe(
            data => {
                this.listaMembros = data.objeto.membros;
                this.dadosMembros = new MatTableDataSource<Membros>(this.listaMembros);
                this.dadosMembros.paginator = this.paginator;
                this.dadosMembros.sort = this.sort;
            }
        );

        this.paginator._intl.itemsPerPageLabel = 'Membros por página';
        this.paginator._intl.getRangeLabel = coberturaMembros;
    }

    editaMembro(membro: Membros): void {
        this._matDialog.open(AdicionaMembroFormComponent, {
            data: {
                edicao: true,
                membro: membro,
                idRoute: this.idRoute
            }
        }).afterClosed().subscribe(
            data => {
                if (data) {
                    this.buscaListaDeMembros();
                }
            });
    }

    deletaMembro(membro: Membros): void {
        const deleteModelo: NotificacaoDelete = new NotificacaoDelete();
        deleteModelo.titulo = 'Deseja mesmo deletar o membro do time?';
        deleteModelo.detalhes = 'Ao confirmar a solicitação, o membro selecionado será removido do time...';
        this._matDialog.open(ConfirmaDeleteComponent, {
            data: {
                notificacaoDetalhe: deleteModelo
            }
        }).afterClosed().subscribe(
            data => {
                if (data) {
                    membro.idTime = this.idTime;
                    membro.idResponsavelEdicao = this.tokenPessoa.idPessoa;
                    this._timeService.removerMembroTime(JSON.stringify(membro))
                        .subscribe(
                            () => {
                                this.buscaListaDeMembros();
                                this._snackBar.abrirSnackBar('Membro removido do time com sucesso!', 'Ok');
                            },
                            err => {
                                this._snackBar.abrirSnackBar('Falha ao remover membro do time...', 'Ok');
                            }
                        );
                }
            }
        );
    }
}

export const coberturaMembros = (pagina: number, tamanhoPagina: number, qtd: number) => {
    if (qtd === 0 || tamanhoPagina === 0) { return `0 até ${qtd}`; }

    qtd = Math.max(qtd, 0);

    const startIndex = pagina * tamanhoPagina;

    const endIndex = startIndex < qtd ?
        Math.min(startIndex + tamanhoPagina, qtd) : startIndex + tamanhoPagina;

    return `${startIndex + 1} - ${endIndex} até ${qtd}`;
};
