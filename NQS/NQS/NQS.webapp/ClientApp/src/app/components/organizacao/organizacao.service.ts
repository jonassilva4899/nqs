import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Organizacao } from '@models/Organizacao';
import { Usuario } from '@models/Usuario';

@Injectable({
    providedIn: 'root'
})
export class OrganizacaoService {

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) {

    }

    adicionarEditar(organizacao): Observable<any> {
        return this.http.post<any>(`${environment.baseUrl}/Organizacao`, organizacao, this.httpOptions);
    }

    listar(idPessoa): Observable<Organizacao[]> {
        return this.http.get<Organizacao[]>(`${environment.baseUrl}/Organizacao/Listar/${idPessoa}`);
    }

    selecionar(idOrganizacao): Observable<Organizacao> {
        return this.http.get<Organizacao>(`${environment.baseUrl}/Organizacao/Selecionar/${idOrganizacao}`);
    }

    novoToken(solicitacao): Observable<Usuario>{
        return this.http.post<Usuario>(`${environment.baseUrl}/Token/TrocarOrganizacao`, solicitacao, this.httpOptions);
    }
}
