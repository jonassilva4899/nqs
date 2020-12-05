import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class SelecionarTemaService {

    constructor() {}

    getTema(): any {
        const tema = localStorage.getItem('tema');
        let config;

        if (tema) {
            config = JSON.parse(tema);
            return config;
        }

        return null;
    }

}
