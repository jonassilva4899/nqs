import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { PerfilService } from '../perfil.service';
import { PersonalMapping, PersonalMappingItem } from 'app/models/PersonalMapping';
import { Acao } from 'app/models/Enums';

@Component({
  selector: 'app-form-personal-mapping',
  templateUrl: './form-personal-mapping.component.html',
  styleUrls: ['./form-personal-mapping.component.scss'],
  providers: [PerfilService]
})
export class FormPersonalMappingComponent implements OnInit {

    Acao = Acao;

    form: FormGroup = this.fb.group({
        titulo: ['', [Validators.required]],
        itens: this.fb.array([], [Validators.required]),
        descricao: ''
    });

    isLoading = {
        salvar: false,
    };

    constructor(
        private fb: FormBuilder,
        private _perfilService: PerfilService,
        private dialogRef: MatDialogRef<FormPersonalMappingComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) { }

    ngOnInit(): void {
        if (this.data.acao === Acao.Edicao) {
            this.preencherForm();
        }
    }

    adicionarItem(event: Event): void {
        event.preventDefault();

        const descricao = this.form.get('descricao');

        if (descricao.value) {
            (this.form.get('itens') as FormArray).push(
                this.fb.control({nomeItem: descricao.value})
            );
        }

        descricao.setValue('');
        descricao.clearValidators();
        descricao.updateValueAndValidity();
    }

    removerItem(index: number): void {
        (this.form.get('itens') as FormArray).removeAt(index);
    }

    preencherForm(): void {
        const personalMapping: PersonalMapping = this.data.personalMapping;

        this.form.get('titulo').setValue(personalMapping.titulo);
        personalMapping.itens.map((item: PersonalMappingItem) => {
            (this.form.get('itens') as FormArray).push(
                this.fb.control(item)
            );
            return;
        });
    }

    salvar(): void {
        const data = this.data;

        if (!this.validarCampos()) {
          return;
        }

        data.personalMapping = {
            ...data.personalMapping,
            ...this.form.value
        };
        this.isLoading.salvar = true;

        if (this.data.acao === Acao.Edicao) {
            this.putPersonalMapping(data);
        } else {
            this.postPersonalMapping(data);
        }
    }

    postPersonalMapping(data: any): void {
        this._perfilService.postPersonalMapping(data)
            .subscribe((res: any) => {
                this.isLoading.salvar = false;
                this.dialogRef.close({
                    atualizar: true,
                });
            }, (err: any) => {
                this.isLoading.salvar = false;
            });
    }

    putPersonalMapping(data: any): void {
        this._perfilService.putPersonalMapping(data)
            .subscribe((res: any) => {
                this.isLoading.salvar = false;
                this.dialogRef.close({
                    atualizar: true,
                });
            }, (err: any) => {
                this.isLoading.salvar = false;
            });
    }

    validarCampos(): boolean {
        const descricao = this.form.get('descricao');

        if (descricao.value) {
            (this.form.get('itens') as FormArray).push(this.fb.control({nomeItem: descricao.value}));
        }

        if (!this.form.get('itens').value.length) {
            descricao.setValidators([Validators.required]);
            descricao.updateValueAndValidity();
        }

        if (this.form.valid) {
            return true;
        }

        return false;
    }

    fechar(): void {
        this.dialogRef.close();
    }

}
