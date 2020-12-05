import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { ConfigurarTermometroService } from '../configurar-termometro.service';
import { TratarStringService } from '@shared/services/tratar-string.service';

import { Competencia } from '@models/Competencia';
import { PraticaAgil } from '@models/PraticaAgil';
import { Acao } from '@models/Enums';

@Component({
  selector: 'app-competencia-form',
  templateUrl: './competencia-form.component.html',
  styleUrls: ['./competencia-form.component.scss']
})
export class CompetenciaFormComponent implements OnInit, OnDestroy {

    Acao = Acao;
    acao: Acao;
    competencia: Competencia;

    listaPraticas: PraticaAgil[] = [];
    listaPraticasFiltro: PraticaAgil[] = [];

    form: FormGroup;

    isLoading = {
        salvar: false,
        listaPraticas: false,
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _configurarTermometroService: ConfigurarTermometroService,
        private _fb: FormBuilder,
        private _snackBar: SnackBar,
        public dialogRef: MatDialogRef<CompetenciaFormComponent>,
        @Inject(MAT_DIALOG_DATA) public data,
    ) {
        this.acao = data.acao;
        this.competencia = data.competencia;

        this.form = this._fb.group({
            nome: ['', [Validators.required]],
            descricao: ['', [Validators.required]],
            praticasAgeis: [[], [Validators.required, Validators.minLength(1)]],
        });
    }

    ngOnInit(): void {
        //this.getPraticasAgeis();

        if (this.acao === Acao.Edicao) {
            this.preencherForm();
        }
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    //getPraticasAgeis(): void {
    //    this.isLoading.listaPraticas = true;
    //    //this._configurarTermometroService.getPraticasAgeis()
    //        .pipe(takeUntil(this._unsubscribeAll))
    //        .subscribe(
    //            (listaPraticas: PraticaAgil[]) => {
    //                this.listaPraticas = listaPraticas;
    //                this.listaPraticasFiltro = listaPraticas;
    //                this.isLoading.listaPraticas = false;
    //            },
    //            (err: any) => {
    //                this._snackBar.abrirSnackBar('Falha ao buscar Práticas Ágeis...', 'OK', 'red');
    //                this.isLoading.listaPraticas = false;
    //            }
    //        );
    //}

    filtrarPraticasAgeis(valor: string): void {
        this.listaPraticasFiltro = this.listaPraticas.filter(
            (pratica) => TratarStringService.busca(pratica.nomePraticaAgil)
                .includes(TratarStringService.busca(valor))
        );
    }

    compareFn(o1: PraticaAgil, o2: PraticaAgil): any {
        return o1 && o2 ? o1.idPraticaAgil === o2.idPraticaAgil : o1 === o2;
    }

    salvarCompetencia(): void {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        const formData = this.form.getRawValue();
        let service;

        if (this.acao === Acao.Edicao) {
            service = this._configurarTermometroService.editarCompetencia(formData, this.competencia);
        } else {
            service = this._configurarTermometroService.criarCompetencia(formData);
        }

        this.isLoading.salvar = true;
        service.pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (res: any) => {
                    this.isLoading.salvar = false;
                    this.dialogRef.close();
                },
                (err: any) => {
                    this._snackBar.abrirSnackBar('Falha ao salvar competência...', 'OK', 'red');
                    this.isLoading.salvar = false;
                }
            );
    }

    preencherForm(): void {
        this.form.patchValue({
            ...this.competencia,
        });
    }

}
