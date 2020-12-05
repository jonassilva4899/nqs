import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ToolbarOptions } from '@models/Toolbar';

@Injectable({
  providedIn: 'root'
})
export class ToolbarService {

    toolbarOptions = new BehaviorSubject<ToolbarOptions>(null);

    constructor() {
    }

}
