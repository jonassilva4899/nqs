import { Component, OnInit, Output, EventEmitter, Input, OnChanges } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { DomSanitizer } from '@angular/platform-browser';


@Component({
    selector: 'app-upload-imagem',
    templateUrl: './upload-imagem.component.html',
    styleUrls: ['./upload-imagem.component.scss'],
    animations: fuseAnimations
})
export class UploadImagemComponent implements OnInit {

    fileToUpload: File = null;
    @Input() imageUrl = '';
    @Input() titulo;
    @Output() respostaImagemBase64 = new EventEmitter<string>();

    constructor() {
     }

    ngOnInit() {
    }

    handleFileInput(file: FileList): void {
        this.fileToUpload = file.item(0);

        const leitor = new FileReader();
        leitor.onload = (event: any) => {
            this.imageUrl = event.target.result;
            this.respostaImagemBase64.emit(this.imageUrl);
        };
        leitor.readAsDataURL(this.fileToUpload);
    }

}
