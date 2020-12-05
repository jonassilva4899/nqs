import { NgModule } from '@angular/core';

import { SafeHtml } from '@pipes/safe-html.pipe';
import { TimesModule } from 'app/main/pages/times/times.module';
import { LoginModule } from 'app/main/pages/login/login.module';
import { PessoasModule } from 'app/main/pages/pessoas/pessoas.module';
import { RegistroPessoaModule } from './pessoas/registro-pessoa/registro-pessoa.module';
import { OtherComponentsModule } from '../../components/components.module';
import { RecuperaSenhaModule } from './login/recupera-senha/recupera-senha.module';
import { NotificationModule } from '../../layout/components/notification/notification.module';
import { PerfilModule } from './perfil/perfil.module';
import { HomeTimeModule } from './home-time/home-time.module';
import { ConfiguracoesModule } from './configuracoes/configuracoes.module';

import { LoginService } from './login/login.service';
import { AgileService } from '@services/agile.service';
import { PermissoesService } from '@services/permissoes.service';
import { TesteModule } from './teste/teste.module';

@NgModule({
    imports: [
        TimesModule,
        LoginModule,
        PessoasModule,
        RegistroPessoaModule,
        OtherComponentsModule,
        RecuperaSenhaModule,
        NotificationModule,
        PerfilModule,
        HomeTimeModule,
        ConfiguracoesModule, 
        TesteModule
    ],
    declarations: [
        SafeHtml,
    ],
    exports: [
    ],
    providers: [
        LoginService,
        PermissoesService,
        AgileService,
    ]
})
export class PagesModule {

}
