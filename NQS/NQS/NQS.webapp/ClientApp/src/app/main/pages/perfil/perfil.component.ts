import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { fuseAnimations } from '@fuse/animations';
import { MatChipInputEvent, MatDialog, MatDialogConfig, MatAutocompleteSelectedEvent } from '@angular/material';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { TratarStringService } from '@shared/services/tratar-string.service';
import { PerfilService } from './perfil.service';

import { EditaPerfilComponent } from './edita-perfil/edita-perfil.component';
import { EditaPerfilTimeComponent } from './edita-perfil-time/edita-perfil-time.component';
import { EditaPerfilClienteComponent } from './edita-perfil-cliente/edita-perfil-cliente.component';
import { HistoricoPerfilClienteComponent } from './historico-perfil-cliente/historico-perfil-cliente.component';
import { AcaoColaboradorComponent } from './acao-colaborador/acao-colaborador.component';
import { ListaAcaoColaboradorComponent } from './acao-colaborador/lista-acao-colaborador/lista-acao-colaborador.component';

import { HabilidadesPerfil } from '@models/HabilidadesPerfil';
import { Perfil } from '@models/Perfil';
import { TimesPerfil } from '@models/PegarTimePerfil';
import { Usuario } from '@models/Usuario';
import { SolicitacaoReenvioEmail } from '@models/ReenviaEmail';
import { SentimentoEnum } from '@models/Enums';
import { NivelPermissao } from '@models/Permissoes';

@Component({
    selector: 'app-perfil',
    templateUrl: './perfil.component.html',
    styleUrls: ['./perfil.component.scss'],
    animations: fuseAnimations
})
export class PerfilComponent implements OnInit {

    NivelPermissao = NivelPermissao;
    SentimentoEnum = SentimentoEnum;

    tokenComId: any;
    retornaPerfil: Perfil;
    idPessoa: string;
    usuario: Usuario = new Usuario();
    listaTimesSelecionados: TimesPerfil[] = [];
    listaTimesSelecionadosIDs: string[];
    qtdAcoesCompletas = 0;
    qtdAcoesTotal = 0;

    visible = true;
    selectable = true;
    removable = true;
    addOnBlur = true;
    readonly separatorKeysCodes: number[] = [ENTER, COMMA];

    listaHabilidadesComboBox: HabilidadesPerfil[];
    filtroListaHabilidades: HabilidadesPerfil[];
    novaHabilidade: HabilidadesPerfil = new HabilidadesPerfil();
    habilidades: HabilidadesPerfil[] = [];
    habilidadeCtrl = new FormControl();
    isLoading = {
        enviaConvite: false
    };
    reenviaConviteCor = '#ef4136';

    constructor(
        private _perfilService: PerfilService,
        private _activatedRoute: ActivatedRoute,
        private _snackBar: SnackBar,
        private _matDialog: MatDialog,
    ) {
        this.usuario = JSON.parse(localStorage.getItem('usuario'));
        this.isLoading.enviaConvite = false;
    }

    ngOnInit(): void {
        this._activatedRoute.paramMap.subscribe(
            params => {
                this.tokenComId = params.get('idPessoa');
                this.buscaPerfil();
                this.buscaAcoesColaborador();
                this.buscaHabilidades();
            }
        );
    }

    buscaHabilidades(): void {
        this._perfilService.pegarHabilidadesColaborador(this.tokenComId)
            .subscribe(
                data => {
                    this.habilidades = data;
                }
            );

        this._perfilService.pegarHabilidadesComboBox(this.tokenComId)
            .subscribe(
                data => {
                    this.listaHabilidadesComboBox = data;
                    this.filtroListaHabilidades = data;
                });
    }

    buscaPerfil(): void {
        this._perfilService.getPerfil(this.tokenComId)
            .subscribe(data => {
                this.retornaPerfil = data;
            });

        this._perfilService.getPegarTimePerfil(this.tokenComId)
            .subscribe(
                data => {
                    this.listaTimesSelecionadosIDs = data.timesPessoa.map(time => time.id);
                    this.listaTimesSelecionados = data.timesPessoa;
                }
            );
    }

    buscaAcoesColaborador(): void {
        this._perfilService.listaAcoesColaborador(this.tokenComId).subscribe(data => {
            this.qtdAcoesTotal = data.length;
            this.qtdAcoesCompletas = data.filter(x => x.status === 4).length;
        });
    }

