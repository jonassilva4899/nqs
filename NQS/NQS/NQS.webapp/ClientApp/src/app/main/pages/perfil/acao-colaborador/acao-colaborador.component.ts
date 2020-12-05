import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AcoesColaborador, ListaResponsaveis } from 'app/models/AcoesColaborador';
import { fuseAnimations } from '@fuse/animations';
import { PerfilService } from '../perfil.service';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Observable } from 'rxjs';
import { SelecionarTimeService } from 'app/components/selecionar-time/selecionar-time.service';
import { TimesPerfil } from '@models/PegarTimePerfil';

interface EstadoAcao {
    valor: number;
    estado: string;
}

@Component({
    selector: 'app-acao-colaborador',
    templateUrl: './acao-colaborador.component.html',
    styleUrls: ['./acao-colaborador.component.scss'],
    animations: fuseAnimations
})
export class AcaoColaboradorComponent implements OnInit {

    adicionaAcaoForm: FormGroup;
    atualizar = false;
    idPessoa: string;
    idResponsavel: string;
    progressBarEstado = false;
    acaoColaborador: AcoesColaborador;
    listaEstadosAcao: EstadoAcao[] = [
        { valor: 1, estado: 'Não Iniciado' },
        { valor: 2, estado: 'Iniciada' },
        { valor: 3, estado: 'Bloqueada' },
        { valor: 4, estado: 'Concluída' }
    ];
    listaMembros$: Observable<ListaResponsaveis[]>;

    constructor(
        private _formBuilder: FormBuilder,
        private _perfilService: PerfilService,
        private _snackBar: SnackBar,
        private dialogRef: MatDialogRef<AcaoColaboradorComponent>,
        private _selecionarTimeService: SelecionarTimeService,
        @Inject(MAT_DIALOG_DATA) data
    ) {
        this.idPessoa = data.idPessoa;
        this.idResponsavel = data.idResponsavel;

        this._selecionarTimeService.timeSelecionado
            .subscribe((timeSelecionado: TimesPerfil) => {
                if (timeSelecionado) {
                    this.listaMembros$ = this._perfilService.listaResponsaveisAcoes(timeSelecionado.id);
                }
            });


        this.adicionaAcaoForm = this._formBuilder.group({
            nomeAcao: ['', [Validators.required]],
            detalheAcao: ['', [Validators.required]],
            data: ['', [Validators.required]],
            responsavel: ['', [Validators.required]],
            status: ['', [Validators.required]]
        });
    }

    ngOnInit(): void {
    }

    adicionarAcao(): void {
        if (this.adicionaAcaoForm.invalid) {
            return;
        }
        this.progressBarEstado = true;
        const resultadoForm: AcoesColaborador = new AcoesColaborador();
        resultadoForm.data = this.adicionaAcaoForm.get('data').value;
        resultadoForm.detalheAcao = this.adicionaAcaoForm.get('detalheAcao').value;
        resultadoForm.idPessoaCriacao = this.idPessoa;
        resultadoForm.idResponsavel = this.adicionaAcaoForm.get('responsavel').value;
        resultadoForm.nomeAcao = this.adicionaAcaoForm.get('nomeAcao').value;
        resultadoForm.status = this.adicionaAcaoForm.get('status').value;

        this._perfilService.adicionaAcaoColaborador(JSON.stringify(resultadoForm))
            .subscribe(
                data => {
                    this.atualizar = true;
                    this._snackBar.abrirSnackBar('Ação adicionado com sucesso!', 'Ok');
                    this.progressBarEstado = false;
                    this.dialogRef.close(this.atualizar);
                },
                err => {
                    this._snackBar.abrirSnackBar('Falha ao adicionar ação ao colaborador...', 'Ok');
                    this.progressBarEstado = false;
                    this.dialogRef.close();
                });
    }

    fechar(): void{
        this.dialogRef.close(this.atualizar);
    }
}
