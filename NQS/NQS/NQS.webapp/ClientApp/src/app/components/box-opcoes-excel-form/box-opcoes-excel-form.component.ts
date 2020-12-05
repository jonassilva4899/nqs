import { Component, OnInit, SimpleChanges, OnChanges, Inject, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { extensaoArquivoValidator } from '@validators/extensao-arquivo.validator';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { TimesPerfil } from '@models/PegarTimePerfil';
import { ListaQuadros } from '@models/Quadro';
import { Observable } from 'rxjs';
import { BoxExcelForm, BoxExcelFormConfig } from '@models/BoxExcelForm';
import { TipoBoxExcelForm } from '@models/Enums';
import { Usuario } from '@models/Usuario';
import { PegarEditaMovimento, PegaMovimento } from '@models/Movimento';

@Component({
    selector: 'app-box-opcoes-excel-form',
    templateUrl: './box-opcoes-excel-form.component.html',
    styleUrls: ['./box-opcoes-excel-form.component.scss']
})
export class BoxOpcoesExcelFormComponent implements OnInit {

    form: FormGroup;
    arquivo: AbstractControl;
    isLoading = {
        salvar: false,
    };
    listaQuadros$: Observable<ListaQuadros[]>;
    movimento: any;
    quantidade = 0;
    quadro = new FormControl();
    quadros: Array<string> = new Array<string>();
    opcao: TipoBoxExcelForm;
    tipoEnum = TipoBoxExcelForm;
    usuario: Usuario = new Usuario();
    boxExcelConfig: BoxExcelFormConfig = new BoxExcelFormConfig();
    boxExcelFormEdit: BoxExcelForm;
    editar = false;
    idConfig: string;

    constructor(
        private _fb: FormBuilder,
        public _dialogRef: MatDialogRef<BoxOpcoesExcelFormComponent>,
        private _snackBar: SnackBar,
        @Inject(MAT_DIALOG_DATA) data,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
        this.form = this._fb.group({
            ExcelArquivoExcel: ['', [Validators.required, extensaoArquivoValidator(['.xlsx'])]],
        });

        this.arquivo = this.form.get('ExcelArquivoExcel');
        this.quadro.setValue([]);

        if (data && data.boxExcelConfig) {
            this.boxExcelConfig.timeSelecionado = data.boxExcelConfig.timeSelecionado;
            this.boxExcelConfig.titulo = data.boxExcelConfig.titulo;
            this.boxExcelConfig.tituloExemploExcel = data.boxExcelConfig.tituloExemploExcel;
            this.boxExcelConfig.exemploExcel = data.boxExcelConfig.exemploExcel;
            this.boxExcelConfig.listaQuadros$ = data.boxExcelConfig.listaQuadros$;
        }

        if (data && data.boxExcelForm) {
            this.editar = true;
            this.boxExcelFormEdit = data.boxExcelForm as BoxExcelForm;
            this.idConfig = this.boxExcelFormEdit.idConfiguracao;

            this.opcao = this.boxExcelFormEdit.tipo;
            this.arquivo.setValue(this.boxExcelFormEdit.arquivoExcel);
            this.quantidade = this.boxExcelFormEdit.valorManual;

            if (this.boxExcelFormEdit.listaQuadros) {
                this.quadro.setValue(this.boxExcelFormEdit.listaQuadros);
            }
        }
    }

    ngOnInit(): void {
        //this.buscaListaQuadros();
    }

    compareFn(o1: any, o2: any): any {
        return o1 && o2 ? o1.id === o2.id : o1 === o2;
    }

    download($event: Event): void {
        $event.stopPropagation();

        const anchor: HTMLAnchorElement = document.createElement('a');
        anchor.href = this.boxExcelFormEdit.urlArquivoExcel;
        anchor.click();
    }

    //buscaListaQuadros(): void {
    //    if (!this.boxExcelConfig.listaQuadros$) {
    //        this.listaQuadros$ = this._movCapacityService.listaDeQuadrosComboBox(this.boxExcelConfig.timeSelecionado.id);
    //    }
    //    else {
    //        this.listaQuadros$ = this.boxExcelConfig.listaQuadros$;
    //    }

    //}

    salvarConfiguracao(): void {
        this.isLoading.salvar = true;

        if (this.opcao === this.tipoEnum.Planilha && this.form.invalid
            || this.opcao === this.tipoEnum.Quadro && this.quadro.value.length < 1
            || this.opcao === this.tipoEnum.ValorManual && !this.quantidade) {
            this._snackBar.abrirSnackBar('Preencha todos os campos corretamente!', 'Ok');
            this.isLoading.salvar = false;
            return;
        }

        const boxExcel: BoxExcelForm = new BoxExcelForm();

        if (this.editar) {
            boxExcel.idConfiguracao = this.idConfig;
        }

        boxExcel.idTime = this.boxExcelConfig.timeSelecionado.id;
        boxExcel.tipo = this.opcao;
        boxExcel.arquivoExcel = this.form.get('ExcelArquivoExcel').value ? this.form.get('ExcelArquivoExcel').value[0] : '';
        boxExcel.valorManual = this.quantidade ? this.quantidade : 0;
        boxExcel.idReponsavel = this.usuario.id;
        if (this.quadro.value.length > 0) {
            this.quadro.value.forEach(elem => {
                this.quadros.push(elem.id);
            });
            boxExcel.idsQuadros = this.quadros;
        }
        this.isLoading.salvar = false;

        this._dialogRef.close(boxExcel);
    }

}
