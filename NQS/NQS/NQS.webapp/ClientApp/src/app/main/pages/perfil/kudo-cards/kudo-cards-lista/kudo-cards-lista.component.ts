import { Component, OnInit, OnChanges, ViewChild, Input, SimpleChanges } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { Observable } from 'rxjs';

import { KudoCardsService } from '../kudo-cards.service';
import { KudoCard, KudoCardDados } from '@models/KudoCard';
import { KudoCardViewComponent } from '../kudo-card-view/kudo-card-view.component';

@Component({
  selector: 'app-kudo-cards-lista',
  templateUrl: './kudo-cards-lista.component.html',
  styleUrls: ['./kudo-cards-lista.component.scss']
})
export class KudoCardsListaComponent implements OnInit, OnChanges {

    @ViewChild(MatSort, {static: true}) sort: MatSort;
    @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

    @Input() listaKudoCards: KudoCardDados[];
    @Input() listaRecebidos: boolean;
    @Input() isLoading: boolean;

    dataSource = new MatTableDataSource();
    displayedColumns = [
        'tipoKudoCard',
        'nomeOrganizacao',
        'destinatario',
        'mensagemKudoCard',
    ];

    constructor(
        private _kudoCardsService: KudoCardsService,
        private _matDialog: MatDialog,
    ) { }

    ngOnInit(): void {
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes && changes.listaKudoCards) {
            this.dataSource.data = this.listaKudoCards;
        }
    }

    getKudoCard(kudoCardID: number): Observable<KudoCard> {
        return this._kudoCardsService.getKudoCard(kudoCardID);
    }

    visualizarKudoCard(kudoCardDados: KudoCardDados): void {
        const dialogRef = this._matDialog.open(KudoCardViewComponent, {
            maxWidth: '700px',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                kudoCardDados,
            }
        });
    }

}
