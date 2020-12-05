import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { MatDialogRef, MAT_DIALOG_DATA, MatChipInputEvent, MatAutocompleteSelectedEvent } from '@angular/material';
import { fuseAnimations } from '@fuse/animations';
import { Guid } from 'guid-typescript';
import { SnackBar } from '../../../../components/snackBar/snackBar';

import { TimeService } from '../time.service';

import { TimeDetalhe, TimeDetalheDados, EditarTime, TimeGrupo } from '@models/TimeDetalhe';
import { Usuario } from '@models/Usuario';
import { TratarStringService } from '@shared/services/tratar-string.service';

@Component({
    selector: 'app-cria-time-form',
    templateUrl: './cria-time-form.component.html',
    styleUrls: ['./cria-time-form.component.scss'],
    animations: fuseAnimations
})
export class CriaTimeFormComponent implements OnInit {

    @ViewChild('chipList', {static: true}) chipList;

    criarTimeForm: FormGroup;
    timeDados: any;
    idTimeRota = '';
    imageUrl = '';
    atualizar = false;
    esperaReqFlag = false;
    modeloCriarTime: any;
    editar = false;
    detalheTime: TimeDetalheDados = new TimeDetalheDados();
    usuario: Usuario = new Usuario();

    tags: TimeGrupo[] = [];
    tagsInseridas: TimeGrupo[] = [];
    readonly separatorKeysCodes: number[] = [ENTER, COMMA];

    isLoading = {
        grupos: false,
    };

    constructor(
        private _formBuilder: FormBuilder,
        private _timeService: TimeService,
        private _snackBar: SnackBar,
        private _dialogRef: MatDialogRef<CriaTimeFormComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
        private _rota: ActivatedRoute,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
        if (data && data.editar) {
            this.editar = data.editar;
            this.detalheTime = data.editarTime;
            this.idTimeRota = data.idTime;
        }
    }

    ngOnInit(): void {
        this.criarTimeForm = this._formBuilder.group({
            nome: ['', Validators.required],
            proposito: ['', Validators.required],
            valores: ['', Validators.required],
            bioTime: [''],
            acordos: [''],
            localizacao: [''],
            grupos: [''],
            capacity: [''],
            ativo: ['']
        });

        this.criarTimeForm.get('grupos').valueChanges
            .subscribe((value: any) => {
                if (value) {
                    this.chipList.errorState = false;
                }
            });

        if (this.editar) {
            this.preencheCamposEditar();
        }

        this.getGrupos();
    }

    preencheCamposEditar(): void {
        this.criarTimeForm.get('nome').setValue(this.detalheTime.nome);
        this.criarTimeForm.get('proposito').setValue(this.detalheTime.proposito);
        this.criarTimeForm.get('valores').setValue(this.detalheTime.valores);
        this.criarTimeForm.get('localizacao').setValue(this.detalheTime.localizacao);
        this.criarTimeForm.get('acordos').setValue(this.detalheTime.acordos);
        this.criarTimeForm.get('ativo').setValue(this.detalheTime.ativo);
        this.criarTimeForm.get('bioTime').setValue(this.detalheTime.bioTime);
        this.criarTimeForm.get('capacity').setValue(this.detalheTime.capacity);
        this.tagsInseridas = this.detalheTime.grupos;
        this.imageUrl = this.detalheTime.logo;
    }

