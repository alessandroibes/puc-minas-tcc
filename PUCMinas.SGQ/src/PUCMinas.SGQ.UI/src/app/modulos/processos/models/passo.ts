import { Parada } from './parada';

export class Passo {
    id: string;
    worflowId: string;
    titulo: string;
    descricao: string;
    iniciado: boolean;
    finalizado: boolean;
    parada: Parada;
}
