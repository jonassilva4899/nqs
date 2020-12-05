import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
import { GoogleLoginProvider, AuthService, SocialUser } from 'angularx-social-login';

import { LoginService } from './login.service';

import { Router, ActivatedRoute } from '@angular/router';
import { SnackBar } from '../../../components/snackBar/snackBar';
import { SelecionarTemaService } from '@pages/configuracoes/selecionar-tema/selecionar-tema.service';
import { FuseConfig } from '@fuse/types';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { Subscription } from 'rxjs';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
})
export class LoginComponent implements OnInit, OnDestroy {
    loginForm: FormGroup;
    returnUrl: string;
    loginEstado: boolean;
    enviarEmailFlag: boolean;
    esqueciSenhaForm: FormGroup;
    emailRecuperarSenha: any;
    verSenha: boolean;

    configuracaoSalva: FuseConfig;

    isLoading = {
        login: false,
        loginGoogle: false,
    };

    hasError = {
        login: false,
    };

    private _unsubscribeAll: Subscription[] = [];
    constructor(
        private _fuseConfigService: FuseConfigService,
        private _selecionarTemaService: SelecionarTemaService,
        private _formBuilder: FormBuilder,
        private authenticationService: LoginService,
        private router: Router,
        private route: ActivatedRoute,
        private _snackBar: SnackBar,
        private authService: AuthService,
        private iconRegistry: MatIconRegistry,
        private sanitizer: DomSanitizer,
    ) {
        this.iconRegistry.addSvgIcon(
            'google_sign',
            sanitizer.bypassSecurityTrustResourceUrl('../../../../assets/icons/others/google-g-2015.svg'));

        this.configuracaoSalva = this._selecionarTemaService.getTema();

        this._fuseConfigService.config = {
            colorTheme: 'theme-pink-dark',
            customScrollbars: true,
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

        if (this.authenticationService.usuarioLogadoDados) {
            this.router.navigate(['/home']);
        }
    }

    ngOnInit(): void {
        this.loginForm = this._formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            senha: ['', Validators.required]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';
        this.loginEstado = true;
    }

    ngOnDestroy(): void {
        this._fuseConfigService.config = this.configuracaoSalva;
    }

    get f(): any { return this.loginForm.controls; }

    onSubmit(): void {
        if (this.loginForm.invalid) {
            return;
        }

        this.isLoading.login = true;
        this.authenticationService.login(this.f.email.value, this.f.senha.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.isLoading.login = false;
                    // this.router.navigate([this.returnUrl]);
                    location.href = this.returnUrl;
                },
                error => {
                    this.isLoading.login = false;
                    this.hasError.login = true;
                    this._snackBar.abrirSnackBar('Usuário ou Senha inválida', 'OK', 'red');
                });
    }

    esqueciSenha(): void {
        this.loginEstado = false;
        this.enviarEmailFlag = false;
        this.esqueciSenhaForm = this._formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
        });
    }

    voltarLogin(): void {
        this.loginEstado = true;
    }

    logInComGoogle(): void {
        const plataforma = GoogleLoginProvider.PROVIDER_ID;
        this.isLoading.loginGoogle = true;
        this.authService.signIn(plataforma).then(
            (resposta) => {
                this._unsubscribeAll.push(
                    this.authenticationService.logInComGoogle(resposta)
                        .pipe(first())
                        .subscribe((res) => {
                            location.href = this.returnUrl;
                        },
                            (error) => {
                                this._snackBar.abrirSnackBar('Conta Google não existente, favor solicitar uma conta com o Administrador da sua Organização', 'Ok');
                                localStorage.clear();
                                return;
                            })
                );
            },
            (error) => {
                this._snackBar.abrirSnackBar('Não foi possível se comunicar com sua conta Google! Por favor, tente novamente mais tarde!', 'Ok');
                this.isLoading.loginGoogle = false;
                localStorage.clear();
                return;
            }
        );
    }

    recuperarSenha(): void {
        this.enviarEmailFlag = true;
        this.emailRecuperarSenha = this.esqueciSenhaForm.getRawValue();

        if (this.emailRecuperarSenha.email == null) {
            return;
        }

        const enviaEmail = {
            email: this.emailRecuperarSenha.email
        };

        this.authenticationService.recuperarSenha(JSON.stringify(enviaEmail))
            .subscribe(
                data => {
                    this._snackBar.abrirSnackBar('Email de recuperação encaminhado!', 'Ok');
                    this.loginEstado = true;
                },
                err => {
                    this._snackBar.abrirSnackBar('Erro ao encaminhar email!', 'Ok');
                }
            );
    }
}
