import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, BehaviorSubject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';
import { Usuario } from 'app/models/Usuario';
import { SocialUser } from 'angularx-social-login';

@Injectable({
    providedIn: 'root',
})
export class LoginService {
    public usuarioLogado: Observable<Usuario>;
    private usuarioLogadoSubject: BehaviorSubject<Usuario>;
    baseUrl = environment.baseUrl;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) {
        this.usuarioLogadoSubject = new BehaviorSubject<Usuario>(JSON.parse(localStorage.getItem('usuario')));
        this.usuarioLogado = this.usuarioLogadoSubject.asObservable();
    }

    public get usuarioLogadoDados(): Usuario {
        return this.usuarioLogadoSubject.value;
    }

    login(usuario, senha): any {
        return this.http.post<any>(`${this.baseUrl}/Token`, { usuario, senha })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('usuario', JSON.stringify(user));
                this.usuarioLogadoSubject.next(user);
                return user;
            }));
    }

    logout(): void {
        // remove user from local storage and set current user to null
        localStorage.removeItem('usuario');
        localStorage.removeItem('timeSelecionado');
        this.usuarioLogadoSubject.next(null);
    }

    recuperarSenha(emailParaRecuperar) {
        return this.http.post(`${this.baseUrl}/Login/RecuperarSenha`, emailParaRecuperar, this.httpOptions);
    }

    redefinirSenha(param) {
        return this.http.post(`${this.baseUrl}/Login/ValidarRecuperarSenha`, param, this.httpOptions);
    }

    logInComGoogle(usuario: SocialUser): any {
        return this.http.post<any>(`${environment.baseUrl}/Token/LoginComGoogle`, JSON.stringify(usuario), this.httpOptions)
            .pipe(map(user => {
                localStorage.setItem('usuario', JSON.stringify(user));
                this.usuarioLogadoSubject.next(user);
                return user;
            }));
    }
}
