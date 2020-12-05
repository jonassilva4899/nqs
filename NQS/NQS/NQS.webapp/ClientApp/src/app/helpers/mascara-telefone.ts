import { Injectable, NgModule } from '@angular/core';

@Injectable()
@NgModule({})
export class TelefoneMascara {
    valueOfInput = '';
    maskInput = '';

    constructor() { }

    inputMascaraTelefone(event): string {

        const pattern = /^[0-9]*$/;
        if (!pattern.test(event.target.value)) {
            event.target.value = event.target.value.replace(/[^0-9]/g, '');
        }

        this.maskInput = event.target.value;
        switch (this.maskInput.length) {
            case 1:
                this.valueOfInput = `(${this.maskInput}`;
                break;
            case 2:
                this.valueOfInput = `(${this.maskInput})`;
                break;
            case 3:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 3)}`;
                break;
            case 4:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 4)}`;
                break;
            case 5:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 5)}`;
                break;
            case 6:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 6)}`;
                break;
            case 7:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 6)}-${this.maskInput.substring(6, 7)}`;
                break;
            case 8:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 6)}-${this.maskInput.substring(6, 8)}`;
                break;
            case 9:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 6)}-${this.maskInput.substring(6, 9)}`;
                break;
            case 10:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 6)}-${this.maskInput.substring(6, 10)}`;
                break;
            case 11:
                this.valueOfInput = `(${this.maskInput.substring(0, 2)})${this.maskInput.substring(2, 7)}-${this.maskInput.substring(7, 11)}`;
                break;
        }

        return this.valueOfInput;
    }
}