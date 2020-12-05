import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Observable } from 'rxjs';

import { KudoCardsService } from '../kudo-cards.service';
import { KudoCardDados, KudoCard } from '@models/KudoCard';

@Component({
  selector: 'app-kudo-card-view',
  templateUrl: './kudo-card-view.component.html',
  styleUrls: ['./kudo-card-view.component.scss']
})
export class KudoCardViewComponent implements OnInit {

    kudoCardDados: KudoCardDados;
    kudoCard: KudoCard;

    constructor(
        private _kudoCardsService: KudoCardsService,
        public dialogRef: MatDialogRef<KudoCardViewComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) { }

    ngOnInit(): void {
        this.kudoCardDados = this.data.kudoCardDados;
        this.getKudoCard(this.kudoCardDados.tipoKudoCard);
    }

    getKudoCard(kudoCardID: number): void {
        this._kudoCardsService.getKudoCard(kudoCardID)
            .subscribe((kudoCard) => {
                this.kudoCard = kudoCard;
            });
    }

}
