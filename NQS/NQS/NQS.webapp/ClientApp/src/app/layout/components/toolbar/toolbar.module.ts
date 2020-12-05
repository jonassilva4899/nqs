import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  MatButtonModule,
  MatIconModule,
  MatMenuModule,
  MatToolbarModule,
  MatBadgeModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
} from '@angular/material';

import { FuseSearchBarModule, FuseShortcutsModule } from '@fuse/components';
import { FuseSharedModule } from '@fuse/shared.module';
import { SelecionarTimeModule } from 'app/components/selecionar-time/selecionar-time.module';
import { EncodeWhiteSpacePipeModule } from '@pipes/encode-white-space.module';

import { ToolbarService } from './toolbar.service';

import { ToolbarComponent } from 'app/layout/components/toolbar/toolbar.component';
import { NotificationComponent } from 'app/layout/components/notification/notification.component';

@NgModule({
    declarations: [
        ToolbarComponent,
        NotificationComponent
    ],
    imports     : [
        RouterModule,
        MatButtonModule,
        MatIconModule,
        MatMenuModule,
        MatToolbarModule,
        MatBadgeModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,

        FuseSharedModule,
        FuseSearchBarModule,
        FuseShortcutsModule,
        SelecionarTimeModule,
        EncodeWhiteSpacePipeModule,
    ],
    exports     : [
        ToolbarComponent
    ],
    providers   : [
        ToolbarService,
    ],
})
export class ToolbarModule {
}
