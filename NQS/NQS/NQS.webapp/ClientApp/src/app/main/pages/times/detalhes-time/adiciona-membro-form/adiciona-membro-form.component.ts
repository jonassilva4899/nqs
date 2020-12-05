import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder, AbstractControl } from '@angular/forms';
import { TimeService } from '../../time.service';
import { PessoaDados } from 'app/models/Pessoa';
import { fuseAnimations } from '@fuse/animations';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { SnackBar } from '../../../../../components/snackBar/snackBar';
import { Membros } from '@models/TimeDetalhe';
import { Usuario } from '@models/Usuario';
import { TratarStringService } from '@shared/services/tratar-string.service';

@Component({
    selector: 'app-adiciona-membro-form',
    templateUrl: './adiciona-membro-form.component.html',
    styleUrls: ['./adiciona-membro-form.component.scss'],
    animations: fuseAnimations
})
export class AdicionaMembroFormComponent implements OnInit {
    adicionaMembroForm: FormGroup;
    idResponsavelEdicao: string;
    pessoasAtivas: PessoaDados[];
    pessoasAtivasFiltro: PessoaDados[];
    listaDeMembros = new FormControl('', Validators.required);
    membroAdicionar: PessoaDados;
    idTimeRota: string;
    esperaReqFlag = false;
    idRoute: string;
    papelNoTime = new FormControl('', Validators.required);
    editarMembro = false;
    membroEdicao: Membros = new Membros();

    isLoading = {
        pessoasAtivas: false,
    };

    constructor(
        private _timeServico: TimeService,
        private dialogRef: MatDialogRef<AdicionaMembroFormComponent>,
        private _snackBar: SnackBar,
        private _formBuilder: FormBuilder,
        @Inject(MAT_DIALOG_DATA) data) {
        this.idRoute = data.idRoute;

        if (data.edicao && data.membro) {
            let usuario: Usuario = new Usuario();
            usuario = JSON.parse(localStorage.getItem('usuario'));
            this.idResponsavelEdicao = usuario.idPessoa;
            this.editarMembro = true;
            this.membroEdicao = data.membro;
        }

    }

    ngOnInit(): void {
        this.getPessoas().then(() => {
            if (this.editarMembro) {
                const membro = this.pessoasAtivas.find((pessoa) => pessoa.id === this.membroEdicao.idPessoa);
                this.listaDeMembros.setValue(membro);
                this.listaDeMembros.disable();
                this.papelNoTime.setValue(this.membroEdicao.papel);
                this.membroEdicao.idResponsavelEdicao = this.idResponsavelEdicao;
            }
        });

        this.listaDeMembros.valueChanges.subscribe((valor) => {
            this.filtrarLista(valor, 'nome', 'pessoasAtivas', 'pessoasAtivasFiltro');
        });
    }

    getPessoas(): Promise<any> {
        return new Promise((resolve, reject) => {
            this.isLoading.pessoasAtivas = true;
            this._timeServico.pegarUsuariosAtivos()
                .subscribe(
                    elem => {
                        this.pessoasAtivas = elem;
                        this.pessoasAtivasFiltro = elem;
                        this.isLoading.pessoasAtivas = false;
                        resolve();
                    },
                    err => {
                        this.isLoading.pessoasAtivas = false;
                        reject();
                    }
                );
        });
    }

    addMembro(): void {

        if (this.listaDeMembros.invalid || this.papelNoTime.value === '') {
            this.papelNoTime.markAsDirty();
            this.papelNoTime.markAsTouched();
            return;
        }

        this.esperaReqFlag = true;
        this._timeServico.pegarUsuariosAtivos().subscribe(
            data => {
                this.membroAdicionar = this.listaDeMembros.value;

                const membro: Membros = new Membros();
                membro.idTime = this.idRoute;
                membro.nome = this.membroAdicionar.nome;
                membro.idPessoa = this.membroAdicionar.id;
                membro.papel = this.papelNoTime.value;
                membro.idResponsavelEdicao = this.idResponsavelEdicao;

                if (!this.editarMembro) {
                    this._timeServico.adicionaMembroTime(JSON.stringify(membro)).subscribe(
                        () => {
                            this._snackBar.abrirSnackBar('Membro adicionado ao time com Sucesso!', 'Ok');
                            this.dialogRef.close(true);
                            this.esperaReqFlag = false;
                        },
                        err => {
                            this._snackBar.abrirSnackBar('Falha ao adicionar novo membro no time...', 'Ok');
                            this.esperaReqFlag = false;
                        }
                    );
                }
                else {
                    this._timeServico.editarMembroTime(JSON.stringify(membro)).subscribe(
                        () => {
                            this._snackBar.abrirSnackBar('Membro do time editado com Sucesso!', 'Ok');
                            this.dialogRef.close(true);
                            this.esperaReqFlag = false;
                        },
                        err => {
                            this._snackBar.abrirSnackBar('Falha ao editar membro do time...', 'Ok', 'red');
                            this.esperaReqFlag = false;
                        }
                    );
                }
            }
        );
    }

    exibirNomeNoAutoComplete(chave: string): any {
        return (valor: any): string => {
            return valor && valor[chave] ? valor[chave] : '';
        };
    }

    verificarSeNomeExiste(control: AbstractControl): void {
        setTimeout(() => {
            const valor = control.value;
            if (typeof valor !== 'object') {
                control.setValue(null);
            }
        }, 100);
    }

    filtrarLista(valor: string, chave: string, nomeLista: string, nomeListaFiltro: string): void {
        if (valor && typeof valor !== 'string') {
            valor = valor[chave];
        }

        this[nomeListaFiltro] = this[nomeLista].filter((item) =>
            TratarStringService.busca(item[chave])
                .includes(valor ? TratarStringService.busca(valor) : '')
        );
    }
}
