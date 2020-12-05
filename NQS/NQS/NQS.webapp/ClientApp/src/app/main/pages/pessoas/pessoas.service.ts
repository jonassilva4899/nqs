import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';
import { environment } from 'environments/environment';

import { PermissoesService } from '@services/permissoes.service';
import { SelecionarTimeService } from 'app/components/selecionar-time/selecionar-time.service';

import { ListaFiltroPessoas, MembroDoTime } from '@models/Pessoa';
import { ListaPessoas } from '@models/PessoaModel';
import { HabilidadesPerfil } from '@models/HabilidadesPerfil';
import { TimeDadosBasicos } from '@models/Times';
import { Permissao } from '@models/Permissoes';

@Injectable({
    providedIn: 'root'
})
export class PessoasService {

    baseUrl = environment.baseUrl;
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        private _permissoesService: PermissoesService,
        private _selecionarTimeService: SelecionarTimeService,
    ) {
    }

    timeSelecionado(): Observable<TimeDadosBasicos> {
        return this._selecionarTimeService.timeSelecionado;
    }

    cadastrarPessoa(pessoa): Observable<any> {
        return this.http.post(`${this.baseUrl}/Pessoa/Adicionar`, pessoa, this.httpOptions);
    }

    listarPessoas(filtro): Observable<ListaPessoas[]> {
        return this.http.post<ListaPessoas[]>(`${this.baseUrl}/Pessoa/ListarTodas`, filtro, this.httpOptions);
    }

    listarMembrosDoTime(idTime: Guid): Observable<MembroDoTime[]> {
        return this.http.get<MembroDoTime[]>(`${this.baseUrl}/Pessoa/ListaMembrosDoMesmoTime/${idTime}`);
    }

    listarTimesFiltro(): Observable<ListaFiltroPessoas[]> {
        return this.http.get<ListaFiltroPessoas[]>(`${this.baseUrl}/Pessoa/PegarTimesComboBox`);
    }

    listarClientesFiltro(): Observable<ListaFiltroPessoas[]> {
        return this.http.get<ListaFiltroPessoas[]>(`${this.baseUrl}/Pessoa/PegarClientesComboBox`);
    }

    listarResponsaveisFiltro(): Observable<ListaFiltroPessoas[]>{
        return this.http.get<ListaFiltroPessoas[]>(`${this.baseUrl}/Pessoa/PegarResponsaveisComboBox`);
    }

    listarHabilidadesFiltro(): Observable<HabilidadesPerfil[]>{
        return this.http.get<HabilidadesPerfil[]>(`${this.baseUrl}/pessoa/PegarTodasHabilidades`);
    }

    getPermissoesParaUsuarioLogado(): Observable<Permissao[]> {
        return this._permissoesService.getPermissoesParaUsuarioLogado();
    }
}
