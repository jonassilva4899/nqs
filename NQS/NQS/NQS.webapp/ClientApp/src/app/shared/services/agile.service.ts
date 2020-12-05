import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PontuacaoPlanningPoker } from '@models/Agile';

@Injectable({
    providedIn: 'root'
})
export class AgileService {

    constructor(
        private http: HttpClient,
    ) {}

    getPontuacaoPlanningPoker(): Observable<PontuacaoPlanningPoker[]> {
        return new Observable((observer) => {
            const pontuacao = [
                { label: '01',  pontos: 1, },
                { label: '02',  pontos: 2, },
                { label: '03',  pontos: 3, },
                { label: '05',  pontos: 5, },
                { label: '08',  pontos: 8, },
                { label: '13',  pontos: 13, },
                { label: '20',  pontos: 20, },
                { label: '40',  pontos: 40, },
                { label: '100', pontos: 100, },
            ];
            observer.next(pontuacao);
            observer.complete();
        });
    }
}
