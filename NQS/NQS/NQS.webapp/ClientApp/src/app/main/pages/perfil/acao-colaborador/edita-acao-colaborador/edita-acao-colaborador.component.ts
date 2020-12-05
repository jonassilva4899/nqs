import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PerfilService } from '@pages/perfil/perfil.service';
import { Observable } from 'rxjs';
import { AcoesColaborador, ListaResponsaveis } from '@models/AcoesColaborador';
import { fuseAnimations } from '@fuse/animations';
import { SnackBar } from 'app/components/snackBar/snackBar';

interface EstadoAcao {
    valor: number;
    estado: string;
}

@Component({
    selector: 'app-edita-acao-colaborador',
    templateUrl: './edita-acao-colaborador.component.html',
    styleUrls: ['./edita-acao-colaborador.component.scss'],
    animations: fuseAnimations
})
export class EditaAcaoColaboradorComponent implements OnInit {

    editarAcaoForm: FormGroup;
    listaEstadosAcao: EstadoAcao[] = [
        { valor: 1, estado: 'Não Iniciado' },
        { valor: 2, estado: 'Iniciada' },
        { valor: 3, estado: 'Bloqueada' },
        { valor: 4, estado: 'Concluída' }
    ];
    acaoModelo$: Observable<AcoesColaborador>;
    novaAcao: AcoesColaborador = new AcoesColaborador();
    listaMembros$: Observable<ListaResponsaveis[]>;
    idPessoa: string;
    idPessoaCriacao: string;
    idResponsavel: string;
    idAcao: string;
    progressBarEstado = false;
    atualizar = false;

    constructor(
        private _formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<EditaAcaoColaboradorComponent>,
        private _snackBar: SnackBar,
        private _perfilService: PerfilService,
        @Inject(MAT_DIALOG_DATA) private data,
    ) {
        this.idPessoa = data.idPessoa;
        this.idAcao = data.idAcao;

        this.editarAcaoForm = this._formBuilder.group({
            nomeAcao: [''],
            detalheAcao: [''],
            data: [''],
            responsavel: [''],
            status: ['']
        });

        this._perfilService.pegaAcaoColaborador(this.idPessoa, this.idAcao)
            .subscribe(x => {
                this.editarAcaoForm.get('nomeAcao').setValue(x.nomeAcao);
                this.editarAcaoForm.get('detalheAcao').setValue(x.detalheAcao);
                this.editarAcaoForm.get('data').setValue(x.data);
                this.editarAcaoForm.get('responsavel').setValue(x.idResponsavel);
                this.editarAcaoForm.get('status').setValue(x.status);
                this.idPessoaCriacao = x.idPessoaCriacao;
            });
        this.listaMembros$ = this._perfilService.listaResponsaveisAcoes(this.idPessoa);
    }

    ngOnInit(): void {
    }

    editarAcao(): void {
        if (this.editarAcaoForm.invalid) {
            return;
        }
        this.progressBarEstado = true;
        this.novaAcao.data = this.editarAcaoForm.get('data').value;
        this.novaAcao.detalheAcao = this.editarAcaoForm.get('detalheAcao').value;
        this.novaAcao.id = this.idAcao;
        this.novaAcao.idPessoaCriacao = this.idPessoaCriacao;
        this.novaAcao.idResponsavel = this.editarAcaoForm.get('responsavel').value;
        this.novaAcao.nomeAcao = this.editarAcaoForm.get('nomeAcao').value;
        this.novaAcao.status = this.editarAcaoForm.get('status').value;

        this._perfilService.editarAcaoColaborador(JSON.stringify(this.novaAcao))
            .subscribe(
                data => {
                    this.atualizar = true;
                    this._snackBar.abrirSnackBar('Ação do colaborador editada com sucesso!', 'Ok');
                    this.progressBarEstado = false;
                    this.dialogRef.close(this.atualizar);
                },
                err => {
                    this._snackBar.abrirSnackBar('Falha ao editar ação do colaborador...', 'Ok');
                    this.progressBarEstado = false;
                    this.dialogRef.close();
                });
    }

    fechar(): void{
        this.dialogRef.close(this.atualizar);
    }

}
