import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Overlay } from '@angular/cdk/overlay';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { TimeService } from './time.service';
import { CriaTimeFormComponent } from './cria-time-form/cria-time-form.component';

import { Times, FiltroTimes, TimeDadosBasicos } from '@models/Times';
import { TermometroAgilEnum } from '@models/Enums';
import { ListaFiltroPessoas } from '@models/Pessoa';
import { ProjetoDadosBasicos } from '@models/Projeto';
import { NivelPermissao } from '@models/Permissoes';


@Component({
    selector: 'times',
    templateUrl: './times.component.html',
    styleUrls: ['./times.component.scss']
})
export class TimesComponent implements OnInit, OnDestroy {

    NivelPermissao = NivelPermissao;
    TermometroAgilEnum = TermometroAgilEnum;
    TermometroAgil = Object.keys(TermometroAgilEnum);

    listaTimes: Times;
    listaGrupos: Array<any> = [];
    listaProjetos: ProjetoDadosBasicos[] = [];
    listaClientes: ListaFiltroPessoas[] = [];
    listaTemperaturas: Array<any> = [];

    filtros: FormGroup = this._fb.group({
        idGrupo: '',
        idProjeto: '',
        idCliente: '',
        temperatura: '',
    });

    isLoading = {
        filtros: false,
        listaTimes: false,
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _timeService: TimeService,
        private _matDialog: MatDialog,
        private _overlay: Overlay,
        private _fb: FormBuilder,
    ) { }

    ngOnInit(): void {
        this.getGrupos();
        //this.getProjetos();
        this.getClientes();

        //this.getTimeSelecionado();

        this.pegarTimes(this.filtros.value);
        this.filtros.valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((valor) => {
                this.isLoading.filtros = true;
                this.pegarTimes(valor);
            });
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getTimeSelecionado(): void {
        this._timeService.timeSelecionado()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((timeSelecionado: TimeDadosBasicos) => {
                const time: any = timeSelecionado;
                const idGrupo = time && time.idGrupo ? time.idGrupo : '';

                this.filtros.get('idGrupo').setValue(idGrupo);
            });
    }

    pegarTimes(filtros: FiltroTimes): void {
        this.isLoading.listaTimes = true;
        this._timeService.pegarTimes(filtros)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (times: Times) => {
                    this.listaTimes = times;
                    this.isLoading.filtros = false;
                    this.isLoading.listaTimes = false;
                },
                (err: any) => {
                    this.isLoading.filtros = false;
                    this.isLoading.listaTimes = false;
                }
            );
    }

    adicionarTime(): void {
        const scrollStrategy = this._overlay.scrollStrategies.reposition();

        const dialogRef = this._matDialog.open(CriaTimeFormComponent, {
            panelClass: 'timee-form-dialog',
            scrollStrategy
        });

        dialogRef.afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                data => {
                    if (data) {
                        this.pegarTimes(this.filtros.value);
                    }
                }
            );
    }

    getGrupos(): void {
        this._timeService.getGrupos()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (grupos: any) => {
                    this.listaGrupos = grupos;
                }
            );
    }

    //getProjetos(): void {
    //    this._timeService.getProjetos()
    //        .pipe(takeUntil(this._unsubscribeAll))
    //        .subscribe(
    //            (projetos: ProjetoDadosBasicos[]) => {
    //                this.listaProjetos = projetos;
    //            }
    //        );
    //}

    getClientes(): void {
        this._timeService.getClientes()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (clientes: ListaFiltroPessoas[]) => {
                    this.listaClientes = clientes;
                }
            );
    }

}
