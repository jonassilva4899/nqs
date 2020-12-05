import { Component, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { PerfilService } from '../perfil.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { EditarClientePerfil, ClientePerfil, EditarClienteModelo } from 'app/models/ClientePerfil';
import { Observable, empty } from 'rxjs';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { Usuario } from 'app/models/Usuario';

@Component({
    selector: 'app-edita-perfil-cliente',
    templateUrl: './edita-perfil-cliente.component.html',
    styleUrls: ['./edita-perfil-cliente.component.scss'],
    animations: fuseAnimations
})
export class EditaPerfilClienteComponent implements OnInit {

    colunasTabela: string[] = ['nome', 'dataInicio', 'dataFim', 'acao'];

    criaCliente = true;
    dataInicioCtrl: FormControl;
    dataFimCtrl: FormControl;
    novoClienteCtrl: FormControl;
    novoCliente = true;
    esperaAtualizar = false;
    idPessoa: string;

    clienteModelo: ClientePerfil = new ClientePerfil();
    editarClienteModelo: EditarClienteModelo = new EditarClienteModelo();
    listaClientes$: Observable<EditarClientePerfil>;
    todosClientes: ClientePerfil[] = [];
    filtroClientes: ClientePerfil[] = [];
    clientesPessoais: ClientePerfil[] = [];

    mostraBotaoAdd = false;
    atualizaClientes = false;

    prompt = 'Pressione ENTER para adicionar "';

    isLoading = {
        salvar: false,
        pegarClientes: false,
    };

    constructor(
        private _perfilService: PerfilService,
        private _snackBar: SnackBar,
        private dialogRef: MatDialogRef<EditaPerfilClienteComponent>,
        @Inject(MAT_DIALOG_DATA) data) {
        this.dataInicioCtrl = new FormControl('', [Validators.required]);
        this.novoClienteCtrl = new FormControl('', [Validators.required]);
        this.dataFimCtrl = new FormControl();
        this.idPessoa = data.idPessoa;
        this.getClientesPerfil();
    }

    opcaoSelecionada(option): void {
        if (option.value.indexOf(this.prompt) === 0) {
            this.adicionaNovoCliente();
        }
    }

    editarCliente(cliente: ClientePerfil): void {
        this.dataInicioCtrl.setValue(cliente.dataInicio);
        this.dataFimCtrl.setValue(cliente.dataFim);
        this.novoClienteCtrl.setValue(cliente);
        this.novoCliente = false;
        this.novoClienteCtrl.disable();

        const responsavelEdicao: Usuario = JSON.parse(localStorage.getItem('usuario'));
        this.editarClienteModelo.idCliente = cliente.id;
        this.editarClienteModelo.idPessoa = this.idPessoa;
        this.editarClienteModelo.ResponsavelEdicao = responsavelEdicao.idPessoa;
    }

    adicionaNovoCliente(): void {
        if (this.novoClienteCtrl.invalid || this.dataInicioCtrl.invalid) {
            this.novoClienteCtrl.markAsDirty();
            this.novoClienteCtrl.markAsTouched();
            this.dataInicioCtrl.markAsDirty();
            this.dataInicioCtrl.markAsTouched();
            return;
        }

        this.isLoading.salvar = true;

        if (this.novoCliente) {
            let cliente: ClientePerfil = new ClientePerfil();
            cliente = this.novoClienteCtrl.value;

            const criaCliente = {
                idCliente: cliente.id,
                idPessoa: this.idPessoa,
                nome: cliente.nome ? cliente.nome : cliente,
                dataInicio: this.dataInicioCtrl.value,
                dataFim: this.dataFimCtrl.value
            };

            this._perfilService.adicionaCliente(JSON.stringify(criaCliente))
                .subscribe(
                    () => {
                        this.isLoading.salvar = false;
                        this._snackBar.abrirSnackBar('Cliente adicionado com sucesso!', 'Ok');
                        this.limparCampos();
                        this.getClientesPerfil();
                    },
                    err => {
                        if (err === 'Conflict') {
                            this.isLoading.salvar = false;
                            this._snackBar.abrirSnackBar('Cliente já relacionado...', 'Ok');
                        }
                        else {
                            this.isLoading.salvar = false;
                            this._snackBar.abrirSnackBar('Falha ao adicionar cliente...', 'Ok');
                        }
                    });
        }
        else {
            this.editarClienteModelo.DataInicio = this.dataInicioCtrl.value;
            this.editarClienteModelo.DataFim = this.dataFimCtrl.value;
            this._perfilService.editarUnicoCliente(JSON.stringify(this.editarClienteModelo))
                .subscribe(
                    () => {
                        this.isLoading.salvar = false;
                        this._snackBar.abrirSnackBar('Cliente editado com sucesso!', 'Ok');
                        this.novoCliente = true;
                        this.limparCampos();
                        this.getClientesPerfil();
                    },
                    err => {
                        this.isLoading.salvar = false;
                        this._snackBar.abrirSnackBar('Falha ao editar cliente...', 'Ok');
                    });
        }
    }

    removerPromptDeClientes(opcao): any {
        if (opcao.startsWith(this.prompt)) {
            opcao = opcao.substring(this.prompt.length, opcao.length - 1);
        }
        return opcao;
    }

    ngOnInit(): void {
    }

    getClientesPerfil(): void {
        this.listaClientes$ = this._perfilService.getClientesPerfil(this.idPessoa);
        this.listaClientes$.subscribe(
            elem => {
                this.clientesPessoais = elem.clientesPessoa;
            }
        );
    }

    limparCampos(): void {
        this.novoClienteCtrl.reset();
        this.dataInicioCtrl.reset();
        this.dataFimCtrl.reset();
    }
}
