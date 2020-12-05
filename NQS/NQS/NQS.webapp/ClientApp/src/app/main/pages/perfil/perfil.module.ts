import { PerfilComponent } from './perfil.component';
import { AuthGuard } from 'app/helpers/auth.guard';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { FuseSharedModule } from '@fuse/shared.module';
import { MatButtonModule, MatIconModule, MatButtonToggleModule, MatMenuModule, MatListModule, MatSelectModule, MatSlideToggleModule, MatCardModule, MatTabsModule, MatGridListModule, MatProgressBarModule, MatToolbarModule, MatFormFieldModule, MatInputModule, MatStepperModule, MatTableModule, MatChipsModule, MatDatepickerModule, MatAutocompleteModule, MatTooltipModule, MatProgressSpinnerModule } from '@angular/material';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { OtherComponentsModule } from 'app/components/components.module';
import { KudoCardsModule } from './kudo-cards/kudo-cards.module';
import { EncodeWhiteSpacePipeModule } from '@pipes/encode-white-space.module';
import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';

import { EditaPerfilComponent } from './edita-perfil/edita-perfil.component';
import { EditaPerfilTimeComponent } from './edita-perfil-time/edita-perfil-time.component';
import { EditaPerfilClienteComponent } from './edita-perfil-cliente/edita-perfil-cliente.component';
import { HistoricoPerfilClienteComponent } from './historico-perfil-cliente/historico-perfil-cliente.component';
import { AcaoColaboradorComponent } from './acao-colaborador/acao-colaborador.component';
import { FormPersonalMappingComponent } from './form-personal-mapping/form-personal-mapping.component';
import { PersonalMappingComponent } from './personal-mapping/personal-mapping.component';
import { ListaAcaoColaboradorComponent } from './acao-colaborador/lista-acao-colaborador/lista-acao-colaborador.component';
import { EditaAcaoColaboradorComponent } from './acao-colaborador/edita-acao-colaborador/edita-acao-colaborador.component';
import { MotivadoresComponent } from './motivadores/motivadores.component';

const routes = [
    {
        path: 'perfil/:idPessoa',
        component: PerfilComponent,
        canActivate: [AuthGuard]
    }
];

@NgModule({
    declarations: [
        PerfilComponent,
        EditaPerfilComponent,
        EditaPerfilTimeComponent,
        EditaPerfilClienteComponent,
        HistoricoPerfilClienteComponent,
        AcaoColaboradorComponent,
        FormPersonalMappingComponent,
        PersonalMappingComponent,
        ListaAcaoColaboradorComponent,
        EditaAcaoColaboradorComponent,
        MotivadoresComponent,
    ],
    imports: [
        RouterModule.forChild(routes),
        TranslateModule,
        FuseSharedModule,
        EncodeWhiteSpacePipeModule,

        MatButtonModule,
        MatButtonToggleModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatSelectModule,
        MatSlideToggleModule,
        MatTabsModule,
        MatCardModule,
        MatGridListModule,
        MatProgressBarModule,
        MatToolbarModule,
        MatDatepickerModule,
        MatAutocompleteModule,
        MatTooltipModule,
        DragDropModule,
        MatProgressSpinnerModule,

        // Reactive Form
        MatChipsModule,
        MatFormFieldModule,
        MatInputModule,
        MatStepperModule,
        MatTableModule,
        OtherComponentsModule,

        KudoCardsModule,
        ExibirParaNiveisModule,
    ],
    exports: [],
    entryComponents: [
        EditaPerfilComponent,
        EditaPerfilTimeComponent,
        EditaPerfilClienteComponent,
        HistoricoPerfilClienteComponent,
        AcaoColaboradorComponent,
        FormPersonalMappingComponent,
        ListaAcaoColaboradorComponent,
        EditaAcaoColaboradorComponent
    ]
})

export class PerfilModule {
}
