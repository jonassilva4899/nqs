import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

import { PermissoesService } from '@services/permissoes.service';

import { Perfil } from '@models/Perfil';
import { EditaPerfil } from '@models/EditaPerfil';
import { PegarTimePerfil, TimesPerfil, PegarTimePerfilPUT } from '@models/PegarTimePerfil';
import { AcoesColaborador, ListaResponsaveis } from '@models/AcoesColaborador';
import { PersonalMapping, PersonalMappingPost, PersonalMappingPut } from '@models/PersonalMapping';
import { EditarClientePerfil, ClientePerfil } from '@models/ClientePerfil';
import { HabilidadesPerfil } from '@models/HabilidadesPerfil';
import { Permissao } from '@models/Permissoes';
import { Usuario } from '@models/Usuario';

@Injectable({
    providedIn: 'root'
})
export class PerfilService {
    baseUrl = environment.baseUrl;
    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    usuario: Usuario;

    constructor(
        private http: HttpClient,
        private _permissoesService: PermissoesService,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    getPerfil(id): Observable<Perfil> {
        return this.http.get<Perfil>(`${this.baseUrl}/pessoa/PegarPerfil/${id}`);
    }

    getPerfilParaEdicao(id): Observable<EditaPerfil> {
        return this.http.get<EditaPerfil>(`${this.baseUrl}/pessoa/PegarEditarPerfil/${id}`);
    }

    editaPerfil(perfil, id): any {
        return this.http.put<any>(`${this.baseUrl}/pessoa/EditarPerfil/${id}`, perfil, this.httpOptions);
    }

    editarTimePerfil(timesNovos: TimesPerfil[], timesAntigos: PegarTimePerfil, idPessoa: string): any {
        const body: PegarTimePerfilPUT = {
            idPessoa,
            timesNovos,
            timesAntigos: timesAntigos.timesPessoa,
        };

        return this.http.put<any>(`${this.baseUrl}/pessoa/EditarTimePerfil/${idPessoa}`, body, this.httpOptions);
    }

    getPegarTimePerfil(idPerfil): Observable<PegarTimePerfil> {
        const idPessoaLogada = this.usuario.idPessoa;
        return this.http.get<PegarTimePerfil>(`${this.baseUrl}/pessoa/PegarTimePerfil/${idPerfil}/${idPessoaLogada}`);
    }

    getClientesPerfil(id): Observable<EditarClientePerfil> {
        return this.http.get<EditarClientePerfil>(`${this.baseUrl}/pessoa/PegarClientePerfil/${id}`);
    }

    editaClientePerfil(clientes, id): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/pessoa/EditarClientePerfil/${id}`, clientes, this.httpOptions);
    }

    editarUnicoCliente(cliente): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/cliente/EditarCliente`, cliente, this.httpOptions);
    }

    getHistoricoClientes(id): Observable<ClientePerfil[]> {
        return this.http.get<ClientePerfil[]>(`${this.baseUrl}/pessoa/HistoricoClientesPessoa/${id}`);
    }

    adicionaCliente(cliente): any {
        return this.http.post<any>(`${this.baseUrl}/cliente/AdicionarCliente`, cliente, this.httpOptions);
    }

    listaAcoesColaborador(id): Observable<AcoesColaborador[]> {
        return this.http.get<AcoesColaborador[]>(`${this.baseUrl}/pessoa/ListarAcaoColaborador/${id}`);
    }

    pegaAcaoColaborador(idColaborador, idAcao): Observable<AcoesColaborador> {
        return this.http.get<AcoesColaborador>(`${this.baseUrl}/pessoa/PegarAcaoColaborador/${idColaborador}/${idAcao}`);
    }

    editarAcaoColaborador(acao): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/pessoa/EditarAcaoColaborador`, acao, this.httpOptions);
    }

    deletarAcaoColaborador(id): Observable<any> {
        return this.http.delete<any>(`${this.baseUrl}/pessoa/DeletarAcaoColaborador/${id}`);
    }

    adicionaAcaoColaborador(acaoColaborador): any {
        return this.http.post<any>(`${this.baseUrl}/pessoa/AdicionaAcaoColaborador`, acaoColaborador, this.httpOptions);
    }

    adicionarHabilidadeColaborador(habilidadeColaborador): Observable<any> {
        return this.http.post<any>(`${this.baseUrl}/pessoa/AdicionarHabilidade`, habilidadeColaborador, this.httpOptions);
    }

    listaResponsaveisAcoes(id): Observable<ListaResponsaveis[]> {
        return this.http.get<ListaResponsaveis[]>(`${this.baseUrl}/pessoa/ListaMembrosDoMesmoTime/${id}`);
    }

    getPersonalMapping(idPessoa: string): Observable<PersonalMapping[]> {
        return this.http.get<PersonalMapping[]>(`${this.baseUrl}/pessoa/PegarPersonalMapping/${idPessoa}`);
    }

    postPersonalMapping(data: any): Observable<any> {
        const body: PersonalMappingPost = {
            IdPessoa: data.idPessoa,
            Titulo: data.personalMapping.titulo,
            Itens: data.personalMapping.itens.map(item => item.nomeItem),
            IdResponsavel: data.usuario.idPessoa,
        };

        return this.http.post<any>(`${this.baseUrl}/pessoa/AdicionarPersonalMapping`, body);
    }

    putPersonalMapping(data: any): Observable<any> {
        const body: PersonalMappingPut = {
            IdPessoa: data.idPessoa,
            IdTitulo: data.personalMapping.idTitulo,
            Titulo: data.personalMapping.titulo,
            Itens: data.personalMapping.itens,
            IdResponsavel: data.usuario.idPessoa,
        };

        return this.http.put<any>(`${this.baseUrl}/pessoa/EditarPersonalMapping/${body.IdPessoa}`, body);
    }

    deletePersonalMapping(idMapping: string): Observable<any> {
        return this.http.delete<any>(`${this.baseUrl}/pessoa/DeletarPersonalMapping/${idMapping}`);
    }

    pegarHabilidadesColaborador(id: string): Observable<HabilidadesPerfil[]> {
        return this.http.get<HabilidadesPerfil[]>(`${this.baseUrl}/pessoa/PegarHabilidades/${id}`);
    }

    pegarHabilidadesComboBox(id: string): Observable<HabilidadesPerfil[]> {
        return this.http.get<HabilidadesPerfil[]>(`${this.baseUrl}/pessoa/PegarHabilidadesComboBox/${id}`);
    }

    removerHabilidadeColaborador(id: string, hab: string): Observable<any> {
        const httpRequest = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
            body: hab
        };
        return this.http.delete<any>(`${this.baseUrl}/pessoa/RemoverHabilidade/${id}`, httpRequest);
    }

    reenviaEmailConvite(solicitacao): Observable<any> {
        return this.http.post<any>(`${this.baseUrl}/pessoa/ConvidarNovamente`, solicitacao, this.httpOptions);
    }

    getPermissoesParaUsuarioLogado(): Observable<Permissao[]> {
        return this._permissoesService.getPermissoesParaUsuarioLogado();
    }

}
