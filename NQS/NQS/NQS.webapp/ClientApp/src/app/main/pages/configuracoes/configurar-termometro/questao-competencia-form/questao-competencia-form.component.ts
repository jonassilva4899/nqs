import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { ConfigurarTermometroService } from '../configurar-termometro.service';
import { CompetenciaFormComponent } from '../competencia-form/competencia-form.component';

import { QuestaoCompetencia, Competencia, TemperaturaQuestaoCompetencia, TemperaturaTermometroEnum } from '@models/Competencia';
import { Acao } from '@models/Enums';

@Component({
  selector: 'app-questao-competencia-form',
  templateUrl: './questao-competencia-form.component.html',
  styleUrls: ['./questao-competencia-form.component.scss']
})
export class QuestaoCompetenciaFormComponent implements OnInit, OnDestroy {

    Acao = Acao;
    acao: Acao;
    questaoCompetencia: QuestaoCompetencia;
    competencia: Competencia;

    form: FormGroup;

    isLoading = {
        salvar: false,
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
        this.questaoCompetencia = data.questaoCompetencia;
        this.competencia = data.competencia;

        this.form = this._fb.group({
            idCompetencia: ['', [Validators.required]],
            tituloQuestao: ['', [Validators.required]],
            fervendo: this._fb.group({
                idQuestaoOpcao: [''],
                descricao: ['', [Validators.required]],
            }),
            quente: this._fb.group({
                idQuestaoOpcao: [''],
                descricao: ['', [Validators.required]],
            }),
            morno: this._fb.group({
                idQuestaoOpcao: [''],
                descricao: ['', [Validators.required]],
            }),
            frio: this._fb.group({
                idQuestaoOpcao: [''],
                descricao: ['', [Validators.required]],
            }),
            congelado: this._fb.group({
                idQuestaoOpcao: [''],
                descricao: ['', [Validators.required]],
            }),
        });
    }

    ngOnInit(): void {
        this.form.get('idCompetencia').setValue(this.competencia.idCompetencia);

        if (this.acao === Acao.Edicao) {
            this.preencherForm();
        }
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    salvarQuestao(): void {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        const formData = this.form.getRawValue();
        let service;

        if (this.acao === Acao.Edicao) {
            service = this._configurarTermometroService.editarQuestaoCompetencia(formData, this.questaoCompetencia);
        } else {
            service = this._configurarTermometroService.criarQuestaoCompetencia(formData);
        }

        this.isLoading.salvar = true;
        service.pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (res: any) => {
                    this.isLoading.salvar = false;
                    this.dialogRef.close();
                },
                (err: any) => {
                    this._snackBar.abrirSnackBar('Falha ao salvar questão...', 'OK', 'red');
                    this.isLoading.salvar = false;
                }
            );
    }

    preencherForm(): void {
        const aplicarValor = (temperatura: TemperaturaQuestaoCompetencia) => {
            switch (temperatura.temperaturaTermometro) {
                case TemperaturaTermometroEnum.Fervendo:
                    this.form.get('fervendo.idQuestaoOpcao').setValue(temperatura.idQuestaoOpcao);
                    this.form.get('fervendo.descricao').setValue(temperatura.descricao);
                    break;

                case TemperaturaTermometroEnum.Quente:
                    this.form.get('quente.idQuestaoOpcao').setValue(temperatura.idQuestaoOpcao);
                    this.form.get('quente.descricao').setValue(temperatura.descricao);
                    break;

                case TemperaturaTermometroEnum.Morno:
                    this.form.get('morno.idQuestaoOpcao').setValue(temperatura.idQuestaoOpcao);
                    this.form.get('morno.descricao').setValue(temperatura.descricao);
                    break;

                case TemperaturaTermometroEnum.Frio:
                    this.form.get('frio.idQuestaoOpcao').setValue(temperatura.idQuestaoOpcao);
                    this.form.get('frio.descricao').setValue(temperatura.descricao);
                    break;

                case TemperaturaTermometroEnum.Congelado:
                    this.form.get('congelado.idQuestaoOpcao').setValue(temperatura.idQuestaoOpcao);
                    this.form.get('congelado.descricao').setValue(temperatura.descricao);
                    break;

                default:
                    break;
            }
        };

        this.form.get('tituloQuestao').setValue(this.questaoCompetencia.tituloQuestao);
        this.questaoCompetencia.questaoOpcoes.map((questao) => {
            aplicarValor(questao);
        });
    }

}
