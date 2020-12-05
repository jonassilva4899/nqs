import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { FuseSharedModule } from '@fuse/shared.module';

import { PessoasComponent } from './pessoas.component';
import { ListaPessoasComponent } from './lista-pessoas/lista-pessoas.component';

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
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material';

import { AuthGuard } from '../../../helpers/auth.guard';
import { OtherComponentsModule } from 'app/components/components.module';
import { PessoaFormDialogComponent } from './pessoa-form/pessoa-form.component';
import { CardPessoasComponent } from './card-pessoas/card-pessoas.component';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { EncodeWhiteSpacePipeModule } from '@pipes/encode-white-space.module';
import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';
import { NivelPermissao } from '@models/Permissoes';
import { RouteGuard } from 'app/helpers/route.guard';

const routes = [
    {
        path: 'pessoas',
        component: PessoasComponent,
        canActivate: [AuthGuard, RouteGuard],
        data: {
            exibirParaNiveis: [
                NivelPermissao.GoobeeAdmin,
                NivelPermissao.OrganizationAdmin,
                NivelPermissao.AgileCoach,
                NivelPermissao.TeamLeader,
            ]
        }
    }
];

@NgModule({
    declarations: [
        PessoasComponent,
        ListaPessoasComponent,
        PessoaFormDialogComponent,
        CardPessoasComponent
    ],
    entryComponents: [
        PessoaFormDialogComponent
    ],
    imports: [
        RouterModule.forChild(routes),
        EncodeWhiteSpacePipeModule,
        TranslateModule,
        FuseSharedModule,
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
        MatDialogModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatInputModule,
        MatToolbarModule,
        MatTooltipModule,
        MatProgressBarModule,
        OtherComponentsModule,
        MatAutocompleteModule,
        MatProgressSpinnerModule,
        ScrollingModule,
        ExibirParaNiveisModule,
    ],
    exports: [
        PessoasComponent
    ]
})

export class PessoasModule {
}
