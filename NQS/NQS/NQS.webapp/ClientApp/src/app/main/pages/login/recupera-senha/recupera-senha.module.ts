import { NgModule } from '@angular/core';
import { RouterModule, ActivatedRoute } from '@angular/router';

import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';

import { MatDialogModule } from '@angular/material/dialog';

import { FuseSharedModule } from '@fuse/shared.module';
import { RecuperaSenhaComponent } from './recupera-senha.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
const routes = [
    {
        path: 'recupera-senha/:id/:hash',
        component: RecuperaSenhaComponent
    }
];

@NgModule({
    declarations: [
        RecuperaSenhaComponent
    ],
    imports: [
        RouterModule.forChild(routes),

        MatButtonModule,
        MatCheckboxModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,

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

        FuseSharedModule,

        FuseSharedModule
    ]
})
export class RecuperaSenhaModule {
}
