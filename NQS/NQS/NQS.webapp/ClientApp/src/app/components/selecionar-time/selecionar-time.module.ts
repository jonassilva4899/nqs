import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatIconModule,
} from '@angular/material';

import { SelecionarTimeService } from './selecionar-time.service';

import { SelecionarTimeComponent } from './selecionar-time.component';
import { EncodeWhiteSpacePipeModule } from '@pipes/encode-white-space.module';

@NgModule({
    declarations: [
        SelecionarTimeComponent,
    ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatProgressSpinnerModule,
        MatIconModule,
        EncodeWhiteSpacePipeModule,
    ],
    exports: [
        SelecionarTimeComponent,
    ],
    providers: [
        SelecionarTimeService,
    ]
})

export class SelecionarTimeModule {
}
