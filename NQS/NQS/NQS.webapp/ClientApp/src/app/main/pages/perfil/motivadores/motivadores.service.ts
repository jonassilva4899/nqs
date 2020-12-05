import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';

import { Motivador, Motivadores, MotivadoresPUT } from '@models/Motivadores';
import { Usuario } from '@models/Usuario';

@Injectable({
    providedIn: 'root',
})
export class MotivadoresService {

    usuario: Usuario;

    constructor(
        private http: HttpClient,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    getMotivadoresPessoa(idPessoa: string): Observable<Motivadores> {
        return this.http.get<Motivadores>(`${environment.baseUrl}/Pessoa/PegarMotivadores/${idPessoa}`);
    }

    putMotivadoresPessoa(motivadores: Motivador[], idPessoa: string): Observable<string> {
        const body: MotivadoresPUT = {
            idPessoa,
            idResponsavelEdicao: this.usuario.idPessoa,
            motivadoresEditados: motivadores.map((motivador: Motivador, i: number) => (
                {
                    idMotivador: motivador.id,
                    indice: i + 1,
                }
            ))
        };

        return this.http.put<string>(`${environment.baseUrl}/Pessoa/EditarMotivadores/${idPessoa}`, body)
            .pipe(
                retry(5)
            );
    }

    adicionarMotivadoresPessoa(idPessoa: string): Observable<any> {
        const body = {
            idPessoa: idPessoa,
            idResponsavelCriacao: this.usuario.idPessoa,
        };
        return this.http.post<any>(`${environment.baseUrl}/Pessoa/AdicionarMotivadores`, body);
    }

}
