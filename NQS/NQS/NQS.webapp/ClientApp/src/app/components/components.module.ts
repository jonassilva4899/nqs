import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { FuseSharedModule } from '@fuse/shared.module';

import {
    MatFormFieldModule,
    MatInputModule,
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
    MatToolbarModule,
    MatTooltipModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatChipsModule,
    MatRadioModule,
    MatCheckboxModule,
} from '@angular/material';

import { TermometroModule } from './termometro/termometro.module';

import { UploadImagemComponent } from './upload-imagem/upload-imagem.component';
import { ConfirmaDeleteComponent } from './confirma-delete/confirma-delete.component';
import { ClienteControlComponent } from './cliente-control/cliente-control.component';
import { OrganizacaoComponent } from './organizacao/organizacao.component';

@NgModule({
    declarations: [
        UploadImagemComponent,
        ConfirmaDeleteComponent,
        ClienteControlComponent,
        OrganizacaoComponent,
    ],
    entryComponents: [
    ],
    imports: [
        TranslateModule,
        FuseSharedModule,
        MatFormFieldModule,
        MatInputModule,
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
        MatToolbarModule,
        MatTooltipModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatAutocompleteModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatChipsModule,
        MatRadioModule,
        MatCheckboxModule,
        TermometroModule,
    ],
    exports: [
        TranslateModule,
        FuseSharedModule,
        MatFormFieldModule,
        MatInputModule,
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
        MatToolbarModule,
        MatTooltipModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatAutocompleteModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatChipsModule,
        MatRadioModule,
        MatCheckboxModule,
        TermometroModule,

        UploadImagemComponent,
        ConfirmaDeleteComponent,
        ClienteControlComponent,
        OrganizacaoComponent,
    ]
})

export class OtherComponentsModule {
}
