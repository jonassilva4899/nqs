import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { FuseSharedModule } from '@fuse/shared.module';

import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatPaginatorModule, MatTooltipModule, MatChipsModule, MatAutocompleteModule, MatProgressSpinnerModule } from '@angular/material';
import { MatTableModule } from '@angular/material/table';

import { MatToolbarModule } from '@angular/material/toolbar';

import { TimesComponent } from './times.component';
import { ListaTimesComponent } from './lista-times/lista-times.component';
import { CardTimeComponent } from './card-time/card-time.component';

import { AuthGuard } from '../../../helpers/auth.guard';
import { DetalhesTimeComponent } from './detalhes-time/detalhes-time.component';
import { CardDetalheTimeComponent } from './detalhes-time/card-detalhe-time/card-detalhe-time.component';
import { CardMembrosTimeComponent } from './detalhes-time/card-membros-time/card-membros-time.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { CriaTimeFormComponent } from './cria-time-form/cria-time-form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { AdicionaMembroFormComponent } from './detalhes-time/adiciona-membro-form/adiciona-membro-form.component';
import { OtherComponentsModule } from 'app/components/components.module';
import { ConfirmaDeleteComponent } from 'app/components/confirma-delete/confirma-delete.component';
import { EncodeWhiteSpacePipeModule } from '@pipes/encode-white-space.module';
import { ExibirParaNiveisModule } from 'app/shared/directives/exibir-para-niveis.module';

const routes = [
    {
        path: 'times',
        component: TimesComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'times/detalhe/:id',
        component: DetalhesTimeComponent,
        canActivate: [AuthGuard]
    }
];

@NgModule({
    declarations: [
        TimesComponent,
        ListaTimesComponent,
        CardTimeComponent,
        DetalhesTimeComponent,
        CardDetalheTimeComponent,
        CardMembrosTimeComponent,
        CriaTimeFormComponent,
        AdicionaMembroFormComponent,
    ],
    imports: [
        RouterModule.forChild(routes),
        TranslateModule,
        FuseSharedModule,
        EncodeWhiteSpacePipeModule,
        MatPaginatorModule,
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
        MatTooltipModule,
        MatFormFieldModule,
        MatInputModule,
        MatStepperModule,
        MatTableModule,
        MatChipsModule,
        MatProgressSpinnerModule,
        MatAutocompleteModule,
        OtherComponentsModule,
        ExibirParaNiveisModule,
    ],
    exports: [
        TimesComponent
    ],
    entryComponents: [
        CriaTimeFormComponent,
        AdicionaMembroFormComponent,
        ConfirmaDeleteComponent
    ]
})

export class TimesModule {
}
