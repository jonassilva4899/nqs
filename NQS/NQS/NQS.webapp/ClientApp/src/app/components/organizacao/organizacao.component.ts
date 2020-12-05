import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PessoaDados } from '@models/Pessoa';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Guid } from 'guid-typescript';
import { TimeService } from '@pages/times/time.service';
import { Organizacao } from '@models/Organizacao';
import { Usuario } from '@models/Usuario';
import { SnackBar } from '../snackBar/snackBar';
import { OrganizacaoService } from './organizacao.service';

@Component({
    selector: 'app-organizacao',
    templateUrl: './organizacao.component.html',
    styleUrls: ['./organizacao.component.scss']
})
export class OrganizacaoComponent implements OnInit {

    organizacaoForm: FormGroup;
    isLoading = {
        buscando: false,
        acao: false,
    };

    imageUrl = '';
    todosUsuarios: PessoaDados[] = [];
    filtroUsuarios: PessoaDados[] = [];
    textoRestante = 1000;
    usuario: Usuario;
    editar = false;
    idOrganizacao = '';

    constructor(
        private _fb: FormBuilder,
        public _dialogRef: MatDialogRef<OrganizacaoComponent>,
        private _timeService: TimeService,
        private _snackBar: SnackBar,
        private _organizacaoService: OrganizacaoService,
        @Inject(MAT_DIALOG_DATA) data,
    ) {
        this.organizacaoForm = this._fb.group({
            nome: ['', [Validators.required]],
            descricao: ['', [Validators.required]],
            localizacao: ['', [Validators.required]],
            administrador: ['', [Validators.required]]
        });

        if (data && data.idOrganizacao) {
            this.editar = true;
            this.idOrganizacao = data.idOrganizacao;
        }

        this.usuario = JSON.parse(localStorage.getItem('usuario'));
    }

    ngOnInit(): void {
        this.listarResponsaveis();

        if (this.editar) {
            this.isLoading.buscando = true;
            this.organizacaoForm.disable();

            this._organizacaoService.selecionar(this.idOrganizacao)
                .subscribe(
                    data => {
                        this.organizacaoForm.get('nome').setValue(data.nome);
                        this.organizacaoForm.get('descricao').setValue(data.descricao);
                        this.organizacaoForm.get('localizacao').setValue(data.localizacao);
                        this.organizacaoForm.get('administrador').setValue(data.pessoas[data.pessoas.length - 1]);
                        this.imageUrl = data.foto;

                        this.isLoading.buscando = false;
                        this.organizacaoForm.enable();
                    }
                );
        }
    }

    listarResponsaveis(): void {
        this._timeService.pegarUsuariosAtivos()
            .subscribe(data => {
                this.todosUsuarios = data;
                this.filtroUsuarios = data;
            });
    }

    filtraResponsaveis(event): void {
        let termoBusca = event || '';

        if (typeof termoBusca === 'object') {
            termoBusca = termoBusca.nome;
        }

        this.todosUsuarios = this.filtroUsuarios.filter(
            (unit) => unit.nome.trim().toLowerCase().indexOf(termoBusca.trim().toLowerCase()) > -1
        );
    }

    receberImagemBase64(resposta: any): void {
        this.imageUrl = resposta;
    }

    usuarioDisplayFn(usuario: PessoaDados): string {
        return usuario ? usuario.nome : '';
    }

    verificarSeNomeExiste(): void {
        setTimeout(() => {
            const formControl = this.organizacaoForm.get('administrador');
            const valor = formControl.value;

            if (typeof valor !== 'object') {
                formControl.setValue(null);
            }
        }, 250);
    }

    addEditOrganizacao(): void {

        this.isLoading.acao = true;
        const usuarioLogado: Usuario = JSON.parse(localStorage.getItem('usuario'));

        const organizacao: Organizacao = new Organizacao();
        const listaDePessoas: Array<string> = new Array<string>();
        organizacao.idUsuario = usuarioLogado.id;
        organizacao.descricao = this.organizacaoForm.get('descricao').value;
        organizacao.foto = this.imageUrl;
        organizacao.idPessoas = listaDePessoas;
        organizacao.localizacao = this.organizacaoForm.get('localizacao').value;
        organizacao.nome = this.organizacaoForm.get('nome').value;
        organizacao.responsavelCriacao = this.usuario.idPessoa;
        organizacao.dataCriacao = new Date();

        if (this.editar) {
            organizacao.id = this.idOrganizacao;
            organizacao.dataEdicao = new Date();
            organizacao.responsavelEdicao = this.usuario.idPessoa;
        }

        this._organizacaoService.adicionarEditar(JSON.stringify(organizacao))
            .subscribe(data => {
                if (!data) {
                    this._snackBar.abrirSnackBar('Falha ao criar organização...', 'Ok', 'red');
                    this._dialogRef.close();
                }
                this._snackBar.abrirSnackBar('Organização criada com sucesso!', 'Ok', 'green');
                this._dialogRef.close(true);
            }, err => {
                this._snackBar.abrirSnackBar('Falha ao criar organização...', 'Ok', 'red');
                this._dialogRef.close();
            });
    }

}
