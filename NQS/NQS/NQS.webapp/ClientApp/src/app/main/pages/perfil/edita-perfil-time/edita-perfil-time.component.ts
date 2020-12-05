import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { fuseAnimations } from '@fuse/animations';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { PerfilService } from '../perfil.service';
import { TimesPerfil, PegarTimePerfil } from 'app/models/PegarTimePerfil';
import { SnackBar } from 'app/components/snackBar/snackBar';

class TimesPerfilModelo {
    id: string;
    nome: string;
    papel: string;
}

@Component({
    selector: 'app-edita-perfil-time',
    templateUrl: './edita-perfil-time.component.html',
    styleUrls: ['./edita-perfil-time.component.scss'],
    animations: fuseAnimations
})

export class EditaPerfilTimeComponent implements OnInit {

    idPessoa: string;
    timesAntigos: PegarTimePerfil;
    meusTimes: TimesPerfil[] = [];
    todosTimes: Array<any>;

    incluirTimeForm: FormGroup;
    novoTimeFuncao: FormControl;

    colunasTabela: string[] = ['nomeTime', 'funcao', 'acoes'];

    isLoading = {
        meusTimes: false,
        salvar: false,
    };

    isEditing = {
        meusTimes: [],
    };

    constructor(
        private _formBuilder: FormBuilder,
        private _perfilService: PerfilService,
        private _snackBar: SnackBar,
        public dialogRef: MatDialogRef<EditaPerfilTimeComponent>,
        @Inject(MAT_DIALOG_DATA) data
    ) {
        this.idPessoa = data.idPessoa;
        this.isLoading.meusTimes = true;
        this._perfilService.getPegarTimePerfil(this.idPessoa)
            .subscribe(
                p => {
                    this.isLoading.meusTimes = false;
                    this.timesAntigos = JSON.parse(JSON.stringify(p));
                    this.meusTimes = JSON.parse(JSON.stringify(p.timesPessoa));
                    this.todosTimes = JSON.parse(JSON.stringify(p.todosTimes));
                },
                err => {
                    this.isLoading.meusTimes = false;
                }
            );
    }

    ngOnInit(): void {
        this.incluirTimeForm = this._formBuilder.group({
            time: ['', [Validators.required]],
            funcao: ['', [Validators.required]],
        });
        this.novoTimeFuncao = this._formBuilder.control('');
    }

    salvarNovoTime(form: FormGroup): void {
        if (form.invalid) {
            this.validarCampos(this.incluirTimeForm);
            return;
        }
        const novoTime = new TimesPerfil();
        novoTime.id = form.value.time.id;
        novoTime.nome = form.value.time.nome;
        novoTime.papel = form.value.funcao;

        this.meusTimes = [...this.meusTimes, novoTime];
        form.reset();
    }

    editarFuncao(i: number): void {
        const time = this.meusTimes[i];
        this.novoTimeFuncao.setValue(time.papel);
        this.isEditing.meusTimes[i] = true;
    }

    salvarFuncao(i: number): void {
        const time = this.meusTimes[i];
        time.papel = this.novoTimeFuncao.value;

        this.novoTimeFuncao.setValue('');
        this.isEditing.meusTimes[i] = false;
    }

    sairDoTime(i): void {
        const meusTimes = [...this.meusTimes];
        meusTimes.splice(i, 1);
        this.meusTimes = meusTimes;
    }

    salvar(): void {
        this.isLoading.salvar = true;
        this._perfilService.editarTimePerfil(this.meusTimes, this.timesAntigos, this.idPessoa)
            .subscribe(
                (res: any) => {
                    this.isLoading.salvar = false;
                    this._snackBar.abrirSnackBar('Times alterados com sucesso.', 'Ok', 'green');
                    this.dialogRef.close();
                },
                (err: any) => {
                    this.isLoading.salvar = false;
                    this._snackBar.abrirSnackBar('Falha ao alterar times.', 'Ok', 'red');
                }
            );
    }

    timeNovo(time: TimesPerfil): boolean {
        return !this.meusTimes.some((t: TimesPerfil) => t.id === time.id);
    }
    
    validarCampos(form: FormGroup): void {
        const campos = Object.keys(form.controls);

        for (const campo of campos) {
            form.get(campo).markAsDirty();
            form.get(campo).markAsTouched();
        }
    }

}
