import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { NotificacoesUsuario } from 'app/models/NotificacoesUsuario';
import { ObservableLike, Observable, BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class QuickPanelNotificationService {

    baseUrl = environment.baseUrl;
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }

    private qtdNotificacaoEvento = new BehaviorSubject<number>(0);

    emitQuantidadeNotificacao(qtd: number): void {
        this.qtdNotificacaoEvento.next(qtd);
    }

    quantidadeNotificacaoListener(): Observable<number> {
        return this.qtdNotificacaoEvento.asObservable();
    }

    getNotificacoesPorUsuario(idUsuario): Observable<NotificacoesUsuario[]> {
        return this.http.get<NotificacoesUsuario[]>(`${this.baseUrl}/notificacao/NaoLidas/${idUsuario}`);
    }

    lerNotificacao(id: string): Observable<any> {
        return this.http.get<any>(`${this.baseUrl}/notificacao/LerNotificacao/${id}`);
    }

    lerTodasNotificacoes(idUsuario: string): Observable<any> {
        return this.http.get<any>(`${this.baseUrl}/notificacao/LerTodasNotificacoes/${idUsuario}`);
    }

}
