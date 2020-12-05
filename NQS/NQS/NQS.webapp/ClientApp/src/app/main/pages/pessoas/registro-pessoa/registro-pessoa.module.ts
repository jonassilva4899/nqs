import { NgModule } from '@angular/core';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

import { FuseSharedModule } from '@fuse/shared.module';
import { RegistroPessoaComponent } from './registro-pessoa.component';
const routes = [
    {
        path: 'registro-pessoa/:id/:hash',
        component: RegistroPessoaComponent
    }
];

@NgModule({
    declarations: [
        RegistroPessoaComponent
    ],
    imports: [
        RouterModule.forChild(routes),

        MatButtonModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,

        FuseSharedModule
    ]
})
export class RegistroPessoaModule {
}
