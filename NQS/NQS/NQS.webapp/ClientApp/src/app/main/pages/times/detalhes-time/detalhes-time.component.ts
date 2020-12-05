import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { TimeService } from '../time.service';
import { TimeDetalhe } from 'app/models/TimeDetalhe';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-detalhes-time',
    templateUrl: './detalhes-time.component.html',
    styleUrls: ['./detalhes-time.component.scss']
})
export class DetalhesTimeComponent implements OnInit {

    idTime: string;
    timeDetalhe$: Observable<TimeDetalhe>;

    constructor(
        private route: ActivatedRoute,
        private _timeService: TimeService
    ) { }

    ngOnInit(): void {
        this.route.paramMap.subscribe(params => {
            this.idTime = params.get('id');
        });

        this.timeDetalhe$ = this._timeService.pegaTimeEspecifico(this.idTime);
    }
}
