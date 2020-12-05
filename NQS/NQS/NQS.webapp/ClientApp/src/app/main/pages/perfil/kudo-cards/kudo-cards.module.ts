import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { FuseSharedModule } from '@fuse/shared.module';
import {
    MatButtonModule,
    MatIconModule,
    MatTabsModule,
    MatCardModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    MatAutocompleteModule,
} from '@angular/material';
import { OtherComponentsModule } from 'app/components/components.module';

import { KudoCardsService } from './kudo-cards.service';
import { PessoasService } from '@pages/pessoas/pessoas.service';
import { TimeService } from '@pages/times/time.service';

import { KudoCardsCardComponent } from './kudo-cards-card/kudo-cards-card.component';
import { KudoCardFormComponent } from './kudo-card-form/kudo-card-form.component';
import { KudoCardsDetalheComponent } from './kudo-cards-detalhe/kudo-cards-detalhe.component';
import { KudoCardsListaComponent } from './kudo-cards-lista/kudo-cards-lista.component';
import { KudoCardViewComponent } from './kudo-card-view/kudo-card-view.component';

@NgModule({
    declarations: [
        KudoCardsCardComponent,
        KudoCardFormComponent,
        KudoCardsDetalheComponent,
        KudoCardsListaComponent,
        KudoCardViewComponent,
    ],
    imports: [
        TranslateModule,
        FuseSharedModule,
        OtherComponentsModule,

        MatButtonModule,
        MatIconModule,
        MatTabsModule,
        MatCardModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatTooltipModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,

        // Reactive Form
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatRadioModule,
        MatAutocompleteModule,
    ],
    exports: [
        KudoCardsCardComponent,
        KudoCardsDetalheComponent,
        KudoCardViewComponent,
    ],
    providers: [
        KudoCardsService,
        PessoasService,
        TimeService,
    ],
    entryComponents: [
        KudoCardFormComponent,
        KudoCardsDetalheComponent,
        KudoCardViewComponent,
    ]
})

export class KudoCardsModule {
}
