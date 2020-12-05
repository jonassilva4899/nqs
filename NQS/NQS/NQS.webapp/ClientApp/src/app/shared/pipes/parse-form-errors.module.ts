import { NgModule } from '@angular/core';
import { ParseFormErrorsPipe } from './parse-form-errors.pipe';

@NgModule({
    imports: [],
    declarations: [ParseFormErrorsPipe],
    exports: [ParseFormErrorsPipe],
})

export class ParseFormErrorsModule {
    static forRoot(): any {
        return {
            ngModule: ParseFormErrorsModule,
            providers: [],
        };
    }
}
