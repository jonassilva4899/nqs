import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Subject, Observable, empty } from 'rxjs';
import { takeUntil, first } from 'rxjs/internal/operators';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
import { RegistraPessoaService } from './registro-pessoa.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RegistroRoute } from '../../../../models/RegistroRoute';
import { RegistroInfoGet } from 'app/models/RegistroInfoGet';
import { Guid } from 'guid-typescript';
import { SnackBar } from '../../../../components/snackBar/snackBar';
import { LoginService } from '@pages/login/login.service';
import { FuseConfig } from '@fuse/types';
import { SelecionarTemaService } from '@pages/configuracoes/selecionar-tema/selecionar-tema.service';
import { GoogleLoginProvider, AuthService } from 'angularx-social-login';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { UsuarioSocialConvite } from '@models/UsuarioSocialConvite';

@Component({
    selector: 'register',
    templateUrl: './registro-pessoa.component.html',
    styleUrls: ['./registro-pessoa.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class RegistroPessoaComponent implements OnInit, OnDestroy {

    registroForm: FormGroup;
    paramsRota: RegistroRoute = new RegistroRoute();
    infosParaAtivar: RegistroInfoGet = new RegistroInfoGet();
    novoRegistro: any;
    idConviteHistorico: Guid;

    configuracaoSalva: FuseConfig;

    contaGoogle = false;

    private _unsubscribeAll: Subject<any>;

    constructor(
        private _fuseConfigService: FuseConfigService,
        private _selecionarTemaService: SelecionarTemaService,
        private _formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private redirectRouter: Router,
        private _registraService: RegistraPessoaService,
        private _snackBar: SnackBar,
        private authenticationService: LoginService,
        private sanitizer: DomSanitizer,
        private iconRegistry: MatIconRegistry,
        private authService: AuthService,
    ) {
        this.iconRegistry.addSvgIcon(
            'google_sign',
            sanitizer.bypassSecurityTrustResourceUrl('../../../../assets/icons/others/google-g-2015.svg'));

        this.configuracaoSalva = this._selecionarTemaService.getTema();

        this._fuseConfigService.config = {
            layout: {
                navbar: {
                    hidden: true
                },
                toolbar: {
                    hidden: true
                },
                footer: {
                    hidden: true
                },
                sidepanel: {
                    hidden: true
                }
            }
        };

        this._unsubscribeAll = new Subject();
        this.route.paramMap.subscribe(params => {
            this.paramsRota.id = params.get('id');
            this.paramsRota.hash = params.get('hash');
        });

        this._registraService.getInfoParaAtivar(this.paramsRota.id, this.paramsRota.hash)
            .subscribe(
                data => {
                    if (data.objeto !== null) {
                        this.idConviteHistorico = data.objeto.idConviteHistorico;
                        this.infosParaAtivar = data;
                        this.contaGoogle = data.objeto.contaGoogle;
                    }
                    else {
                        this._snackBar.abrirSnackBar('Solicitação Inválida...', 'Ok');
                        this.limparToken();
                    }
                },
                err => {
                    this._snackBar.abrirSnackBar('Houve um erro durante o procedimento...', 'Ok');
                    this.limparToken();
                });
    }

    ngOnInit(): void {

        this.registroForm = this._formBuilder.group({
            nome: [''],
            email: [''],
            senha: ['', Validators.required],
            senhaConfirmacao: ['', [Validators.required, confirmacaoSenhaValidacao]],
            idConviteHistorico: ['']
        });

        this.registroForm.get('senha').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this.registroForm.get('senhaConfirmacao').updateValueAndValidity();
            });
    }

    ngOnDestroy(): void {
        this._fuseConfigService.config = this.configuracaoSalva;

        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    enviaAtivacao(): void {
        this.novoRegistro = this.registroForm.getRawValue();

        const registroParaAtivar = {
            novaSenha: this.novoRegistro.senha,
            confirmacaoNovaSenha: this.novoRegistro.senhaConfirmacao,
            idConviteHistorico: this.idConviteHistorico
        };

        this._registraService.postInfoParaAtivar(JSON.stringify(registroParaAtivar)).subscribe(
            () => {
                this._snackBar.abrirSnackBar('Conta ativada com sucesso!', 'Ok');
                this.limparToken();
            },
            (err) => {
                this._snackBar.abrirSnackBar('Falha ao ativar conta...', 'Ok');
                this.limparToken();
            }
        );
    }

    enviaSincronizacaoGoogle(): void {
        const plataforma = GoogleLoginProvider.PROVIDER_ID;

        this.authService.signIn(plataforma).then(
            (resposta) => {
                const registroParaAtivarGoogle: UsuarioSocialConvite = new UsuarioSocialConvite();
                registroParaAtivarGoogle.idConviteHistorico = this.idConviteHistorico;
                registroParaAtivarGoogle.usuarioSocial = resposta;

                this._registraService.postInfoParaSincronizarGoogle(registroParaAtivarGoogle)
                    .pipe(first())
                    .subscribe(
                        (res) => {
                            this._snackBar.abrirSnackBar('Conta associada com sucesso!', 'Ok');
                            location.href = '/login';
                        },
                        (error) => {
                            this._snackBar.abrirSnackBar('Falha ao associar conta google...', 'Ok');
                            location.href = '/login';
                        });
            },
        );
    }

    limparToken(): void {
        this.authenticationService.logout();
        this.redirectRouter.navigateByUrl('/login');
    }
}

/**
 * Senha validação
 *
 * @param {AbstractControl} control
 * @returns {ValidationErrors | null}
 */
export const confirmacaoSenhaValidacao: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {

    if (!control.parent || !control) {
        return null;
    }

    const senha = control.parent.get('senha');
    const senhaConfirmacao = control.parent.get('senhaConfirmacao');

    if (!senha || !senhaConfirmacao) {
        return null;
    }

    if (senhaConfirmacao.value === '') {
        return null;
    }

    if (senha.value === senhaConfirmacao.value) {
        return null;
    }

    return { senhasNaoIdenticas: true };
};
