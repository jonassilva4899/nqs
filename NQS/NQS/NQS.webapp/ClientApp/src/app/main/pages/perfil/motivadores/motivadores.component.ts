import { Component, OnInit, OnDestroy, Input, OnChanges, SimpleChanges } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Subscription } from 'rxjs';
import { SnackBar } from 'app/components/snackBar/snackBar';
import { MotivadoresService } from './motivadores.service';
import { Motivadores, Motivador } from '@models/Motivadores';
import { MotivadoresEnum } from '@models/Enums';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-motivadores',
  templateUrl: './motivadores.component.html',
  styleUrls: ['./motivadores.component.scss']
})
export class MotivadoresComponent implements OnInit, OnDestroy, OnChanges {

    NivelPermissao = NivelPermissao;

    @Input() idPessoa: string;
    @Input() idsTimes: string[];

    motivadores: Motivadores;

    isLoading = {
        motivadores: false,
        adicionar: false,
    };

    subscription = new Subscription();
    subscriptionMotivadores = new Subscription();

    constructor(
        private _motivadoresService: MotivadoresService,
        private _domSanitizer: DomSanitizer,
        private _snackBar: SnackBar,
    ) { }

    ngOnInit(): void {
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes && changes.idPessoa && changes.idPessoa.currentValue) {
            this.getMotivadoresPessoa(this.idPessoa);
        }
    }

    getMotivadoresPessoa(idPessoa): void {
        this.isLoading.motivadores = true;

        this.subscription.add(
            this._motivadoresService.getMotivadoresPessoa(idPessoa)
                .subscribe(
                    (motivadores: Motivadores) => {
                        this.motivadores = motivadores;
                        this.isLoading.motivadores = false;
                    },
                    (err: any) => {
                        this.isLoading.motivadores = false;
                    }
                )
        );
    }

    exibirImgMotivador(motivador: Motivador): SafeResourceUrl {
        let imgUrl;

        if (!motivador) {
            return '';
        }

        switch (motivador.nome) {
            case MotivadoresEnum.Status:
                imgUrl = 'Motivadores_status.png';
                break;

            case MotivadoresEnum.Aceitacao:
                imgUrl = 'Motivadores_aceitacao.png';
                break;

            case MotivadoresEnum.Ordem:
                imgUrl = 'Motivadores_ordem.png';
                break;

            case MotivadoresEnum.Maestria:
                imgUrl = 'Motivadores_maestria.png';
                break;

            case MotivadoresEnum.Poder:
                imgUrl = 'Motivadores_poder.png';
                break;

            case MotivadoresEnum.Meta:
                imgUrl = 'Motivadores_meta.png';
                break;

            case MotivadoresEnum.Relacaoo:
                imgUrl = 'Motivadores_relacao.png';
                break;

            case MotivadoresEnum.Liberdade:
                imgUrl = 'Motivadores_liberdade.png';
                break;

            case MotivadoresEnum.Honra:
                imgUrl = 'Motivadores_honra.png';
                break;

            case MotivadoresEnum.Curiosidade:
                imgUrl = 'Motivadores_curiosidade.png';
                break;

        }

        return this._domSanitizer.bypassSecurityTrustResourceUrl(`../../../../../assets/images/motivadores/${imgUrl}`);
    }

    drop(event: CdkDragDrop<string[]>): void {
        moveItemInArray(this.motivadores.motivadores, event.previousIndex, event.currentIndex);
        this.salvarNovaOrdemDeMotivadores(this.motivadores.motivadores);
    }

    salvarNovaOrdemDeMotivadores(motivadores: Motivador[]): void {
        this.subscriptionMotivadores.unsubscribe();
        this.subscriptionMotivadores =
            this._motivadoresService.putMotivadoresPessoa(motivadores, this.idPessoa)
                .subscribe(
                    (res: any) => {},
                    (err: any) => {
                        this._snackBar.abrirSnackBar('Falha ao salvar Motivadores', 'Ok', 'red');
                    }
                );
    }

    adicionarMotivadoresPessoa(): void {
        this.isLoading.adicionar = true;

        this.subscription.add(
            this._motivadoresService.adicionarMotivadoresPessoa(this.idPessoa)
                .subscribe(
                    (res: any) => {
                        this.isLoading.adicionar = false;
                        this.getMotivadoresPessoa(this.idPessoa);
                    },
                    (err: any) => {
                        this.isLoading.adicionar = false;
                        this._snackBar.abrirSnackBar('Falha ao adicionar Motivadores ao perfil...', 'Ok', 'red');
                    }
                )
        );
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
        this.subscriptionMotivadores.unsubscribe();
    }

}
