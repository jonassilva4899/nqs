import { Component, OnInit, Inject } from '@angular/core';
import { fuseAnimations } from '@fuse/animations';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';
import { PerfilService } from '../perfil.service';
import { ClientePerfil } from 'app/models/ClientePerfil';

@Component({
    selector: 'app-historico-perfil-cliente',
    templateUrl: './historico-perfil-cliente.component.html',
    styleUrls: ['./historico-perfil-cliente.component.scss'],
    animations: fuseAnimations
})
export class HistoricoPerfilClienteComponent implements OnInit {

    displayedColumns: string[] = ['nome', 'data_inicio', 'data_fim'];
    dataSource: MatTableDataSource<ClientePerfil>;
    dadosClientePerfil: MatTableDataSource<ClientePerfil>;
    listaClientePerfil: ClientePerfil[] = [];
    idPessoa: string;

    constructor(private _perfilService: PerfilService, @Inject(MAT_DIALOG_DATA) data) {
        this.idPessoa = data.idPessoa;
    }

    ngOnInit() {
        this.preencheClientesPerfil();
    }

    preencheClientesPerfil() {

        this._perfilService.getHistoricoClientes(this.idPessoa).subscribe(
            data => {
                this.listaClientePerfil = data;
                this.dadosClientePerfil = new MatTableDataSource<ClientePerfil>(this.listaClientePerfil);
            }
        );
    }

}
