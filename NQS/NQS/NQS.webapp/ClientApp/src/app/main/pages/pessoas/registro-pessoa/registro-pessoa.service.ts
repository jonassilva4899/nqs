import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { RegistroInfoGet } from 'app/models/RegistroInfoGet';
import { Observable } from 'rxjs';
import { UsuarioSocialConvite } from '@models/UsuarioSocialConvite';

@Injectable({
    providedIn: 'root'
})
export class RegistraPessoaService {

    baseUrl = environment.baseUrl;
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient
    ) { }

    getInfoParaAtivar(id: string, hash: string) {
        return this.http.get<RegistroInfoGet>(`${this.baseUrl}/Resposta/Convite/${id}/${hash}`);
    }

    postInfoParaAtivar(registro) {
        return this.http.post(`${this.baseUrl}/login`, registro, this.httpOptions);
    }

    postInfoParaSincronizarGoogle(registro: UsuarioSocialConvite): Observable<any> {
        return this.http.post<any>(`${this.baseUrl}/login/AssociarContaGoogle`, JSON.stringify(registro), this.httpOptions);
    }
}
