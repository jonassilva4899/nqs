import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material';

import { KudoCardFormComponent } from '../kudo-card-form/kudo-card-form.component';
import { KudoCardsDetalheComponent } from '../kudo-cards-detalhe/kudo-cards-detalhe.component';
import { KudoCardsNumeros } from '@models/KudoCard';
import { Acao } from '@models/Enums';
import { TimesPerfil } from '@models/PegarTimePerfil';
import { KudoCardsService } from '../kudo-cards.service';

@Component({
    selector: 'app-kudo-cards-card',
    templateUrl: './kudo-cards-card.component.html',
    styleUrls: ['./kudo-cards-card.component.scss']
})
export class KudoCardsCardComponent implements OnInit, OnChanges {

    @Input() visaoTime: boolean;
    @Input() timeSelecionado: TimesPerfil;
    @Input() idPessoa: string;

    kudoCardsNumeros = new KudoCardsNumeros();

    isLoading = {
        kudoCardsNumeros: false,
    };

    constructor(
        private _matDialog: MatDialog,
        private _kudoCardService: KudoCardsService,
    ) { }

    ngOnChanges(changes: SimpleChanges): void {
        if (this.visaoTime) {
            if (changes && changes.timeSelecionado) {
                this.getContagemKudoCards(this.timeSelecionado ? this.timeSelecionado.id : '');
            }
        } else {
            if (changes && changes.idPessoa && changes.idPessoa.currentValue) {
                this.getRecebidosEnviadosPessoa(this.idPessoa);
            }
        }
    }

    ngOnInit(): void {
    }

    getContagemKudoCards(idTime?: string): void {
        this._kudoCardService.getRecebidosDoTime(idTime)
            .subscribe((kudoCardsNumeros: KudoCardsNumeros) => {
                this.kudoCardsNumeros = kudoCardsNumeros;
            });
    }

    getRecebidosEnviadosPessoa(idPessoa: string): void {
        this._kudoCardService.getRecebidosEnviadosPessoa(idPessoa)
            .subscribe((kudoCardsNumeros: KudoCardsNumeros) => {
                this.kudoCardsNumeros = kudoCardsNumeros;
            });
    }

    novoKudoCard(): void {
        const dialogRef = this._matDialog.open(KudoCardFormComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                acao: Acao.Cadastro,
            }
        });

        dialogRef.afterClosed().subscribe((result: any) => {
            if (result && result.atualizar) {
                this.kudoCardsNumeros.enviados = this.kudoCardsNumeros.enviados + 1;
            }
        });
    }

    visualizarKudoCards(): void {
        const dialogRef = this._matDialog.open(KudoCardsDetalheComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                visaoTime: this.visaoTime,
                idPessoa: this.idPessoa,
                timeSelecionado: this.timeSelecionado,
            }
        });

        dialogRef.afterClosed().subscribe((result: any) => {
        });
    }

}
