import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FuseSharedModule } from '@fuse/shared.module';

import {
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatIconModule,
    MatTableModule,
    MatSortModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    MatTooltipModule,
} from '@angular/material';

import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';
import { ConfigurarTermometroService } from './configurar-termometro.service';

import { ConfigurarTermometroComponent } from './configurar-termometro.component';
import { ListaCompetenciasComponent } from './lista-competencias/lista-competencias.component';
import { CompetenciaFormComponent } from './competencia-form/competencia-form.component';
import { ListaQuestoesCompetenciaComponent } from './lista-questoes-competencia/lista-questoes-competencia.component';
import { QuestaoCompetenciaFormComponent } from './questao-competencia-form/questao-competencia-form.component';
import { ImportarConfiguracoesCompetenciasComponent } from './importar-configuracoes-competencias/importar-configuracoes-competencias.component';

@NgModule({
    declarations: [
        ConfigurarTermometroComponent,
        ListaCompetenciasComponent,
        CompetenciaFormComponent,
        ListaQuestoesCompetenciaComponent,
        QuestaoCompetenciaFormComponent,
        ImportarConfiguracoesCompetenciasComponent,
    ],
    imports: [
        CommonModule,
        TranslateModule,
        FuseSharedModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatIconModule,
        MatTableModule,
        MatSortModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatAutocompleteModule,
        MatTooltipModule,
        ExibirParaNiveisModule,
    ],
    exports: [
        ConfigurarTermometroComponent,
    ],
    entryComponents: [
        ListaCompetenciasComponent,
        CompetenciaFormComponent,
        ListaQuestoesCompetenciaComponent,
        QuestaoCompetenciaFormComponent,
        ImportarConfiguracoesCompetenciasComponent,
    ],
    providers: [
        ConfigurarTermometroService,
    ]
})
export class ConfigurarTermometroModule { }
