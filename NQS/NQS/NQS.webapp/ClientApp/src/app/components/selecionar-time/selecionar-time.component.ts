import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { SelecionarTimeService } from './selecionar-time.service';
import { TimeService } from '@pages/times/time.service';
import { OrganizacaoService } from '../organizacao/organizacao.service';

import { TimesPerfil } from '@models/PegarTimePerfil';
import { TimeGrupo } from '@models/TimeDetalhe';
import { Organizacao } from '@models/Organizacao';
import { Usuario } from '@models/Usuario';
import { TimeDadosBasicos } from '@models/Times';

@Component({
    selector: 'app-selecionar-time',
    templateUrl: './selecionar-time.component.html',
    styleUrls: ['./selecionar-time.component.scss'],
})
export class SelecionarTimeComponent implements OnInit, OnDestroy {

    usuario: Usuario = new Usuario();
    organizacaoSelecionada = new Organizacao();
    listaTimes: TimeDadosBasicos[] = [];
    timeSelecionado = new FormControl('');

    tipoSelecionado: 'time' | 'grupo';

    exibirOrganizacaoRotas = ['/home', '/projetos'];
    exibirOpcaoOrganizacao = false;

    exibirGruposRotas = ['/home', '/pessoas', '/projetos', '/times'];
    exibirGrupos = false;

    listaGrupos: TimeGrupo[] = [];

    isLoading = {
        buscar: true,
    };

    gruposOpen: boolean;
    timesOpen: boolean;

    private _unsubscribeAll = new Subject();

    constructor(
        private _selecionarTimeService: SelecionarTimeService,
        private _timeService: TimeService,
        private _organizacaoService: OrganizacaoService,
        private _router: Router
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
        this._router.events
            .subscribe(data => {
                if (data instanceof NavigationEnd) {
                    this.exibirOpcaoOrganizacao = this.exibirOrganizacaoRotas.includes(this._router.url);
                    this.exibirGrupos = this.exibirGruposRotas.includes(this._router.url);

                    if (!this.exibirOpcaoOrganizacao && !this.exibirGrupos) {
                        this.atribuirUltimoTimeSelecionado();
                    }
                }
            });

        this.getPegarTimePerfil();
        this.getGrupos();

        this.timeSelecionado.valueChanges.subscribe((time: any) => {
            if (time) {
                if (time.id) {
                    this.tipoSelecionado = 'time';
                    this._selecionarTimeService.setTimeNaStorage(time);
                } else {
                    this.tipoSelecionado = 'grupo';
                }

                this._selecionarTimeService.timeSelecionado.next(time);
            } else {
                this._selecionarTimeService.deleteTimeDaStorage();
                this._selecionarTimeService.timeSelecionado.next(null);
            }
        });
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getGrupos(): void {
        if (!this.usuario) {
            return;
        }

        this.isLoading.buscar = true;
        this._timeService.getGrupos()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (listaGrupos: any) => {
                    this.isLoading.buscar = false;
                    this.listaGrupos = listaGrupos;
                },
                (err: any) => {
                    this.isLoading.buscar = false;
                },
            );
    }

    getPegarTimePerfil(): void {
        if (!this.usuario) {
            return;
        }

        this.isLoading.buscar = true;
        this._selecionarTimeService.getTimesDadosBasicos(this.usuario.idPessoa)
            .subscribe(
                (timesPerfil: TimeDadosBasicos[]) => {
                    this.listaTimes = timesPerfil;
                    this.selecionarTime();
                    this.isLoading.buscar = false;
                },
                (err) => {
                    this.isLoading.buscar = false;
                }
            );

        this._organizacaoService.selecionar(this.usuario.idOrganizacao)
            .subscribe(organizacao => {
                this.organizacaoSelecionada = organizacao;
                this._selecionarTimeService.organizacaoSelecionada.next(organizacao);
            });
    }

    selecionarTime(): void {
        let time = this._selecionarTimeService.getTimeDaStorage();

        if (time) {
            const findTime = this.listaTimes.find((t: TimesPerfil) => t.id === time.id);
            time = findTime;
        } else {
            time = this.listaTimes[0];
        }

        this.timeSelecionado.setValue(time);
    }

    atribuirUltimoTimeSelecionado(): void {
        const ultimoTimeSelecionado = this._selecionarTimeService.getTimeDaStorage();
        const time = this.listaTimes.find((t) => t.id === ultimoTimeSelecionado.id);

        if (time) {
            this.timeSelecionado.setValue(time);
        }
    }

    openedChange($event: boolean): void {
        const time = this.timeSelecionado.value;
        const idTime = time && time.id ? time.id : null;
        const idGrupo = time && time.idGrupo ? time.idGrupo : null;

        if ($event) {
            if (idTime) {
                this.timesOpen = true;
            }
            if (idGrupo) {
                this.gruposOpen = true;
            }
        }
    }

    irParaPaginaDoTime(time: TimeDadosBasicos): void {
        if (time && time.id) {
            this._router.navigate(['/times/detalhe', time.id]);
        }
    }

    nomeDoGrupoComoAvatar(time: TimeDadosBasicos): string {
        const words = time ? time.nome.split(' ') : ['TODOS'];
        let initials;

        if (words.length > 1) {
            initials = words.map(word => word.substring(0, 1));
            initials = initials.slice(-3).join('');
        } else {
            initials = words[0].substring(0, 2);
        }

        return initials.toUpperCase();
    }

}
