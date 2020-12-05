import { Guid } from 'guid-typescript';
import { CategoriaProjeto, DeliveryProjeto, StatusProjeto } from './Enums';

export class ConfiguracaoProjeto {
    nome: string;
    logo: string;
    descricao: string;
    idCliente: Guid;
    idResponsavel: Guid;
    idComercial: Guid;
    status: StatusProjeto;
    categoria: CategoriaProjeto;
    delivery: DeliveryProjeto;
    dataInicio: Date;
    dataFim: Date;
    custo: number;
    receita: number;
    esforco: number;
}
