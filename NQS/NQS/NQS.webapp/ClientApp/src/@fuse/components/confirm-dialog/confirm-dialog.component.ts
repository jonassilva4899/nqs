import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector   : 'fuse-confirm-dialog',
    templateUrl: './confirm-dialog.component.html',
    styleUrls  : ['./confirm-dialog.component.scss']
})
export class FuseConfirmDialogComponent {

    title: string;
    message: string;

    confirmButtonText = 'OK';
    confirmButtonClass = 'mat-accent';

    cancelButtonText = 'Cancelar';

    /**
     * Constructor
     *
     * @param {MatDialogRef<FuseConfirmDialogComponent>} dialogRef
     */
    constructor(
        public dialogRef: MatDialogRef<FuseConfirmDialogComponent>,
        @Inject(MAT_DIALOG_DATA) data,
    ) {
        this.title = data.title || this.title;
        this.message = data.message || this.message;

        this.confirmButtonText = data.confirmButtonText || this.confirmButtonText;
        this.confirmButtonClass = data.confirmButtonClass || this.confirmButtonClass;

        this.cancelButtonText = data.cancelButtonText || this.cancelButtonText;
    }

}
