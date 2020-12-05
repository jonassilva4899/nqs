import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class SnackBar {
    constructor(private _snackBar: MatSnackBar) { }

    abrirSnackBar(message: string, action: string, panelClass?: string | string[]): void {
        this._snackBar.open(message, action, {
            duration: 3500,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass
        });
    }
}
