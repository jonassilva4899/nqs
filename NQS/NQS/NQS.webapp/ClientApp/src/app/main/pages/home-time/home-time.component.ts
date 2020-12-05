import { Component, OnInit, OnDestroy } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Subscription, Subject } from 'rxjs';


import { TimesPerfil } from '@models/PegarTimePerfil';
import { fuseAnimations } from '@fuse/animations';
import { MovimentacaoCapacity, PraticaAgilChave } from '@models/Enums';
import { HomeTimeService } from './home-time.service';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-home-time',
  templateUrl: './home-time.component.html',
  styleUrls: ['./home-time.component.scss'],
  animations: fuseAnimations
})
export class HomeTimeComponent implements OnInit, OnDestroy {

    NivelPermissao = NivelPermissao;
    PraticaAgilChave = PraticaAgilChave;

    timeSelecionado: TimesPerfil;
    subscription: Subscription = new Subscription();
    tipoMovCapacity = MovimentacaoCapacity;
    praticasConfiguradas: string[];

    temENPS = true;

    private _unsubscribeAll = new Subject();

    constructor(
        private _homeTimeService: HomeTimeService,
        private _snackBar: SnackBar,
    ) { }

    ngOnInit(): void {
        //this.getTimeSelecionado();
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    //getTimeSelecionado(): void {
    //    this._praticasAgeisService.timeSelecionado()
    //        .pipe(takeUntil(this._unsubscribeAll))
    //        .subscribe((time: TimesPerfil) => {
    //            this.timeSelecionado = time;
    //            this.pegarPraticasConfiguradas();
    //        });
    //}

    pegarPraticasConfiguradas(): void {
        this.praticasConfiguradas = [];

        this._homeTimeService.pegaPraticasConfiguradas(this.timeSelecionado)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (data: string[]) => {
                    this.praticasConfiguradas = data;
                },
                (err: any) => {
                    this._snackBar.abrirSnackBar('Falha ao buscar práticas configuradas do time...', 'OK', 'red');
                }
            );
    }

}
