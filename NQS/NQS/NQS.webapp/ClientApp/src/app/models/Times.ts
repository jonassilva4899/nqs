import { Guid } from 'guid-typescript';
import { TermometroAgilEnum } from './Enums';

export class Times {
    exibicaoMensagem: string;
    objeto: TimesDados[];
}

export class TimesDados {
    id: Guid;
    logo: string;
    nome: string;
    capacidade: number;
    membros: number;
    colaboradores: number;
    projetos: number;
    praticas: number;
    segue: boolean;
    praticaAgilEmFalta: boolean;
    ativo: boolean;
}

export class TimeDadosBasicos {
    id: string;
    nome: string;
    logo?: string;
}

export class FiltroTimes {
    idGrupo: string;
    idProjeto: string;
    idCliente: string;
    temperatura: TermometroAgilEnum;
}
