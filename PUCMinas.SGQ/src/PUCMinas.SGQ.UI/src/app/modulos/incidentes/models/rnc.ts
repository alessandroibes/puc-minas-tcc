import { Guid } from "guid-typescript";
import { StatusRNC } from './status';

export interface RNC {
    id: Guid,
    ocorrencia: string,
    descricao: string,
    classificacao: number,
    engenheiroResponsavel: Guid,
    gestorAvaliador: Guid,
    status: StatusRNC,
    gravidadeId: Guid,
    causaId: Guid,
    acaoId: Guid,
    prazo: Date,
    dataOcorrencia: Date
}
