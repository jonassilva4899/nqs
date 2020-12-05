import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';
import { FuseConfigService } from '@fuse/services/config.service';
import { Permissao } from '@models/Permissoes';
import { ListaFiltroPessoas } from '@models/Pessoa';
import { Usuario } from '@models/Usuario';
import { PessoaFormDialogComponent } from '@pages/pessoas/pessoa-form/pessoa-form.component';
import { PessoasService } from '@pages/pessoas/pessoas.service';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { TelefoneMascara } from 'app/helpers/mascara-telefone';
import { Guid } from 'guid-typescript';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-teste',
  templateUrl: './teste.component.html',
  styleUrls: ['./teste.component.scss']
})
export class TesteComponent implements OnInit {

    pessoaForm: FormGroup;
    novaPessoa: any;
    respostaReq: Observable<boolean>;
    valueOfInput = '';
    atualizar = false;
    imageUrl = '';
    usuario: Usuario = new Usuario();
    listaTimes: ListaFiltroPessoas[] = [];
    listaPermissoes: Permissao[] = [];

    isLoading = {
        listaTimes: false,
        permissoes: false,
        salvar: false,
    };

    contaGoogle = false;

    private _unsubscribeAll: Subject<any>;

    constructor(
        private _formBuilder: FormBuilder,
        private _fuseConfigService: FuseConfigService,
        private _pessoasService: PessoasService,
        private _snackBar: SnackBar,
        private mascaraTel: TelefoneMascara
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));


        this._fuseConfigService.config = {
          colorTheme: 'theme-pink-dark',
          customScrollbars: true,
          layout: {
              navbar: {
                  hidden: true
              },
              toolbar: {
                  hidden: true
              },
              footer: {
                  hidden: true
              },
              sidepanel: {
                  hidden: true
              }
          }
      };


    }

    ngOnInit(): void {
        this.pessoaForm = this._formBuilder.group({
            eContaGoogle: [false, [Validators.required]],
            nome: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            telefone: ['', [Validators.required]],
            funcaoPrincipal: ['', [Validators.required]],
            eUsuario: [false, [Validators.required]],
            status: [true, [Validators.required]],
            // teste: ['', []],    
                   // idTime: ['', [Validators.required]],
            // nivelPermissao: ['', [Validators.required]],
            foto: [''],
        });

        // this.getTimes();
        // this.getPermissoesParaUsuarioLogado();
    }

    desabilitaCampos(): void {
        if (!this.contaGoogle) {
            this.contaGoogle = true;
        }
        else {
            this.contaGoogle = false;
        }
    }

    OnSubmit(): void {
        if (this.pessoaForm.invalid) {
            this.validarCampos(this.pessoaForm);
            return;
        }

        this.isLoading.salvar = true;
        this.novaPessoa = this.pessoaForm.getRawValue();
        const modeloPessoa = {
            pessoa: {
                nome: this.novaPessoa.nome,
                foto: this.imageUrl,
                funcaoPrincipal: this.novaPessoa.funcaoPrincipal,
                telefone: this.novaPessoa.telefone,
                // teste: this.novaPessoa.teste,
                email: this.novaPessoa.email,
                status: this.novaPessoa.status,
                dataCriacao: new Date(),
                dataEdicao: new Date(),
                // responsavelCriacao: this.usuario.idPessoa,
                // responsavelEdicao: this.usuario.idPessoa,
                // idOrganizacao: Guid.create().toString(),
                // idTime: this.novaPessoa.idTime,
                // nivelPermissao: this.novaPessoa.nivelPermissao,
            },
            // pessoaRequisitando: this.usuario.idPessoa,
            eUsuario: this.novaPessoa.eUsuario,
            eContaGoogle: this.novaPessoa.eContaGoogle
        };

        this._pessoasService.cadastrarPessoa(JSON.stringify(modeloPessoa)).subscribe(
            (res) => {
                this.atualizar = true;
                this._snackBar.abrirSnackBar('Pessoa salva com sucesso!', 'Ok');
                this.isLoading.salvar = false;
            },
            (err) => {
                this._snackBar.abrirSnackBar('Falha ao adicionar pessoa...', 'Ok');
                this.isLoading.salvar = false;
            }
        );
    }

    mascaraTelefone(event): void {
        this.valueOfInput = this.mascaraTel.inputMascaraTelefone(event);
    }

    receberImagemBase64(resposta: any): void {
        this.imageUrl = resposta;
    }

    getTimes(): void {
        this.isLoading.listaTimes = true;
        this._pessoasService.listarTimesFiltro()
            .subscribe(
                (listaTimes: ListaFiltroPessoas[]) => {
                    this.listaTimes = listaTimes;
                    this.isLoading.listaTimes = false;
                },
                (err: any) => {
                    this.isLoading.listaTimes = false;
                }
            );
    }

    getPermissoesParaUsuarioLogado(): void {
        this.isLoading.permissoes = true;
        this._pessoasService.getPermissoesParaUsuarioLogado()
            .subscribe(
                (listaPermissoes: Permissao[]) => {
                    this.listaPermissoes = listaPermissoes;
                    this.isLoading.permissoes = false;
                }
            );
    }

    validarCampos(form: FormGroup): void {
        const campos = Object.keys(form.controls);

        for (const campo of campos) {
            form.get(campo).markAsDirty();
            form.get(campo).markAsTouched();
        }
    }

}