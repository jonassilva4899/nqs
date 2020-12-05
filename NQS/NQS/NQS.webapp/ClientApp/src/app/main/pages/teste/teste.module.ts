import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TesteComponent } from './teste.component';
import { NivelPermissao } from '@models/Permissoes';
import { AuthGuard } from 'app/helpers/auth.guard';
import { RouteGuard } from 'app/helpers/route.guard';
import { Router, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatButtonModule, MatButtonToggleModule, MatIconModule, MatListModule, MatMenuModule, MatSelectModule, MatSlideToggleModule, MatTabsModule, MatCardModule, MatGridListModule, MatDialogModule, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatToolbarModule, MatTooltipModule, MatProgressBarModule, MatAutocompleteModule, MatProgressSpinnerModule } from '@angular/material';
import { FuseSharedModule } from '@fuse/shared.module';
import { TranslateModule } from '@ngx-translate/core';
import { ExibirParaNiveisModule } from '@shared/directives/exibir-para-niveis.module';
import { EncodeWhiteSpacePipeModule } from '@shared/pipes/encode-white-space.module';
import { OtherComponentsModule } from 'app/components/components.module';



const routes = [
  {
      path: 'teste',
      component: TesteComponent
      //canActivate: [AuthGuard, RouteGuard],
      //data: {
      //    exibirParaNiveis: [
      //        NivelPermissao.TeamMember,
      //    ]
      //}
  }
];



@NgModule({
  declarations: [TesteComponent],
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
})


export class TesteModule { }
