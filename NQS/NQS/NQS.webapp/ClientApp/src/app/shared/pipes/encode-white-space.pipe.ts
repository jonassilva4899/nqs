import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'encodeWhiteSpace' })
export class EncodeWhiteSpacePipe implements PipeTransform {
  transform(value: string): string {
    return value ? (value).toString().replace(/\s/g, '%20') : '';
  }
}
