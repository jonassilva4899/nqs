import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material';
import { FuseSharedModule } from '@fuse/shared.module';
import { AuthGuard } from 'app/helpers/auth.guard';


import { KudoCardsModule } from '@pages/perfil/kudo-cards/kudo-cards.module';


import { HomeTimeService } from './home-time.service';

import { HomeTimeComponent } from './home-time.component';
import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';

const routes = [
    {
        path: 'home',
        component: HomeTimeComponent,
        canActivate: [AuthGuard]
    }
];

@NgModule({
    declarations: [
        HomeTimeComponent,
    ],
    imports: [
        RouterModule.forChild(routes),
        FuseSharedModule,
        MatProgressSpinnerModule,

    
        KudoCardsModule,
         ExibirParaNiveisModule,
    ],
    exports: [
        HomeTimeComponent
    ],
    providers: [
        HomeTimeService,
    ]
})
export class HomeTimeModule {
}
