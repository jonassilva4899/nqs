import {  TimesDados } from 'app/models/Times';
import { Component, OnInit, Input } from '@angular/core';
import { NivelPermissao } from '@models/Permissoes';
import { TermometroAgilEnum } from '@models/Enums';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material';

@Component({
    selector: 'app-card-time',
    templateUrl: './card-time.component.html',
    styleUrls: ['./card-time.component.scss']
})
export class CardTimeComponent implements OnInit {

    NivelPermissao = NivelPermissao;
    TermometroAgilEnum = TermometroAgilEnum;
    titulo = '';

    @Input() atributosTime: TimesDados;

    constructor(
        private _domSanitizer: DomSanitizer,
        private _matIconRegistro: MatIconRegistry,
    ) {
        this._matIconRegistro.addSvgIcon('goobee_termometro',
            this._domSanitizer.bypassSecurityTrustResourceUrl('../../../../../assets/goobee_termometro.svg')
        );
    }

    ngOnInit(): void {
        this.defineTitulo(this.atributosTime.praticas);
    }

    defineTitulo(temp: number): void {
        if (temp < 3) {
            this.titulo = TermometroAgilEnum.Congelado;
        }
        else if (temp < 5) {
            this.titulo = TermometroAgilEnum.Frio;
        }
        else if (temp < 7) {
            this.titulo = TermometroAgilEnum.Morno;
        }
        else if (temp < 9) {
            this.titulo = TermometroAgilEnum.Quente;
        }
        else {
            this.titulo = TermometroAgilEnum.Fervendo;
        }
    }

}
