import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/internal/operators';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
import { ActivatedRoute, Router } from '@angular/router';
import { SnackBar } from '../../../../components/snackBar/snackBar';
import { LoginService } from '../login.service';
import { FuseConfig } from '@fuse/types';
import { SelecionarTemaService } from '@pages/configuracoes/selecionar-tema/selecionar-tema.service';

@Component({
    selector: 'register',
    templateUrl: './recupera-senha.component.html',
    styleUrls: ['./recupera-senha.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class RecuperaSenhaComponent implements OnInit, OnDestroy {

    recuperarSenhaForm: FormGroup;
    idRoute: string;
    hashRoute: string;
    camposRecuperarSenha: any;
    redefinirFlag: boolean;

    configuracaoSalva: FuseConfig;

    private _unsubscribeAll: Subject<any>;

    constructor(
        private _fuseConfigService: FuseConfigService,
        private _selecionarTemaService: SelecionarTemaService,
        private _formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private redirectRouter: Router,
        private _loginService: LoginService,
        private _snackBar: SnackBar,
    ) {
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
    }

    ngOnInit(): void {
        this.redefinirFlag = false;
        this.route.paramMap.subscribe(params => {
            this.idRoute = params.get('id');
            this.hashRoute = params.get('hash');
        });

        this.recuperarSenhaForm = this._formBuilder.group({
            senha: ['', Validators.required],
            senhaConfirmacao: ['', [Validators.required, confirmacaoSenhaValidacao]],
        });

        this.recuperarSenhaForm.get('senha').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this.recuperarSenhaForm.get('senhaConfirmacao').updateValueAndValidity();
            });
    }

    ngOnDestroy(): void {
        this._fuseConfigService.config = this.configuracaoSalva;

        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    redefinirSenha(): void {
        this.redefinirFlag = true;
        this.camposRecuperarSenha = this.recuperarSenhaForm.getRawValue();

        const envioRedefinicao = {
            Senha: this.camposRecuperarSenha.senha,
            ConfirmarSenha: this.camposRecuperarSenha.senhaConfirmacao,
            IdRecuperarSenhaHash: this.idRoute,
            TokenHash: this.hashRoute
        };

        this._loginService.redefinirSenha(JSON.stringify(envioRedefinicao))
        .subscribe(
            data => {
                this._snackBar.abrirSnackBar('Senha redefinida com Sucesso!', 'Ok');
            },
            err => {
                this._snackBar.abrirSnackBar('Erro ao redefinir senha!', 'Ok');
            }
        );
        this.redirectRouter.navigate(['/login']);
        this.redefinirFlag = false;
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
