import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
    providedIn: 'root'
})
export class ValidarCamposService {

    static validar(form: FormGroup): void {
        const campos = Object.keys(form.controls);

        for (const campo of campos) {
            form.get(campo).markAsDirty();
            form.get(campo).markAsTouched();
        }
    }

}
