import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { PessoasService } from './pessoas.service';
import { PessoaFormDialogComponent } from './pessoa-form/pessoa-form.component';

import { FiltrosPessoas, ListaFiltroPessoas } from '@models/Pessoa';
import { ListaPessoas } from '@models/PessoaModel';
import { HabilidadesPerfil } from '@models/HabilidadesPerfil';
import { NivelPermissao } from '@models/Permissoes';
import { TimeDadosBasicos } from '@models/Times';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
    selector: 'pessoas',
    templateUrl: './pessoas.component.html',
    styleUrls: ['./pessoas.component.scss']
})
export class PessoasComponent implements OnInit, OnDestroy {

    NivelPermissao = NivelPermissao;

    dialogRef: any;
    actions: [];
    listaPessoas: ListaPessoas[] = [];
    listaPessoas$: Subscription = new Subscription();
    listaTimes$: Observable<ListaFiltroPessoas[]>;
    listaClientes$: Observable<ListaFiltroPessoas[]>;
    listaResponsaveis$: Observable<ListaFiltroPessoas[]>;
    listaHabilidades$: Observable<HabilidadesPerfil[]>;
    listaHabilidade: HabilidadesPerfil[];
    filtroListaHabilidade: HabilidadesPerfil[];

    filtros: FormGroup;

    isLoading = {
        listaPessoas: false,
    };

    private _unsubscribeAll: Subject<any> = new Subject();

    constructor(
        private _matDialog: MatDialog,
        private _pessoaService: PessoasService,
        private _fb: FormBuilder,
    ) {
        this.filtros = this._fb.group({
            nomeColaborador: '',
            idTime: '',
            idGrupo: '',
            idCliente: '',
            idResponsavel: '',
            status: '',
            habilidade: '',
            comecaCom: 0,
            terminaCom: 14,
            idPessoaLogada: JSON.parse(localStorage.getItem('usuario')).idPessoa,
        });

        this.listaTimes$ = this._pessoaService.listarTimesFiltro();
        this.listaClientes$ = this._pessoaService.listarClientesFiltro();
        this.listaResponsaveis$ = this._pessoaService.listarResponsaveisFiltro();
        this.listaHabilidades$ = this._pessoaService.listarHabilidadesFiltro();
        this.listaHabilidades$.subscribe(data => {
            this.listaHabilidade = data;
            this.filtroListaHabilidade = data;
        });
    }

    ngOnInit(): void {
        this.filtros.valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((value) => {
                this.listarPessoas();
            });

        //this.getTimeSelecionado();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getTimeSelecionado(): void {
        this._pessoaService.timeSelecionado()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((timeSelecionado: TimeDadosBasicos) => {
                const time: any = timeSelecionado;
                const idTime = time && time.id ? time.id : '';
                const idGrupo = time && time.idGrupo ? time.idGrupo : '';

                this.filtros.patchValue({
                    idTime,
                    idGrupo,
                });
            });
    }

    listarPessoas(): void {
        const filtros = this.filtros.getRawValue();

        this.isLoading.listaPessoas = true;
        this.listaPessoas$.unsubscribe();
        this.listaPessoas$ = this._pessoaService.listarPessoas(filtros)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                data => {
                    this.listaPessoas = data;
                    this.isLoading.listaPessoas = false;
                },
                err => {
                    this.isLoading.listaPessoas = false;
                }
            );
    }

    adicionarPessoa(): void {
        this.dialogRef = this._matDialog.open(PessoaFormDialogComponent, {
            panelClass: 'pessoa-form-dialog',
            data: {
                action: 'novaPessoa',
            }
        });

        this.dialogRef.afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(data => {
                if (data) {
                    this.filtros.get('comecaCom').setValue(0);
                    this.filtros.get('terminaCom').setValue(14);

                    this.listarPessoas();
                }
            });
    }

}
