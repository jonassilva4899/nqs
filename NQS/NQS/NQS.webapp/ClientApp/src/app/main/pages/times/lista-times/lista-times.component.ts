import { Component, OnInit, Input } from '@angular/core';
import { Times } from 'app/models/Times';

@Component({
    selector: 'app-lista-times',
    templateUrl: './lista-times.component.html',
    styleUrls: ['./lista-times.component.scss']
})
export class ListaTimesComponent implements OnInit {

    @Input() listaTimes: Times;

    breakpoint: number;

    constructor() { }

    ngOnInit(): void {
        this.breakpoint = window.innerWidth / 360;
    }

    onResize(event): void {
        this.breakpoint = window.innerWidth / 360;
    }
}
