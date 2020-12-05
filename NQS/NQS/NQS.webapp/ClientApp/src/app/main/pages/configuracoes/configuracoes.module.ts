import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'app/helpers/auth.guard';

import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';
import { ConfigurarTermometroModule } from './configurar-termometro/configurar-termometro.module';

import { FuseConfigService } from '@fuse/services/config.service';
import { OrganizacaoService } from 'app/components/organizacao/organizacao.service';

import { ConfiguracoesComponent } from './configuracoes.component';
import { OtherComponentsModule } from 'app/components/components.module';
import { SelecionarTemaComponent } from './selecionar-tema/selecionar-tema.component';
import { SelecionarOrganizacaoComponent } from './selecionar-organizacao/selecionar-organizacao.component';
import { IntegracaoJiraComponent } from './integracao-jira/integracao-jira.component';

const routes: Routes = [
    {
        path     : 'configuracoes',
        component: ConfiguracoesComponent,
        canActivate: [AuthGuard],
    },
];

@NgModule({
    declarations: [
        ConfiguracoesComponent,
        SelecionarTemaComponent,
        SelecionarOrganizacaoComponent,
        IntegracaoJiraComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        OtherComponentsModule,
        ConfigurarTermometroModule,
        ExibirParaNiveisModule,
    ],
    providers: [
        FuseConfigService,
        OrganizacaoService,
    ]
})
export class ConfiguracoesModule { }
