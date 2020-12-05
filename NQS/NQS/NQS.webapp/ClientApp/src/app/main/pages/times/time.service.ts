import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


import { Times, FiltroTimes, TimeDadosBasicos } from 'app/models/Times';
import { TimeDetalhe, TimeGrupo } from 'app/models/TimeDetalhe';
import { PessoaDados, ListaFiltroPessoas } from 'app/models/Pessoa';
import { ProjetoDadosBasicos } from '@models/Projeto';
import { PessoasService } from '@pages/pessoas/pessoas.service';
import { TermometroAgilEnum } from '@models/Enums';
import { SelecionarTimeService } from 'app/components/selecionar-time/selecionar-time.service';

@Injectable({
    providedIn: 'root'
})
export class TimeService {

    baseUrl = environment.baseUrl;
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private _pessoasService: PessoasService,
        private _selecionarTimeService: SelecionarTimeService,
    ) {
    }

    timeSelecionado(): Observable<TimeDadosBasicos> {
        return this._selecionarTimeService.timeSelecionado;
    }

    pegarTimes(filtros: FiltroTimes): Observable<Times> {
        const filtroTemperatura = (temp: TermometroAgilEnum): Array<number> => {
            if (temp === TermometroAgilEnum.Congelado) {
                return [1, 2];
            }
            else if (temp === TermometroAgilEnum.Frio) {
                return [3, 4];
            }
            else if (temp === TermometroAgilEnum.Morno) {
                return [5, 6];
            }
            else if (temp === TermometroAgilEnum.Quente) {
                return [7, 8];
            }
            else if (TermometroAgilEnum.Fervendo) {
                return [9];
            }

            return [];
        };

        return this.http.post<Times>(`${this.baseUrl}/Time/Times`, filtros)
            .pipe(
                map((times) => {
                    const timesFiltrados = {
                        ...times,
                        objeto: times.objeto.filter((time) => {
                            const temperatura = Math.floor(time.praticas);

                            if (filtros.temperatura) {
                                if (!filtroTemperatura(filtros.temperatura).includes(temperatura)) {
                                    return filtros.temperatura === TermometroAgilEnum.Fervendo && temperatura > 9;
                                }

                                return true;
                            }

                            return true;
                        }),
                    };

                    return timesFiltrados;
                })
            );
    }

    criarTimes(time): any {
        return this.http.post<any>(`${this.baseUrl}/Time`, time, this.httpOptions);
    }

    pegaTimeEspecifico(idTime): Observable<TimeDetalhe> {
        return this.http.get<TimeDetalhe>(`${this.baseUrl}/Time/Time-interno/${idTime}`);
    }

    pegarUsuariosAtivos(idPessoa?: string): Observable<PessoaDados[]> {
        const idPessoaFiltrada = idPessoa || '';
        return this.http.get<PessoaDados[]>(`${this.baseUrl}/Pessoa/PessoasAtivas/${idPessoaFiltrada}`);
    }

    pegarUsuarioAtivosNaoInclusivo(idPessoa: string): Observable<PessoaDados[]> {
        return this.http.get<PessoaDados[]>(`${this.baseUrl}/Pessoa/PegarPessoasUsuarioNaoInclusivo/${idPessoa}`);
    }

    adicionaMembroTime(membro): Observable<any> {
        return this.http.post<any>(`${this.baseUrl}/time/Adicionar-Pessoa`, membro, this.httpOptions);
    }

    editarMembroTime(membro): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/time/Time-Interno/EditarMembro`, membro, this.httpOptions);
    }

    editarTime(id, time): Observable<any> {
        return this.http.put<any>(`${environment.baseUrl}/time/Time-interno/Editar/${id}`, time, this.httpOptions);
    }

    removerMembroTime(membro): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/time/Time-Interno/RemoverMembro`, membro, this.httpOptions);
    }

    getGrupos(): Observable<TimeGrupo[]> {
        return this.http.get<any>(`${this.baseUrl}/Time/PegarGrupos`);
    }

    //getProjetos(): Observable<ProjetoDadosBasicos[]> {
    //    return this._scrumboardService.getProjetos();
    //}

    getClientes(): Observable<ListaFiltroPessoas[]> {
        return this._pessoasService.listarClientesFiltro();
    }

}
