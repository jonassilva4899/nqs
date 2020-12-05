import { NgModule } from '@angular/core';
import { EncodeWhiteSpacePipe } from './encode-white-space.pipe';

@NgModule({
    imports: [],
    declarations: [EncodeWhiteSpacePipe],
    exports: [EncodeWhiteSpacePipe],
})

export class EncodeWhiteSpacePipeModule {
    static forRoot(): any {
        return {
            ngModule: EncodeWhiteSpacePipeModule,
            providers: [],
        };
    }
}
