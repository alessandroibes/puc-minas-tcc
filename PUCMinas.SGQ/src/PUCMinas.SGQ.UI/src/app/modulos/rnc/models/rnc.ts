import { Guid } from 'guid-typescript';

export interface RNC {
    id: Guid,
    ocorrencia: string,
    descricao: string,
    classificacao: number,
    engenheiroResponsavel: Guid,
    gestorAvaliador: Guid,
    status: number,
    gravidadeId: Guid,
    causaId: Guid,
    acaoId: Guid,
    dataOcorrencia: Date
}
