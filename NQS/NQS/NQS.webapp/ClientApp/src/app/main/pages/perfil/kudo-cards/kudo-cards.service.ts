import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { PessoasService } from '@pages/pessoas/pessoas.service';
import { TimeService } from '@pages/times/time.service';

import { KudoCard, KudoCardID, KudoCardDados, EnvioKudoCard, KudoCardsNumeros, KudoCardEnviadosRecebidos } from '@models/KudoCard';
import { TimeDadosBasicos } from '@models/Times';
import { PessoaDados } from '@models/Pessoa';
import { Usuario } from '@models/Usuario';

@Injectable({
    providedIn: 'root'
})
export class KudoCardsService {

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    usuario: Usuario;
    imagesPath = 'https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=';

    constructor(
        private _http: HttpClient,
        private _domSanitizer: DomSanitizer,
        private _pessoaService: PessoasService,
        private _timeService: TimeService,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    getKudoCards(): Observable<KudoCard[]> {
        const kudoCards: KudoCard[] = [
            {
                id: KudoCardID.ObrigadoPelaForca,
                nome: 'Obrigado pela força!',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_obrigado-pela-forca.svg`),
            },
            {
                id: KudoCardID.ParabensMestre,
                nome: 'Parabéns mestre!',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_parabens-mestre.svg`),
            },
            {
                id: KudoCardID.QueMaravilha,
                nome: 'Que maravilha!',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_que-maravilha.svg`),
            },
            {
                id: KudoCardID.QueTrabalhoIncrivel,
                nome: 'Que trabalho incrível!',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_que-trabalho-incrivel.svg`),
            },
            {
                id: KudoCardID.VoceEImbativel,
                nome: 'Voce é imbatível',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_voce-e-imbativel.svg`),
            },
            {
                id: KudoCardID.SuperTrabalho,
                nome: 'Super trabalho!',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_super-trabalho.svg`),
            },
            {
                id: KudoCardID.TimePoderoso,
                nome: 'Time poderoso',
                imagem: sanitizer.call(this, `${this.imagesPath}kudocard_time-poderoso.svg`),
            },
        ];

        function sanitizer(img): any {
            return this._domSanitizer.bypassSecurityTrustResourceUrl(img);
        }

        return new Observable((observer) => {
            observer.next(kudoCards);
            observer.complete();
        });
    }

    getKudoCard(kudoCardID: number): Observable<KudoCard> {
        return new Observable((observer) => {
            this.getKudoCards().subscribe((kudoCards) => {
                observer.next(kudoCards.find((kudoCard) => kudoCard.id === kudoCardID));
                observer.complete();
            });
        });
    }

    getPessoas(): Observable<PessoaDados[]> {
        return this._timeService.pegarUsuarioAtivosNaoInclusivo(this.usuario.idPessoa);
    }

    getTimes(): Observable<TimeDadosBasicos[]> {
        return this._pessoaService.listarTimesFiltro();
    }

    enviarKudoCard(kudoCardForm: EnvioKudoCard): Observable<any> {
        console.log(kudoCardForm);

        return this._http.post<any>(`${environment.baseUrl}/KudoCard/Enviar`, JSON.stringify(kudoCardForm), this.httpOptions);
        // return new Observable((observer) => {
        //     this.listaKudoCards.push(body);
        //     observer.next(body);
        //     observer.complete();
        // });
    }

    getRecebidosEnviadosPessoa(idPessoa: string): Observable<KudoCardsNumeros> {
        return this._http.get<KudoCardsNumeros>(`${environment.baseUrl}/KudoCard/RecebidosEnviadosPessoa`, {
            params: new HttpParams().set('idPessoa', idPessoa),
        });
    }

    getListaRecebidosEnviadosPessoa(idPessoa: string): Observable<KudoCardEnviadosRecebidos> {
        return this._http.get<KudoCardEnviadosRecebidos>(`${environment.baseUrl}/KudoCard/ListaRecebidosEnviadosPessoa`, {
            params: new HttpParams().set('idPessoa', idPessoa),
        });
    }

    getRecebidosDoTime(idTime: string): Observable<KudoCardsNumeros> {
        return this._http.get<KudoCardsNumeros>(`${environment.baseUrl}/KudoCard/RecebidosDoTime`, {
            params: new HttpParams().set('idTime', idTime),
        }).pipe(
            map((res: any) => {
                return new KudoCardsNumeros(0, res);
            })
        );
    }

    getListaRecebidosDoTime(idTime: string): Observable<KudoCardEnviadosRecebidos> {
        return this._http.get<KudoCardEnviadosRecebidos>(`${environment.baseUrl}/KudoCard/ListaRecebidosDoTime`, {
            params: new HttpParams().set('idTime', idTime),
        }).pipe(
            map((res: any) => {
                return new KudoCardEnviadosRecebidos([], res);
            })
        );
    }

}