    add(event: MatChipInputEvent): void {
        const input = event.input;
        const value = event.value;

        if (this.filtroListaHabilidades.filter((unit) => unit.nomeHabilidade.indexOf(value) > -1).length === 0) {
            if ((value || '').trim()) {
                this.novaHabilidade = new HabilidadesPerfil();
                this.novaHabilidade.idPessoa = this.tokenComId;
                this.novaHabilidade.nomeHabilidade = value.trim();
                this.novaHabilidade.idHabilidade = '';

                this._perfilService.adicionarHabilidadeColaborador(JSON.stringify(this.novaHabilidade))
                    .subscribe(() => {
                        this._snackBar.abrirSnackBar('Habilidade cadastrada com sucesso!', 'Ok');
                        this.buscaHabilidades();
                    });
            }
        }

        if (input) {
            input.value = '';
        }
    }

    selected(event: MatAutocompleteSelectedEvent): void {
        this.novaHabilidade = new HabilidadesPerfil();
        this.novaHabilidade.idHabilidade = (event.option.value).idHabilidade;
        this.novaHabilidade.nomeHabilidade = (event.option.value).nomeHabilidade;
        this.novaHabilidade.idPessoa = this.tokenComId;

        this._perfilService.adicionarHabilidadeColaborador(JSON.stringify(this.novaHabilidade))
            .subscribe(() => {
                this._snackBar.abrirSnackBar('Habilidade cadastrada com sucesso!', 'Ok');
                this.buscaHabilidades();
            });
    }

    remove(hab: HabilidadesPerfil): void {
        hab.idPessoa = this.tokenComId;
        this._perfilService.removerHabilidadeColaborador(this.tokenComId, JSON.stringify(hab))
            .subscribe(() => {
                this._snackBar.abrirSnackBar('Habilidade removida com sucesso!', 'Ok');
                this.buscaHabilidades();
            });
    }

    filtrarHabilidades(event): void {
        if (this.filtroListaHabilidades) {
            this.listaHabilidadesComboBox = this.filtroListaHabilidades.filter(
                (unit) => TratarStringService.busca(unit.nomeHabilidade)
                    .includes(TratarStringService.busca(event))
            );
        }
    }

    editarPerfil(): void {
        this._matDialog.open(EditaPerfilComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            autoFocus: false,
            data: {
                idPessoa: this.tokenComId
            },
        })
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaPerfil();
                    }
                }
            );
    }

    editarTime(): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {
            idPessoa: this.tokenComId
        };
        dialogConfig.minWidth = '70vw';
        dialogConfig.minHeight = '80vh';
        dialogConfig.autoFocus = false;

        this._matDialog.open(EditaPerfilTimeComponent, dialogConfig)
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaPerfil();
                    }
                }
            );
    }

    editarCliente(): void {
        this._matDialog.open(EditaPerfilClienteComponent, {
            autoFocus: false,
            data: { idPessoa: this.tokenComId }
        })
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaPerfil();
                    }
                }
            );
    }

    historicoClientes(): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {
            idPessoa: this.tokenComId
        };

        this._matDialog.open(HistoricoPerfilClienteComponent, dialogConfig)
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaPerfil();
                    }
                }
            );
    }

    adicionaAcao(): void {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {
            idPessoa: this.tokenComId,
            idResponsavel: this.usuario.idPessoa
        };

        this._matDialog.open(AcaoColaboradorComponent, dialogConfig)
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaAcoesColaborador();
                    }
                }
            );
    }

    abrirListaAcoes(): void {
        this._matDialog.open(ListaAcaoColaboradorComponent, {
            width: '80vw',
            maxHeight: '100vh',
            panelClass: 'dialog-with-close',
            data: {
                idPessoa: this.tokenComId,
                idResponsavel: this.usuario.idPessoa
            }
        })
            .afterClosed().subscribe(
                data => {
                    if (data) {
                        this.buscaAcoesColaborador();
                    }
                }
            );
    }

    reenviaEmail(): void {

        if (this.isLoading.enviaConvite) {
            return;
        }

        this.isLoading.enviaConvite = true;
        this.reenviaConviteCor = '#a29d9d';
        const solicitacao: SolicitacaoReenvioEmail = new SolicitacaoReenvioEmail();
        solicitacao.idPessoa = this.tokenComId;
        solicitacao.idResponsavel = this.usuario.idPessoa;

        this._perfilService.reenviaEmailConvite(JSON.stringify(solicitacao))
            .subscribe(() => {
                this._snackBar.abrirSnackBar('Convite reenviado com sucesso!', 'Ok');
                this.isLoading.enviaConvite = false;
                this.reenviaConviteCor = '#ef4136';
            }, err => {
                this._snackBar.abrirSnackBar('Falha ao reenviar convite', 'Ok', 'red');
                this.isLoading.enviaConvite = false;
                this.reenviaConviteCor = '#ef4136';
            });
    }

    exibirParaUsuarioLogado(): boolean {
        return this.tokenComId === this.usuario.idPessoa;
    }

}
