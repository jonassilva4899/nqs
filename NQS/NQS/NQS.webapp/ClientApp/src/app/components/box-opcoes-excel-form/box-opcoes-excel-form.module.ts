import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoxOpcoesExcelFormComponent } from './box-opcoes-excel-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FuseSharedModule } from '@fuse/shared.module';
import { MatCardModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatCheckboxModule, MatAutocompleteModule, MatButtonModule, MatIconModule, MatProgressSpinnerModule, MatProgressBarModule, MatChipsModule, MatTableModule, MatSortModule, MatPaginatorModule, MatTooltipModule } from '@angular/material';
import { FileUploadModule } from '../file-upload/file-upload.module';
import { ParseFormErrorsModule } from '@pipes/parse-form-errors.module';

@NgModule({
    declarations: [
        BoxOpcoesExcelFormComponent,
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        BrowserModule,
        RouterModule,
        FuseSharedModule,
        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        MatAutocompleteModule,
        MatButtonModule,
        MatIconModule,
        MatProgressSpinnerModule,
        MatProgressBarModule,
        MatChipsModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatTooltipModule,
        FileUploadModule,
        ParseFormErrorsModule,
    ],
    exports: [
        BoxOpcoesExcelFormComponent,
    ],
    entryComponents: [
        BoxOpcoesExcelFormComponent,
    ]
})
export class BoxOpcoesExcelFormModule { }
