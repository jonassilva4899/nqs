import { Component, OnInit } from '@angular/core';
import { QuickPanelNotificationService } from '../quick-panel/quick-panel-notification.service';

@Component({
    selector: 'app-notification',
    templateUrl: './notification.component.html',
    styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

    tokenComId: any;
    qtdNotificacao: number;
    constructor(
        private _notificationService: QuickPanelNotificationService,
        private _quickPanelService: QuickPanelNotificationService,
    ) {
        this._quickPanelService.quantidadeNotificacaoListener().subscribe(data => {
            this.qtdNotificacao = data;
        });
    }

    ngOnInit(): void {
        this.tokenComId = JSON.parse(localStorage.getItem('usuario'));

        if (this.tokenComId) {
            this._notificationService.getNotificacoesPorUsuario(this.tokenComId.id)
                .subscribe(data => {
                    this.qtdNotificacao = data.length;
                });
        }
    }

}
