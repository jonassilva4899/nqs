import { Component, OnInit, Input, OnChanges, SimpleChanges, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { SnackBar } from 'app/components/snackBar/snackBar';

import { PerfilService } from '../perfil.service';
import { FormPersonalMappingComponent } from '../form-personal-mapping/form-personal-mapping.component';
import { FuseConfirmDialogComponent } from '@fuse/components/confirm-dialog/confirm-dialog.component';

import { PersonalMapping } from '@models/PersonalMapping';
import { Usuario } from '@models/Usuario';
import { Acao } from '@models/Enums';
import { NivelPermissao } from '@models/Permissoes';

@Component({
  selector: 'app-personal-mapping',
  templateUrl: './personal-mapping.component.html',
  styleUrls: ['./personal-mapping.component.scss']
})
export class PersonalMappingComponent implements OnInit, OnChanges, OnDestroy {

    NivelPermissao = NivelPermissao;

    @Input() idPessoa: string;
    @Input() idsTimes: string[];
    @Input() usuario: Usuario;

    Acao = Acao;
    personalMappings: PersonalMapping[] = [];

    isLoading = {
        personalMappings: false,
    };

    private _unsubscribeAll = new Subject();

    constructor(
        private _perfilService: PerfilService,
        private _matDialog: MatDialog,
        private _snackBar: SnackBar,
    ) {
    }

    ngOnInit(): void {
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes && changes.idPessoa && changes.idPessoa.currentValue) {
            this.getPersonalMapping();
        }
    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    getPersonalMapping(): void {
        this.isLoading.personalMappings = true;
        this._perfilService.getPersonalMapping(this.idPessoa)
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(
                (personalMappings: PersonalMapping[]) => {
                    this.personalMappings = personalMappings;
                    this.isLoading.personalMappings = false;
                },
                (err) => {
                    this.isLoading.personalMappings = false;
                }
            );
    }

    abrirFormPersonalMapping(acao: Acao, personalMapping?: PersonalMapping): void {
        const dialogRef = this._matDialog.open(FormPersonalMappingComponent, {
            data: {
                acao,
                personalMapping,
                idPessoa: this.idPessoa,
                usuario: this.usuario,
            },
        });

        dialogRef.afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(result => {
                if (result && result.atualizar) {
                    this._snackBar.abrirSnackBar('Personal Mapping salvo!', 'Ok');
                    this.getPersonalMapping();
                }
            });
    }

    remover(event: Event, personalMapping: PersonalMapping, index: number): void {
        event.preventDefault();
        event.stopPropagation();

        const dialogRef = this._matDialog.open(FuseConfirmDialogComponent, {
            data: {
                title: `Confirma a exclusão do personal mapping ${personalMapping.titulo}`,
                message: 'Essa ação não pode ser desfeita.',
                confirmButtonText: 'Sim, excluir',
                confirmButtonClass: 'mat-warn',
            },
        });

        dialogRef.afterClosed()
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(result => {
                if (result) {
                    this.personalMappings.splice(index, 1);
                    this._perfilService.deletePersonalMapping(personalMapping.idTitulo)
                        .pipe(takeUntil(this._unsubscribeAll))
                        .subscribe((res: any) => {
                            this._snackBar.abrirSnackBar('Personal Mapping removido!', 'Ok');
                        }, (err) => {
                            this.personalMappings.splice(index, 0, personalMapping);
                            this._snackBar.abrirSnackBar('Falha ao remover Personal Mapping...', 'Ok');
                        });
                }
            });
    }

}
