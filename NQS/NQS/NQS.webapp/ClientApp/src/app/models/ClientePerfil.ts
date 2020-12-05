export class EditarClientePerfil{
    idPessoa: string;
    clientesPessoa: ClientePerfil[];
    todosClientes: ClientePerfil[];
}

export class ClientePerfil{
    id: string;
    nome: string;
    dataInicio: string;
    dataFim: string;
}

export class EditarClienteModelo{
    idPessoa: string;
    idCliente: string;
    DataInicio: string;
    DataFim: string;
    ResponsavelEdicao: string;
}
