import { Component, OnInit, Input } from '@angular/core';

import { ListaPessoas } from 'app/models/PessoaModel';
import { NivelPermissao } from '@models/Permissoes';

@Component({
    selector: 'app-card-pessoas',
    templateUrl: './card-pessoas.component.html',
    styleUrls: ['./card-pessoas.component.scss']
})
export class CardPessoasComponent implements OnInit {

    NivelPermissao = NivelPermissao;

    @Input() atributosPessoa: ListaPessoas;

    dataCheckPoint: Date;
    dataAtual: Date;
    exibeAlertaData = false;

    constructor() {
    }

    ngOnInit(): void {
        if (this.atributosPessoa.proximoCheckpoint) {
            this.dataAtual = new Date();
            this.dataCheckPoint = new Date(this.atributosPessoa.proximoCheckpoint);

            if (this.dataCheckPoint < this.dataAtual) {
                this.exibeAlertaData = true;
            }
        }
    }
}
