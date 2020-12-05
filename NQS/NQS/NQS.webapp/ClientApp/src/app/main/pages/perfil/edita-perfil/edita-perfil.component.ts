import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { fuseAnimations } from '@fuse/animations';

import { TelefoneMascara } from 'app/helpers/mascara-telefone';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { PerfilService } from '../perfil.service';

import { Usuario } from '@models/Usuario';
import { EditaPerfil } from '@models/EditaPerfil';
import { Permissao, NivelPermissao } from '@models/Permissoes';
import { ExibirParaNiveisDirective } from '@shared/directives/exibir-para-niveis.directive';

@Component({
    selector: 'app-edita-perfil',
    templateUrl: './edita-perfil.component.html',
    styleUrls: ['./edita-perfil.component.scss'],
    animations: fuseAnimations
})
export class EditaPerfilComponent implements OnInit {

    NivelPermissao = NivelPermissao;

    pessoa: EditaPerfil;

    editaPerfilForm: FormGroup;
    valueOfInput = '';
    imageUrl = '';
    idPessoa: string;
    atualizar = false;
    idResponsavel: Usuario = new Usuario();
    listaPermissoes: Permissao[];

    isLoading = {
        salvar: false,
        getPerfil: false,
        permissoes: false,
    };

    exibirParaNiveis = new ExibirParaNiveisDirective();

    constructor(
        private _formBuilder: FormBuilder,
        private mascaraTel: TelefoneMascara,
        private _perfilService: PerfilService,
        private _snackBar: SnackBar,
        public dialogRef: MatDialogRef<EditaPerfilComponent>,
        @Inject(MAT_DIALOG_DATA) data,
    ) {
        this.idPessoa = data.idPessoa;
        this.idResponsavel = JSON.parse(localStorage.getItem('usuario'));
        this.editaPerfilForm = this._formBuilder.group({
            nome: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            telefone: ['', [Validators.required]],
            funcaoPrincipal: ['', [Validators.required]],
            miniBio: [''],
            eUsuario: [false, []],
            status: [false, []],
            nivelPermissao: ['', [Validators.required]],
            eContaGoogle: [false, []]
        });
    }

    ngOnInit(): void {
        this.exibirParaNiveis.exibirParaNiveis = [
            NivelPermissao.GoobeeAdmin,
            NivelPermissao.OrganizationAdmin,
            NivelPermissao.AgileCoach,
            NivelPermissao.TeamLeader,
        ];
        this.exibirParaNiveis.exibirParaNiveisOuSeMesmaPessoa = this.idPessoa;

        this.editaPerfilForm.get('eContaGoogle').valueChanges
            .subscribe((value) => {
                this.contaGoogle(value);
            });

        this.getPerfilParaEdicao();
        this.getPermissoesParaUsuarioLogado();
    }

    mascaraTelefone(event): void {
        this.valueOfInput = this.mascaraTel.inputMascaraTelefone(event);
    }

    receberImagemBase64(resposta: any): void {
        this.imageUrl = resposta;
    }

    getPerfilParaEdicao(): void {
        this.isLoading.getPerfil = true;
        this.editaPerfilForm.disable();
        this._perfilService.getPerfilParaEdicao(this.idPessoa).subscribe(
            data => {
                this.pessoa = data;

                this.editaPerfilForm.patchValue({
                    nome: data.nome,
                    email: data.email,
                    telefone: data.telefone,
                    funcaoPrincipal: data.funcaoPrincipal,
                    miniBio: data.miniBio,
                    eUsuario: data.eUsuario,
                    status: data.status,
                    nivelPermissao: data.nivelPermissao,
                    eContaGoogle: data.eContaGoogle
                });
                this.imageUrl = data.foto;

                if (this.exibirParaNiveis.temPermissao) {
                    this.editaPerfilForm.enable();
                }

                if (this.idResponsavel.roleEnum === NivelPermissao.TeamMember) {
                    this.editaPerfilForm.get('status').disable();
                    this.editaPerfilForm.get('nivelPermissao').disable();
                    this.editaPerfilForm.get('eUsuario').disable();
                }

                this.isLoading.getPerfil = false;
            }
        );
    }

    editarPerfil(): void {
        if (this.editaPerfilForm.invalid) {
            this.validarCampos(this.editaPerfilForm);
            return;
        }

        const camposFormularios = this.editaPerfilForm.getRawValue();
        const perfil = {
            id: this.idPessoa,
            foto: this.imageUrl,
            nome: camposFormularios.nome,
            funcaoPrincipal: camposFormularios.funcaoPrincipal,
            email: camposFormularios.email,
            telefone: camposFormularios.telefone,
            miniBio: camposFormularios.miniBio,
            eUsuario: camposFormularios.eUsuario,
            status: camposFormularios.status,
            nivelPermissao: camposFormularios.nivelPermissao,
            idResponsavelEdicao: this.idResponsavel.idPessoa,
            eContaGoogle: camposFormularios.eContaGoogle,
            senha: camposFormularios.senha ? camposFormularios.senha : null,
            confirmacaoSenha: camposFormularios.senhaConfirmacao ? camposFormularios.senhaConfirmacao : null
        };

        this.isLoading.salvar = true;
        this._perfilService.editaPerfil(JSON.stringify(perfil), this.idPessoa)
            .subscribe(
                data => {
                    this.atualizar = true;
                    this.isLoading.salvar = false;
                    this._snackBar.abrirSnackBar('Perfil editado com sucesso!', 'Ok');
                    this.dialogRef.close(this.atualizar);
                },
                err => {
                    this.isLoading.salvar = false;
                    this._snackBar.abrirSnackBar('Falha ao editar Perfil...', 'Ok');
                });
    }

    getPermissoesParaUsuarioLogado(): void {
        this.isLoading.permissoes = true;
        this._perfilService.getPermissoesParaUsuarioLogado()
            .subscribe(
                (listaPermissoes: Permissao[]) => {
                    this.listaPermissoes = listaPermissoes;
                    this.isLoading.permissoes = false;
                }
            );
    }

    validarCampos(form: FormGroup): void {
        const campos = Object.keys(form.controls);

        for (const campo of campos) {
            form.get(campo).markAsDirty();
            form.get(campo).markAsTouched();
        }
    }

    contaGoogle(eContaGoogle: boolean): void {
        if (eContaGoogle && this.editaPerfilForm.get('senha') && this.editaPerfilForm.get('senhaConfirmacao')) {
            this.editaPerfilForm.removeControl('senha');
            this.editaPerfilForm.removeControl('senhaConfirmacao');
        } else if (this.pessoa.eContaGoogle) {
            this.editaPerfilForm.addControl('senha', new FormControl('', [Validators.required, confirmacaoSenhaValidacao]));
            this.editaPerfilForm.addControl('senhaConfirmacao', new FormControl('', [Validators.required, confirmacaoSenhaValidacao]));
        }
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

