import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MAT_LABEL_GLOBAL_OPTIONS } from '@angular/material';

import { FileUploadComponent } from './file-upload.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  exports: [
    FileUploadComponent
  ],
  declarations: [
    FileUploadComponent
  ],
  providers: [
    {provide: MAT_LABEL_GLOBAL_OPTIONS, useValue: {float: 'never'}}
  ]
})
export class FileUploadModule { }
