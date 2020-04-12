import { Passo } from './passo';

export class Workflow {
    id: string;
    nome: string;
    iniciado: boolean;
    finalizado: boolean;
    passos: Passo[];
}
