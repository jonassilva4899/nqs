import { Component, HostBinding, Inject, OnDestroy, OnInit, Renderer2, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { DOCUMENT } from '@angular/common';
import { Subject, Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { FuseConfigService } from '@fuse/services/config.service';
import { FuseNavigationService } from '@fuse/components/navigation/navigation.service';
import { FuseSidebarService } from '@fuse/components/sidebar/sidebar.service';
import { MatDialog } from '@angular/material';
import { OrganizacaoComponent } from 'app/components/organizacao/organizacao.component';
import { OrganizacaoService } from 'app/components/organizacao/organizacao.service';
import { Organizacao } from '@models/Organizacao';
import { Usuario, SolicitacaoToken } from '@models/Usuario';
import { NivelPermissao } from '@models/Permissoes';

@Component({
    selector: 'fuse-theme-options',
    templateUrl: './theme-options.component.html',
    styleUrls: ['./theme-options.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class FuseThemeOptionsComponent implements OnInit, OnDestroy {

    NivelPermissao = NivelPermissao;

    fuseConfig: any;
    form: FormGroup;
    organizacao: FormControl = new FormControl();
    listaOrganizacao$: Observable<Organizacao[]>;

    @HostBinding('class.bar-closed')
    barClosed: boolean;

    // Private
    private _unsubscribeAll: Subject<any>;

    /**
     * Constructor
     *
     * @param {DOCUMENT} document
     * @param {FormBuilder} _formBuilder
     * @param {FuseConfigService} _fuseConfigService
     * @param {FuseNavigationService} _fuseNavigationService
     * @param {FuseSidebarService} _fuseSidebarService
     * @param {Renderer2} _renderer
     */
    constructor(
        @Inject(DOCUMENT) private document: any,
        private _formBuilder: FormBuilder,
        private _fuseConfigService: FuseConfigService,
        private _fuseNavigationService: FuseNavigationService,
        private _fuseSidebarService: FuseSidebarService,
        private _renderer: Renderer2,
        private _matDialog: MatDialog,
        private _organizacaoService: OrganizacaoService,
    ) {
        // Set the defaults
        this.barClosed = true;

        // Set the private defaults
        this._unsubscribeAll = new Subject();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        // Build the config form
        // noinspection TypeScriptValidateTypes
        this.form = this._formBuilder.group({
            colorTheme: new FormControl(),
            customScrollbars: new FormControl(),
            layout: this._formBuilder.group({
                style: new FormControl(),
                width: new FormControl(),
                navbar: this._formBuilder.group({
                    primaryBackground: new FormControl(),
                    secondaryBackground: new FormControl(),
                    folded: new FormControl(),
                    hidden: new FormControl(),
                    position: new FormControl(),
                    variant: new FormControl()
                }),
                toolbar: this._formBuilder.group({
                    background: new FormControl(),
                    customBackgroundColor: new FormControl(),
                    hidden: new FormControl(),
                    position: new FormControl()
                }),
                footer: this._formBuilder.group({
                    background: new FormControl(),
                    customBackgroundColor: new FormControl(),
                    hidden: new FormControl(),
                    position: new FormControl()
                }),
                sidepanel: this._formBuilder.group({
                    hidden: new FormControl(),
                    position: new FormControl()
                })
            })
        });

        // Subscribe to the config changes
        this._fuseConfigService.config
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config) => {

                if (config.colorTheme === 'theme-default') {
                    config.layout.navbar.primaryBackground = 'fuse-white-700';
                }
                // Update the stored config
                this.fuseConfig = config;

                // Set the config form values without emitting an event
                // so that we don't end up with an infinite loop
                this.form.setValue(config, { emitEvent: false });
            });

        // Subscribe to the specific form value changes (layout.style)
        this.form.get('layout.style').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((value) => {

                // Reset the form values based on the
                // selected layout style
                this._resetFormValues(value);
            });

        // Subscribe to the form value changes
        this.form.valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config) => {

                localStorage.setItem('tema', JSON.stringify(config));
                localStorage.setItem('tema', JSON.stringify(config));

                const tema = localStorage.getItem('tema');

                if (tema != null) {
                    config = JSON.parse(tema);
                }

                if (config.colorTheme === 'theme-default') {
                    config.layout.navbar.primaryBackground = 'fuse-white-700';
                }
                // Update the config
                this._fuseConfigService.config = config;
            });

        // Add customize nav item that opens the bar programmatically
        const customFunctionNavItem = {
            id: 'custom-function',
            title: 'Customização',
            type: 'group',
            icon: 'settings',
            children: [
                {
                    id: 'customize',
                    title: 'Configurações',
                    type: 'item',
                    icon: 'settings',
                    url: '/configuracoes',
                    // function: () => {
                    //     this.toggleSidebarOpen('themeOptionsPanel');
                    // }
                }
            ]
        };

        this._fuseNavigationService.addNavigationItem(customFunctionNavItem, 'end');
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();

        // Remove the custom function menu
        this._fuseNavigationService.removeNavigationItem('custom-function');
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Private methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Reset the form values based on the
     * selected layout style
     *
     * @param value
     * @private
     */
    private _resetFormValues(value): void {
        switch (value) {
            // Vertical Layout #1
            case 'vertical-layout-1':
                {
                    this.form.patchValue({
                        layout: {
                            width: 'fullwidth',
                            navbar: {
                                primaryBackground: 'fuse-navy-700',
                                secondaryBackground: 'fuse-navy-900',
                                folded: false,
                                hidden: false,
                                position: 'left',
                                variant: 'vertical-style-1'
                            },
                            toolbar: {
                                background: 'fuse-white-500',
                                customBackgroundColor: false,
                                hidden: false,
                                position: 'below-static'
                            },
                            footer: {
                                background: 'fuse-navy-900',
                                customBackgroundColor: true,
                                hidden: false,
                                position: 'below-static'
                            },
                            sidepanel: {
                                hidden: false,
                                position: 'right'
                            }
                        }
                    });

                    break;
                }

            // Vertical Layout #2
            case 'vertical-layout-2':
                {
                    this.form.patchValue({
                        layout: {
                            width: 'fullwidth',
                            navbar: {
                                primaryBackground: 'fuse-navy-700',
                                secondaryBackground: 'fuse-navy-900',
                                folded: false,
                                hidden: false,
                                position: 'left',
                                variant: 'vertical-style-1'
                            },
                            toolbar: {
                                background: 'fuse-white-500',
                                customBackgroundColor: false,
                                hidden: false,
                                position: 'below'
                            },
                            footer: {
                                background: 'fuse-navy-900',
                                customBackgroundColor: true,
                                hidden: false,
                                position: 'below'
                            },
                            sidepanel: {
                                hidden: false,
                                position: 'right'
                            }
                        }
                    });

                    break;
                }

            // Vertical Layout #3
            case 'vertical-layout-3':
                {
                    this.form.patchValue({
                        layout: {
                            width: 'fullwidth',
                            navbar: {
                                primaryBackground: 'fuse-navy-700',
                                secondaryBackground: 'fuse-navy-900',
                                folded: false,
                                hidden: false,
                                position: 'left',
                                layout: 'vertical-style-1'
                            },
                            toolbar: {
                                background: 'fuse-white-500',
                                customBackgroundColor: false,
                                hidden: false,
                                position: 'above-static'
                            },
                            footer: {
                                background: 'fuse-navy-900',
                                customBackgroundColor: true,
                                hidden: false,
                                position: 'above-static'
                            },
                            sidepanel: {
                                hidden: false,
                                position: 'right'
                            }
                        }
                    });

                    break;
                }

            // Horizontal Layout #1
            case 'horizontal-layout-1':
                {
                    this.form.patchValue({
                        layout: {
                            width: 'fullwidth',
                            navbar: {
                                primaryBackground: 'fuse-navy-700',
                                secondaryBackground: 'fuse-navy-900',
                                folded: false,
                                hidden: false,
                                position: 'top',
                                variant: 'vertical-style-1'
                            },
                            toolbar: {
                                background: 'fuse-white-500',
                                customBackgroundColor: false,
                                hidden: false,
                                position: 'above'
                            },
                            footer: {
                                background: 'fuse-navy-900',
                                customBackgroundColor: true,
                                hidden: false,
                                position: 'above-fixed'
                            },
                            sidepanel: {
                                hidden: false,
                                position: 'right'
                            }
                        }
                    });

                    break;
                }
        }
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    adicionaEditOrg(edit?: boolean): void {

        let valor = null;
        if (edit === true) {
            let usuario: Usuario = new Usuario();
            usuario = JSON.parse(localStorage.getItem('usuario'));
            valor = usuario.idOrganizacao;
        }

        this._matDialog.open(OrganizacaoComponent, {
            autoFocus: false,
            width: '80vw',
            maxHeight: '100vh',
            data: {
                idOrganizacao: valor
            },
        }).afterClosed().subscribe(data => { if (data) { this.listarOrganizacoes(); } });
    }

    listarOrganizacoes(): void {
        let usuario: Usuario = new Usuario();
        usuario = JSON.parse(localStorage.getItem('usuario'));
        this.listaOrganizacao$ = this._organizacaoService.listar(usuario.id);
        this.organizacao.setValue(usuario.idOrganizacao);
    }

    trocarOrganizacao(): void {
        this.pegarNovoToken(this.organizacao.value);
    }

    pegarNovoToken(idOrganizacao): void {
        let usuario: Usuario = new Usuario();
        usuario = JSON.parse(localStorage.getItem('usuario'));

        const solicitaToken: SolicitacaoToken = new SolicitacaoToken();
        solicitaToken.idUsuario = usuario.id;
        solicitaToken.idOrganizacao = idOrganizacao;

        this._organizacaoService.novoToken(JSON.stringify(solicitaToken))
            .subscribe(
                data => {
                    localStorage.removeItem('usuario');
                    localStorage.setItem('usuario', JSON.stringify(data));
                    localStorage.removeItem('timeSelecionado');
                    window.location.reload();
                });
    }

    /**
     * Toggle sidebar open
     *
     * @param key
     */
    toggleSidebarOpen(key): void {
        this._fuseSidebarService.getSidebar(key).toggleOpen();
        this.listarOrganizacoes();
    }
}
