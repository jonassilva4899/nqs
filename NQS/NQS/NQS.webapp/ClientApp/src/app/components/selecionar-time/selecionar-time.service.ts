import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';

import { TimeDadosBasicos } from '@models/Times';
import { Organizacao } from '@models/Organizacao';

@Injectable({
    providedIn: 'root'
})
export class SelecionarTimeService {

    timeSelecionado = new BehaviorSubject<TimeDadosBasicos>(null);
    organizacaoSelecionada = new BehaviorSubject<Organizacao>(null);

    constructor(
        private http: HttpClient,
    ) {}

    setTimeNaStorage(time: TimeDadosBasicos): void {
        localStorage.setItem('timeSelecionado', JSON.stringify(time));
    }

    getTimeDaStorage(): TimeDadosBasicos {
        const time = localStorage.getItem('timeSelecionado');
        return JSON.parse(time);
    }

    deleteTimeDaStorage(): void {
        localStorage.removeItem('timeSelecionado');
    }

    getTimesDadosBasicos(idPessoa: string): Observable<TimeDadosBasicos[]> {
        return this.http.get<TimeDadosBasicos[]>(`${environment.baseUrl}/PraticaAgil/PegarTimesComFotoComboBox/${idPessoa}`);
    }

}
