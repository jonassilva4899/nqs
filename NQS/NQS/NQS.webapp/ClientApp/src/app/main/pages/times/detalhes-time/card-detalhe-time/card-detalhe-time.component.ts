import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { TimeDetalhe, EditarTime, TimeGrupo } from 'app/models/TimeDetalhe';
import { MatDialog } from '@angular/material';
import { CriaTimeFormComponent } from '@pages/times/cria-time-form/cria-time-form.component';
import { ActivatedRoute } from '@angular/router';
import { TimeService } from '@pages/times/time.service';
import { NivelPermissao } from '@models/Permissoes';

@Component({
    selector: 'app-card-detalhe-time',
    templateUrl: './card-detalhe-time.component.html',
    styleUrls: ['./card-detalhe-time.component.scss']
})
export class CardDetalheTimeComponent implements OnInit {

    NivelPermissao = NivelPermissao;

    idTimeRota: string;
    @Input() receberDetalheTime: any;
    constructor(
        private _matDialog: MatDialog,
        private _rota: ActivatedRoute,
        private _timeService: TimeService,
    ) {
        this._rota.paramMap.subscribe(
            param => {
                this.idTimeRota = param.get('id');
            }
        );
    }

    ngOnInit(): void {
    }

    editarTime(): void {
        this._matDialog.open(CriaTimeFormComponent, {
            autoFocus: false,
            data: {
                editar: true,
                editarTime: this.receberDetalheTime,
                idTime: this.idTimeRota
            }
        }).afterClosed().subscribe(
            (data: EditarTime) => {
                if (data) {
                    this.receberDetalheTime.logo = data.logo;
                    this.receberDetalheTime.localizacao = data.localizacao;
                    this.receberDetalheTime.grupos = data.grupos;
                    this.receberDetalheTime.proposito = data.proposito;
                    this.receberDetalheTime.valores = data.valores;
                    this.receberDetalheTime.nome = data.nome;
                    this.receberDetalheTime.ativo = data.ativo;
                    this.receberDetalheTime.bioTime = data.bioTime;
                    this.receberDetalheTime.acordos = data.acordos;
                    this.receberDetalheTime.capacity = data.capacity;
                }
            }
        );
    }

    retornarNomesDosGrupos(grupos: TimeGrupo[]): string {
        return grupos.map(grupo => grupo.nome).join(', ');
    }
}
