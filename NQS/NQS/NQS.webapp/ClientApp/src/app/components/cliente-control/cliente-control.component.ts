import { Component, OnInit, Input, Self, OnChanges, Optional } from '@angular/core';
import { FormControl, ControlValueAccessor, NgControl, Validators } from '@angular/forms';
import { MatFormFieldControl } from '@angular/material';
import { Observable } from 'rxjs';

import { TratarStringService } from '@shared/services/tratar-string.service';
import { ClientePerfil, EditarClientePerfil } from '@models/ClientePerfil';

@Component({
    selector: 'cliente-control',
    templateUrl: './cliente-control.component.html',
    styleUrls: ['./cliente-control.component.scss'],
    providers: [
        {
            provide: MatFormFieldControl,
            useExisting: ClienteControlComponent
        }
    ]
})
export class ClienteControlComponent implements ControlValueAccessor, OnInit, MatFormFieldControl<any>, OnChanges {

    todosClientes: ClientePerfil[] = [];
    filtroClientes: ClientePerfil[] = [];

    value: any;
    stateChanges: Observable<void>;
    id: string;
    focused: boolean;
    empty: boolean;
    shouldLabelFloat: boolean;
    required: boolean;
    disabled: boolean;
    errorState: boolean;
    controlType?: string;
    autofilled?: boolean;
    @Input() placeholder = 'Cliente';

    @Input() listaClientes$: Observable<EditarClientePerfil>;
    @Input() novoClienteCtrl: FormControl;

    isLoading = {
        todosClientes: false,
    };

    hasError = {
        todosClientes: false,
    };

    constructor(
        @Optional()
        @Self() public ngControl: NgControl,
    ) {
        this.ngControl.valueAccessor = this;
    }

    setDescribedByIds(ids: string[]): void {
    }

    onContainerClick(event: MouseEvent): void {
    }

    ngOnInit(): void {
        this.getClientesPerfil();
    }

    getClientesPerfil(): void {
        this.isLoading.todosClientes = true;
        this.hasError.todosClientes = false;

        this.listaClientes$.subscribe(
            elem => {
                this.todosClientes = elem.todosClientes;
                this.filtroClientes = elem.todosClientes;
                this.isLoading.todosClientes = false;
            },
            err => {
                this.isLoading.todosClientes = false;
                this.hasError.todosClientes = true;
            }
        );
    }

    displayFn(cliente: ClientePerfil): string {
        if (cliente && cliente.nome) {
            return cliente.nome;
        }
    }

    filtraClientes(event): void {
        if (typeof event !== 'string') {
            return;
        }

        this.todosClientes = this.filtroClientes.filter(
            (unit) => TratarStringService.busca(unit.nome).includes(TratarStringService.busca(event))
        );
    }

    writeValue(obj: any): void {
    }

    registerOnChange(fn: any): void {
    }

    registerOnTouched(fn: any): void {
    }

    setDisabledState?(isDisabled: boolean): void {
    }

    ngOnChanges(changes): void {
        this.getClientesPerfil();
    }

    atribuirCliente(): void {
        setTimeout(() => {
            if (typeof this.ngControl.value !== 'string') {
                return;
            }

            const cliente = this.filtroClientes.find(
                (unit) => TratarStringService.busca(unit.nome) === TratarStringService.busca(this.ngControl.value)
            );

            if (cliente) {
                this.ngControl.control.setValue(cliente);
            }
        }, 250);
    }

}
