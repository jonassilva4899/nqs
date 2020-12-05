import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';


import {
    InfoCompetencias,
    Competencia,
    CompetenciaCRUD,
    QuestaoCompetencia,
    QuestaoCompetenciaCRUD,
    TemperaturaTermometroEnum,
} from '@models/Competencia';
import { PraticaAgil } from '@models/PraticaAgil';
import { Usuario } from '@models/Usuario';
import { OrganizacaoDadosBasicos } from '@models/Organizacao';

@Injectable({
  providedIn: 'root'
})
export class ConfigurarTermometroService {

    usuario: Usuario;

    constructor(
        private http: HttpClient,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    getInfoCompetencias(): Observable<InfoCompetencias[]> {
        return this.http.get<InfoCompetencias[]>(`${environment.baseUrl}/Competencia/InfoCompetencias`);
    }

    getCompetencias(): Observable<Competencia[]> {
        return this.http.get<Competencia[]>(`${environment.baseUrl}/Competencia/PegarCompetencias`);
    }

    //getPraticasAgeis(): Observable<PraticaAgil[]> {
    //    return this._praticasAgeisService.getDadosBasicosPraticasAgeis();
    //}

    criarCompetencia(formData: any): Observable<any> {
        const body: CompetenciaCRUD = this.tratarDadosCompetencia(formData);
        return this.http.post(`${environment.baseUrl}/Competencia/AdicionarCompetencia`, body);
    }

    editarCompetencia(formData: any, competencia: Competencia): Observable<any> {
        const body: CompetenciaCRUD = this.tratarDadosCompetencia(formData, competencia);
        return this.http.put(`${environment.baseUrl}/Competencia/EditarCompetencia/${competencia.idCompetencia}`, body);
    }

    tratarDadosCompetencia(formData: any, competencia?: Competencia): CompetenciaCRUD {
        const body: CompetenciaCRUD = {
            nome: formData.nome,
            descricao: formData.descricao,
            idsPraticas: formData.praticasAgeis.map((pratica: PraticaAgil) => pratica.idPraticaAgil),
            idResponsavel: this.usuario.idPessoa,
        };

        if (competencia) {
            body.idCompetencia = competencia.idCompetencia;
        }

        return body;
    }

    getQuestoesCompetencia(competencia: Competencia): Observable<QuestaoCompetencia[]> {
        return this.http.get<QuestaoCompetencia[]>(`${environment.baseUrl}/Competencia/PegarCompetenciaQuestao/${competencia.idCompetencia}`);
    }

    apagarCompetencia(competencia: Competencia): Observable<any> {
        return this.http.delete(`${environment.baseUrl}/Competencia/DeletarCompetencia/${competencia.idCompetencia}`);
    }

    criarQuestaoCompetencia(formData: any): Observable<any> {
        const body: QuestaoCompetenciaCRUD = this.tratarDadosQuestaoCompetencia(formData);
        return this.http.post(`${environment.baseUrl}/Competencia/AdicionarCompetenciaQuestao`, body);
    }

    editarQuestaoCompetencia(formData: any, questaoCompetencia: QuestaoCompetencia): Observable<any> {
        const body: QuestaoCompetenciaCRUD = this.tratarDadosQuestaoCompetencia(formData, questaoCompetencia);
        return this.http.put(`${environment.baseUrl}/Competencia/EditarCompetenciaQuestao/${questaoCompetencia.idCompetenciaQuestao}`, body);
    }

    tratarDadosQuestaoCompetencia(formData: any, questaoCompetencia?: QuestaoCompetencia): QuestaoCompetenciaCRUD {
        const temperatura = (descricaoTemperatura, temperaturaTermometro) => {
            return {
                ...descricaoTemperatura,
                temperaturaTermometro,
            };
        };

        const body: QuestaoCompetenciaCRUD = {
            tituloQuestao: formData.tituloQuestao,
            questaoOpcoes: [
                temperatura(formData.fervendo, TemperaturaTermometroEnum.Fervendo),
                temperatura(formData.quente, TemperaturaTermometroEnum.Quente),
                temperatura(formData.morno, TemperaturaTermometroEnum.Morno),
                temperatura(formData.frio, TemperaturaTermometroEnum.Frio),
                temperatura(formData.congelado, TemperaturaTermometroEnum.Congelado),
            ],
            idCompetencia: formData.idCompetencia,
            idResponsavel: this.usuario.idPessoa,
        };

        if (questaoCompetencia) {
            body.idCompetenciaQuestao = questaoCompetencia.idCompetenciaQuestao;
            delete body.idCompetencia;
        }

        return body;
    }

    apagarQuestaoCompetencia(questaoCompetencia: QuestaoCompetencia): Observable<any> {
        return this.http.delete(`${environment.baseUrl}/Competencia/DeletarCompetenciaQuestao/${questaoCompetencia.idCompetenciaQuestao}`);
    }

    getOrganizacoesComCompetencias(): Observable<OrganizacaoDadosBasicos[]> {
        return this.http.get<OrganizacaoDadosBasicos[]>(`${environment.baseUrl}/Competencia/PegarOrganizacoesComCompetencias`);
    }

    importarConfiguracoesCompetencias(organizacao: OrganizacaoDadosBasicos): Observable<any> {
        return this.http.post(`${environment.baseUrl}/Competencia/ImportarCompetencias`, {
            idOrganizacao: organizacao.idOrganizacao,
            idResponsavel: this.usuario.idPessoa,
        });
    }

}
