import { Pipe, PipeTransform } from '@angular/core';
import { FormControl } from '@angular/forms';

@Pipe({
    name: 'parseFormErrors',
    pure: false,
})
export class ParseFormErrorsPipe implements PipeTransform {
  transform(formControl: FormControl): string {
    if (formControl.errors) {
      if (formControl.errors.required) {
        return 'Campo obrigatório';
      } else if (formControl.errors.value) {
        return formControl.errors.value;
      } else if (formControl.errors.message) {
        return formControl.errors.message;
      } else if (formControl.errors.matDatepickerMin) {
        return 'Data fora do limite permitido';
      } else if (formControl.errors.minlength) {
        return `Insira ao menos ${formControl.errors.minlength.requiredLength} caracteres`;
      } else {
        return 'Campo inválido';
      }
    } else if (formControl.invalid) {
      return 'Campo inválido';
    }

    return '';
  }
}
