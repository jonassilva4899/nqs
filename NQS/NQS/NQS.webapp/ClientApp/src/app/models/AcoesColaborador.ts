export class AcoesColaborador{
    id?: string;
    nomeAcao: string;
    detalheAcao: string;
    data: string;
    idPessoaCriacao: string;
    nomePessoaCriacao?: string;
    idResponsavel: string;
    nomeResponsavel?: string;
    status: number;
}

export class ListaResponsaveis{
    idMembro: string;
    nomeMembro: string;
}
