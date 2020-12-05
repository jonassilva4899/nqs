import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';
import { TimeDadosBasicos } from '@models/Times';

@Injectable({
  providedIn: 'root'
})
export class HomeTimeService {

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) { }

    pegaPraticasConfiguradas(timeSelecionado: TimeDadosBasicos): Observable<string[]> {
        const time = timeSelecionado;
        return this.http.get<string[]>(`${environment.baseUrl}/Home/PraticasConfiguradas/${time && time.id ? time.id : ''}`);
    }
}
