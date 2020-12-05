import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { SelecionarTemaService } from './selecionar-tema.service';
import { FuseConfigService } from '@fuse/services/config.service';

@Component({
  selector: 'app-selecionar-tema',
  templateUrl: './selecionar-tema.component.html',
  styleUrls: ['./selecionar-tema.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class SelecionarTemaComponent implements OnInit, OnDestroy {

    themeControl = new FormControl();
    fuseConfig: any;

    private _unsubscribeAll: Subject<any>;

    constructor(
        private _selecionarTemaService: SelecionarTemaService,
        private _fuseConfigService: FuseConfigService,
    ) {
        this._unsubscribeAll = new Subject();
    }

    ngOnInit(): void {
        this._fuseConfigService.config
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config) => {
                this.fuseConfig = config;
                this.themeControl.setValue(config.colorTheme, { emitEvent: false });
            });

        this.themeControl.valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((theme) => {
                this.setTema(theme);
            });
    }

    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    setTema(tema?: string): void {
        if (tema) {
            this.fuseConfig.colorTheme = tema;
        }

        if (this.fuseConfig.colorTheme === 'theme-default') {
            this.fuseConfig.layout.navbar.primaryBackground = 'fuse-white-700';
        }

        localStorage.setItem('tema', JSON.stringify(this.fuseConfig));
        this._fuseConfigService.config = this.fuseConfig;
    }

}
