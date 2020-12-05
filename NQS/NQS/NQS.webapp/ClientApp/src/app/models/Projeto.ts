import { Guid } from 'guid-typescript';
import { CategoriaProjeto, DeliveryProjeto, StatusProjeto } from './Enums';
import { Pessoa } from './Pessoa';
import { ClientePerfil } from './ClientePerfil';

export class Projeto {
    exibicaoMensagem: string;
    objeto: ProjetoDados[];
}

export class ProjetoDados {
    id: string;
    idTime: string;
    nome: string;
    logo: string;
    descricao: string;
    idCliente: string;
    nomeCliente: string;
    idComercial: string;
    idResponsavel: string;
    nomeResponsavel: string;
    idResponsavelComercial: string;
    nomeResponsavelComercial: string;
    statusProjeto: StatusProjeto;
    categoriaProjeto: CategoriaProjeto;
    deliveryProjeto: DeliveryProjeto;
    dataInicio: Date;
    dataFim: Date;
    custo: number;
    receita: number;
    esforco: number;
    dataCriacao: Date;
    responsavelCriacao: string;
    dataEdicao: Date;
    responsavelEdicao: Guid;
    status: boolean;
    cardsConcluidos: number;
    // timeProjetos: TimeProjeos[];
    // responsavelProjetos: ResponsavelProjetos[];
}

export class ProjetoDadosBasicos {
    idProjeto: string;
    nome: string;
}

export class FiltroProjeto {
    ordenacao = '';
    status = '';
    idCliente = '';
}
