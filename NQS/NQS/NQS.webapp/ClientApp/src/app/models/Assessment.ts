import { QuestaoCompetencia } from './Competencia';

export class Assessment {
    idPesquisaCompetencia: string;
    nomeCompetencia: string;
    observacao: string;
    assessmentPesquisaQuestoes: QuestaoAssessment[];
}

export class QuestaoAssessment {
    idPesquisaQuestao: string;
    ordem: number;
    questaoOpcaoViewModels: OpcaoQuestaoAssessment[];
    resposta: any;
    respostaModel: any;
    tituloQuestao: string;
}

export class OpcaoQuestaoAssessment {
    descricao: string;
    idQuestaoOpcao: string;
    temperaturaTermometro: number;
}

export class InfoUltimoAssessment {
    colaboradoresNaoResponderam: number;
    colaboradoresRespondendo: number;
    colaboradoresResponderam: number;
    dataDisparo: string;
    idAssessmentPesquisa: string;
    mediaNota: string;
    totalColaboradores: number;
    assessmentPessoas: AssessmentPessoa[];
}

export class AssessmentPessoa {
    idPessoa: string;
    nome: string;
    status: AssessmentPessoaRespostaStatus;
}

export enum AssessmentPessoaRespostaStatus {
    NaoIniciado = 1,
    EmProgresso = 2,
    Finalizado = 3,
}

export class AssessmentApurado {
    media: number;
    quantidadeNaoRespondidos: number;
    quantidadeRespondidos: number;
    total: number;
    dataUltimoEnvio: string;
}
