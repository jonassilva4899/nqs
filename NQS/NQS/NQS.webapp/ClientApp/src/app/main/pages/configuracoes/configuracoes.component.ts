import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-configuracoes',
  templateUrl: './configuracoes.component.html',
  styleUrls: ['./configuracoes.component.scss'],
  animations: [fuseAnimations],
  encapsulation: ViewEncapsulation.None,
})
export class ConfiguracoesComponent implements OnInit {

    NivelPermissao = NivelPermissao;

    configJira = [
        { time: 'Bope', dominio: 'https://bope.atlassian.net', data: new Date(2020, 5, 1) },
        { time: 'Clã UX', dominio: 'https://claux.atlassian.net', data: new Date(2020, 4, 1) },
        { time: 'Team Sano' },
    ];

    constructor(
    ) { }

    ngOnInit(): void {
    }

}
