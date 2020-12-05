import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-termometro',
  templateUrl: './termometro.component.html',
  styleUrls: ['./termometro.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class TermometroComponent implements OnInit {

    @Input() temperatura = 0;

    constructor() { }

    ngOnInit(): void {
    }

}
