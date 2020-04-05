import { Causa } from './causa';
import { Acao } from './acao';
import { Gravidade } from './gravidade';

export class RNC {
    id: string;
    ocorrencia: string;
    descricao: string;
    classificacao: number;
    status: number;
    gravidade: Gravidade;
    causa: Causa;
    acao: Acao;
    prazo: Date;
    dataOcorrencia: Date;
}
