import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { TratarStringService } from '@shared/services/tratar-string.service';
import { KudoCardsService } from '../kudo-cards.service';

import { KudoCard, KudoCardTipoDestinatario, EnvioKudoCard } from '@models/KudoCard';
import { PessoaDados } from '@models/Pessoa';
import { TimeDadosBasicos, } from '@models/Times';
import { Usuario } from '@models/Usuario';

@Component({
    selector: 'app-kudo-card-form',
    templateUrl: './kudo-card-form.component.html',
    styleUrls: ['./kudo-card-form.component.scss']
})
export class KudoCardFormComponent implements OnInit {

    KudoCardTipoDestinatario = KudoCardTipoDestinatario;
    form: FormGroup;

    kudoCards: KudoCard[] = [];
    times: TimeDadosBasicos[] = [];
    pessoas: PessoaDados[] = [];
    timesFiltro: TimeDadosBasicos[] = [];
    pessoasFiltro: PessoaDados[] = [];

    isLoading = {
        enviar: false,
    };

    constructor(
        private _kudoCardsService: KudoCardsService,
        private _fb: FormBuilder,
        public dialogRef: MatDialogRef<KudoCardFormComponent>,
        @Inject(MAT_DIALOG_DATA) private data,
        private _snackBar: SnackBar,
    ) { }

    ngOnInit(): void {
        this.form = this._fb.group({
            kudoCardID: ['', [Validators.required]],
            tipoDestinatario: ['', [Validators.required]],
            pessoa: ['', []],
            time: ['', []],
            mensagem: ['', [Validators.required]],
        });

        this.form.get('tipoDestinatario').valueChanges.subscribe((value) => {
            if (value === KudoCardTipoDestinatario.Pessoa) {
                this.form.get('time').reset();
                this.form.get('time').clearValidators();
                this.form.get('pessoa').setValidators([Validators.required]);

                if (!this.pessoas.length) {
                    this.getPessoas();
                }
            } else {
                this.form.get('pessoa').reset();
                this.form.get('pessoa').clearValidators();
                this.form.get('time').setValidators([Validators.required]);

                if (!this.times.length) {
                    this.getTimes();
                }
            }

            this.form.get('time').updateValueAndValidity();
            this.form.get('pessoa').updateValueAndValidity();
        });

        this.form.get('time').valueChanges.subscribe((value) => {
            this.filtrarLista(value, 'nome', 'times', 'timesFiltro');
        });

        this.form.get('pessoa').valueChanges.subscribe((value) => {
            this.filtrarLista(value, 'nome', 'pessoas', 'pessoasFiltro');
        });

        this.getKudoCards();
    }

    getKudoCards(): void {
        this._kudoCardsService.getKudoCards()
            .subscribe(
                (kudoCards) => {
                    this.kudoCards = kudoCards;
                }
            );
    }

    getTimes(): void {
        this._kudoCardsService.getTimes()
            .subscribe(
                (times) => {
                    this.times = times;
                    this.timesFiltro = times;
                }
            );
    }

    getPessoas(): void {
        this._kudoCardsService.getPessoas()
            .subscribe(
                (pessoas) => {
                    this.pessoas = pessoas;
                    this.pessoasFiltro = pessoas;
                }
            );
    }

    selecionaKudoCard(kudoCard: KudoCard): void {
        this.form.get('kudoCardID').setValue(kudoCard.id);
    }

    enviarKudoCard(): void {
        const formData = this.form.getRawValue();

        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        this.isLoading.enviar = true;
        const kudoCardForm: EnvioKudoCard = new EnvioKudoCard();

        if (formData.time && formData.time.id) {
            kudoCardForm.idTime = formData.time.id;
        }
        else if (formData.pessoa && formData.pessoa.id) {
            kudoCardForm.para = formData.pessoa.id;
        }

        kudoCardForm.mensagem = formData.mensagem;
        kudoCardForm.tipoKudoCard = formData.kudoCardID;
        kudoCardForm.tipoDestinatario = formData.tipoDestinatario;
        kudoCardForm.de = (JSON.parse(localStorage.getItem('usuario')) as Usuario).idPessoa;

        this._kudoCardsService.enviarKudoCard(kudoCardForm)
            .subscribe(
                (res: any) => {
                    this.isLoading.enviar = false;
                    this.dialogRef.close({ atualizar: true });
                },
                (err: any) => {
                    this.isLoading.enviar = false;
                    this._snackBar.abrirSnackBar('Falha ao enviar Kudo Card...', 'OK', 'red');
                }
            );
    }

    exibirNomeNoAutoComplete(chave: string): any {
        return (valor: any): string => {
            return valor && valor[chave] ? valor[chave] : '';
        };
    }

    verificarSeNomeExiste(control: AbstractControl): void {
        setTimeout(() => {
            const valor = control.value;
            if (typeof valor !== 'object') {
                control.setValue(null);
            }
        }, 250);
    }

    filtrarLista(valor: string, chave: string, nomeLista: string, nomeListaFiltro: string): void {
        if (valor && typeof valor !== 'string') {
            valor = valor[chave];
        }

        this[nomeListaFiltro] = this[nomeLista].filter((item) =>
            TratarStringService.busca(item[chave])
                .includes(valor ? TratarStringService.busca(valor) : '')
        );
    }

}
