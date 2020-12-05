import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TermometroComponent } from './termometro.component';

@NgModule({
    declarations: [
        TermometroComponent,
    ],
    imports: [
        CommonModule
    ],
    exports: [
        TermometroComponent,
    ]
})
export class TermometroModule {

}
