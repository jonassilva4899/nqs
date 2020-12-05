import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { NotificacaoDelete } from '@models/ConfirmaDelete';

@Component({
    selector: 'app-confirma-delete',
    templateUrl: './confirma-delete.component.html',
    styleUrls: ['./confirma-delete.component.scss']
})
export class ConfirmaDeleteComponent implements OnInit {

    notificacaoDetalhe: NotificacaoDelete = new NotificacaoDelete();
    isLoading = {
        deletar: false
    };

    constructor(
        @Inject(MAT_DIALOG_DATA) data,
        public dialogRef: MatDialogRef<ConfirmaDeleteComponent>) {
        this.notificacaoDetalhe = data.notificacaoDetalhe;
    }

    ngOnInit(): void {
    }

}
