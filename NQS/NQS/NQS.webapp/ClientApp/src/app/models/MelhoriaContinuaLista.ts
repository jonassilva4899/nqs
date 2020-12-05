import { CompetenciaEnum, OrigemEnum, StatusEnum } from './Enums';

export class MelhoriaContinuaLista{
    id: string;
    idTime: string;
    acao: string;
    descricao: string;
    origem: OrigemEnum;
    competencia: CompetenciaEnum;
    status: StatusEnum;
    dataInclusao: string;
    idResponsavelMelhoriaContinua: string;
    nomeResponsavelMelhoriaContinua: string;
    idResponsavelEdicao: string;
    idResponsavelCriacao: string;
}