import { ChangeDetectionStrategy, Component, OnInit, Input, ViewChild } from '@angular/core';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { ListaPessoas } from 'app/models/PessoaModel';
import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
import { throttleTime, mergeMap, scan, map, tap } from 'rxjs/operators';
import { PessoasService } from '../pessoas.service';
import { FiltrosPessoas } from '@models/Pessoa';
import { DataSource } from '@angular/cdk/table';
import { CollectionViewer } from '@angular/cdk/collections';

@Component({
    selector: 'app-lista-pessoas',
    templateUrl: './lista-pessoas.component.html',
    styleUrls: ['./lista-pessoas.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ListaPessoasComponent implements OnInit {

    breakpoint: number;
    fim = false;
    @Input() listaPessoas: ListaPessoas[];
    @Input() filtroPessoas: FiltrosPessoas;
    @ViewChild(CdkVirtualScrollViewport, { static: false }) viewPort: CdkVirtualScrollViewport;

    constructor(private _pessoaService: PessoasService) {
    }

    scrollIndex(event): void {
        if (!this.fim) {
            const end = this.viewPort.getRenderedRange().end;
            const total = this.viewPort.getDataLength();

            if (end >= (total / 2) && end !== 0 && total !== 0) {
                this.adicionaPaginas();
            }
        }
    }

    ngOnInit(): void {
        this.breakpoint = window.innerWidth / 380;
    }

    adicionaPaginas(): void {
        this.filtroPessoas.comecaCom = this.filtroPessoas.terminaCom;
        this.filtroPessoas.terminaCom += 10;
        this._pessoaService.listarPessoas(JSON.stringify(this.filtroPessoas))
            .subscribe(data => {
                if (data.length > 0) {
                    this.listaPessoas = this.listaPessoas.concat(data);
                }
                else {
                    this.fim = true;
                }
            });
    }

    onResize(event): void {
        this.breakpoint = window.innerWidth / 380;
    }
}