    criarTime(): void {
        this.esperaReqFlag = true;
        this.timeDados = this.criarTimeForm.getRawValue();

        if (this.criarTimeForm.invalid) {
            this.validarCampos(this.criarTimeForm);
            this.esperaReqFlag = false;
            return;
        }

        if (!this.editar) {
            this.modeloCriarTime = {
                nome: this.timeDados.nome,
                logo: this.imageUrl,
                proposito: this.timeDados.proposito,
                valores: this.timeDados.valores,
                localizacao: this.timeDados.localizacao,
                grupos: this.tagsInseridas,
                bioTime: this.timeDados.bioTime,
                acordos: this.timeDados.acordos,
                capacity: this.timeDados.capacity,
                ativo: this.timeDados.ativo ? true : false,
                dataCriacao: new Date(),
                responsavelCriacao: Guid.create().toString(),
                configuracoes: []
            };

            this._timeService.criarTimes(JSON.stringify(this.modeloCriarTime))
                .subscribe(
                    () => {
                        this.atualizar = true;
                        this._snackBar.abrirSnackBar('Time criado com sucesso!', 'Ok');
                        this._dialogRef.close(this.atualizar);
                        this.esperaReqFlag = false;
                    },
                    err => {
                        this._snackBar.abrirSnackBar('Falha ao criar novo Time...', 'Ok');
                        this.esperaReqFlag = false;
                    }
                );
        }
        else {
            const modeloEditarTime: EditarTime = new EditarTime();
            modeloEditarTime.dataEdicao = new Date();
            modeloEditarTime.idResponsavelEdicao = this.usuario.idPessoa;
            modeloEditarTime.localizacao = this.timeDados.localizacao;
            modeloEditarTime.grupos = this.tagsInseridas;
            modeloEditarTime.logo = this.timeDados.logo;
            modeloEditarTime.nome = this.timeDados.nome;
            modeloEditarTime.proposito = this.timeDados.proposito;
            modeloEditarTime.valores = this.timeDados.valores;
            modeloEditarTime.logo = this.imageUrl;
            modeloEditarTime.ativo = this.timeDados.ativo;
            modeloEditarTime.capacity = this.timeDados.capacity;
            modeloEditarTime.bioTime = this.timeDados.bioTime;
            modeloEditarTime.acordos = this.timeDados.acordos;

            this._timeService.editarTime(this.idTimeRota, JSON.stringify(modeloEditarTime))
                .subscribe(
                    data => {
                        this.atualizar = true;
                        this._snackBar.abrirSnackBar('Time editado com sucesso!', 'Ok');
                        this._dialogRef.close(modeloEditarTime);
                        this.esperaReqFlag = false;
                    },
                    err => {
                        this._snackBar.abrirSnackBar('Falha ao editar time...', 'Ok');
                        this.esperaReqFlag = false;
                    }
                );
        }
    }

    receberImagemBase64(resposta: any): void {
        this.imageUrl = resposta;
    }

    getGrupos(): void {
        this.isLoading.grupos = true;

        this._timeService.getGrupos()
            .subscribe(
                (listaGrupos: any) => {
                    this.isLoading.grupos = false;
                    this.tags = listaGrupos;
                },
                (err: any) => {
                    this.isLoading.grupos = false;
                },
            );
    }

    removerTag(tag: any): void {
        const tagIndex = this.tagsInseridas.findIndex(t => t.nome === tag.nome);
        this.tagsInseridas.splice(tagIndex, 1);
    }

    adicionarTagInput(event: MatChipInputEvent, inputForm: any): void {
        let input;
        let value;

        input = event.input;
        value = input.value.trim();

        if (!value) {
            return;
        }

        this.adicionarTag({
            nome: value,
        }, inputForm);
    }

    adicionarTagSelect(event: MatAutocompleteSelectedEvent, inputForm: any): void {
        let input;
        input = event.option;
        this.adicionarTag(input.value, inputForm);
    }

    adicionarTag(tag: any, inputForm: any): void {
        const tagsInseridas = this.tagsInseridas;
        const tagRepetida = tagsInseridas.find(
            t => TratarStringService.busca(t.nome) === TratarStringService.busca(tag.nome)
        );
        const tagExiste = this.tags.find(
            t => TratarStringService.busca(t.nome).includes(TratarStringService.busca(tag.nome))
        );

        if (!tagRepetida && !tagExiste) {
            tagsInseridas.push(tag);
        } else if (!tagRepetida && tagExiste) {
            tagsInseridas.push(tagExiste);
        }

        this.criarTimeForm.get('grupos').setValue('');
        if (inputForm) {
            inputForm.value = '';
        }
    }

    tagsNaoAdicionadas(): Array<any> {
        let nome;
        const filtro = this.criarTimeForm.get('grupos');

        if (typeof filtro.value === 'string') {
            nome = filtro.value;
        } else {
            nome = filtro.value.nome;
        }

        nome = nome ? nome.trim().toLowerCase() : '';

        return this.tags.filter((tag: any) => {
            const cond1 = this.tagsInseridas.some((t: any) => t.nome === tag.nome);
            const cond2 = tag.nome.trim().toLowerCase().indexOf(nome) > -1;
            return !cond1 && cond2;
        });
    }

    validarCampos(form: FormGroup): void {
        const campos = Object.keys(form.controls);

        for (const campo of campos) {
            form.get(campo).markAsDirty();
            form.get(campo).markAsTouched();
        }

        if (!this.tagsInseridas.length) {
            this.chipList.errorState = true;
        } else {
            this.chipList.errorState = false;
        }
    }

}
