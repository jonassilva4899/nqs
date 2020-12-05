import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import {
    MatSort,
    MatPaginator,
    MatTableDataSource,
    MatDialog,
    MatDialogRef,
    MAT_DIALOG_DATA,
} from '@angular/material';
import { Observable } from 'rxjs';

import { KudoCardsService } from '../kudo-cards.service';
import { KudoCardDados, KudoCard, KudoCardEnviadosRecebidos } from '@models/KudoCard';
import { TimeDadosBasicos } from '@models/Times';

@Component({
  selector: 'app-kudo-cards-detalhe',
  templateUrl: './kudo-cards-detalhe.component.html',
  styleUrls: ['./kudo-cards-detalhe.component.scss']
})
export class KudoCardsDetalheComponent implements OnInit {

    listaKudoCards = new KudoCardEnviadosRecebidos();
    listaKudoCardsEnviados: KudoCardDados[] = [];
    listaKudoCardsRecebidos: KudoCardDados[] = [];

    visaoTime: boolean;
    idPessoa: string;
    timeSelecionado: TimeDadosBasicos;

    isLoading = {
        listaKudoCards: false,
    };

    constructor(
        private _kudoCardsService: KudoCardsService,
        private _matDialog: MatDialog,
        public dialogRef: MatDialogRef<KudoCardsDetalheComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) { }

    ngOnInit(): void {
        this.visaoTime = this.data.visaoTime;
        this.idPessoa = this.data.idPessoa;
        this.timeSelecionado = this.data.timeSelecionado;

        if (this.visaoTime) {
            this.getListaRecebidosDoTime(this.timeSelecionado ? this.timeSelecionado.id : '');
        } else {
            this.getListaRecebidosEnviadosPessoa(this.idPessoa);
        }
    }

    getListaRecebidosDoTime(idTime: string): void {
        this.getListaKudoCards(
            this._kudoCardsService.getListaRecebidosDoTime(idTime)
        );
    }

    getListaRecebidosEnviadosPessoa(idPessoa: string): void {
        this.getListaKudoCards(
            this._kudoCardsService.getListaRecebidosEnviadosPessoa(idPessoa)
        );
    }

    getListaKudoCards(service: Observable<any>): void {
        this.listaKudoCards = new KudoCardEnviadosRecebidos();
        this.listaKudoCardsEnviados = [];
        this.listaKudoCardsRecebidos = [];
        this.isLoading.listaKudoCards = true;

        service.subscribe(
            (kudoCards: KudoCardEnviadosRecebidos) => {
                this.listaKudoCards = kudoCards;
                this.listaKudoCardsEnviados = kudoCards.enviados;
                this.listaKudoCardsRecebidos = kudoCards.recebidos;
                this.isLoading.listaKudoCards = false;
            },
            (err: any) => {
                this.isLoading.listaKudoCards = false;
            },
        );
    }
}
