import { PassoDefinicao } from './passodefinicao';

export interface WorkflowDefinicao {
    id: string;
    nome: string;
    passosDefinicao: PassoDefinicao[];
}
