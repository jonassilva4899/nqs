import { SafeResourceUrl } from '@angular/platform-browser';
import { DelegacaoEnum } from './Enums';

export class DelegationCard {
    nome: string;
    imagem: SafeResourceUrl;
    delegation: DelegacaoEnum;
}

export class Delegation{
    idTime: string;
    idDominio: string;
    nomeDominio: string;
    idSupervisor: string;
    nivelAutoridade: DelegacaoEnum;
    idResponsavelTime: string;
    observacao: string;
    idResponsavelCriacao: string;
}

export class ListaDominios {
    idDominio: string;
    nomeDominio: string;
}

export class DelegationBoardTime {
    idDelegationBoard: string;
    nomeDominio: string;
    idDominio: string;
    idSupervisor: string;
    nomeSupervisor: string;
    nivelAutoridade: DelegacaoEnum;
    idResponsavelTime: string;
    nomeResponsavelTime: string;
    observacao: string;
    idResponsavelEdicao?: string;
}

export class DelegationBox {
    qtdDominiosDelegationBoard: number;
}