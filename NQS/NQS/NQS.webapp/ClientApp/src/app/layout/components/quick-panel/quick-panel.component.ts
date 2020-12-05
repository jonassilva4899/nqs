import { Component, OnInit, ViewEncapsulation, DoCheck } from '@angular/core';
import { Observable } from 'rxjs';
import { NotificacoesUsuario } from 'app/models/NotificacoesUsuario';
import { QuickPanelNotificationService } from './quick-panel-notification.service';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { map } from 'rxjs/operators';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
    selector: 'quick-panel',
    templateUrl: './quick-panel.component.html',
    styleUrls: ['./quick-panel.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: [
        trigger('slideInOut', [
            transition(':enter', [
                style({ transform: 'translateX(100%)' }),
                animate('300ms ease-in', style({ transform: 'translateX(0%)' }))
            ]),
            transition(':leave', [
                animate('300ms ease-in', style({ transform: 'translateX(100%)' }))
            ])
        ])
    ]
})
export class QuickPanelComponent implements OnInit, DoCheck {
    date: Date;
    events: any[];
    notes: any[];
    settings: any;
    tokenComId: any;
    listaNotificacoes: NotificacoesUsuario[];
    executou = false;

    constructor(
        private _notificacaoService: QuickPanelNotificationService,
        private _snackbar: SnackBar, ) {
        this.date = new Date();
        this.settings = {
            notify: true,
            cloud: false,
            retro: true
        };
    }

    ngOnInit(): void {
        this.tokenComId = JSON.parse(localStorage.getItem('usuario'));
    }

    lerNotificacao(id: string, index: number): void {
        this._notificacaoService.lerNotificacao(id).subscribe(
            () => {
                this.listaNotificacoes.splice(index, 1);
                this._notificacaoService.emitQuantidadeNotificacao(this.listaNotificacoes.length);
            },
            err => {
                this._snackbar.abrirSnackBar('Falha ao ler notificação', 'Ok', 'red');
            });
    }

    lerTodas(): void {
        this._notificacaoService.lerTodasNotificacoes(this.tokenComId.id).subscribe(
            () => {
                this.listaNotificacoes = [];
                this._notificacaoService.emitQuantidadeNotificacao(this.listaNotificacoes.length);
            },
            err => {
                this._snackbar.abrirSnackBar('Falha ao limpar notificações', 'Ok', 'red');
            });
    }

    ngDoCheck(): void {
        this.pegarNotificacoesNaoLidas();
    }

    pegarNotificacoesNaoLidas(): void {
        if (this.tokenComId && !this.executou) {
            this.executou = true;
            this._notificacaoService.getNotificacoesPorUsuario(this.tokenComId.id).subscribe(
                data => {
                    this.listaNotificacoes = data;
                },
                err => {
                    this._snackbar.abrirSnackBar('Falha ao buscar notificações', 'Ok', 'red');
                }
            );
        }
    }
}
