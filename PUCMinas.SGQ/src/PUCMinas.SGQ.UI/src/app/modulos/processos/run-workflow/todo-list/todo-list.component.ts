import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Passo } from '../../models/passo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Parada } from '../../models/parada';
import { ProcessoService } from '../../services/processo.service';

@Component({
    selector: 'todo-list',
    templateUrl: './todo-list.component.html',
    styleUrls: ['todo-list.component.css']
})
export class ToDoListComponent {
    @Input()
    list: Passo[];

    @Output()
    toggle = new EventEmitter<any>();

    constructor(private modalService: NgbModal, private processoService: ProcessoService) { }

    toggleItem(index: number, acao: string) {
        const passo = this.list[index];

        switch (acao) {
            case 'iniciar':
                passo.finalizado = false;
                passo.iniciado = true;
                break;
            case 'finalizar':
                passo.finalizado = true;
                passo.iniciado = false;
                break;
            case 'retomar':
                passo.finalizado = false;
                passo.iniciado = true;
                break;
            case 'cancelar':
                passo.finalizado = false;
                passo.iniciado = false;
                break;
        }

        this.toggle.emit({
            passo: { ...passo }
        });
    }

    TITULO_PASSO: any;
    open(content, index: number) {
        const passo = this.list[index];
        this.TITULO_PASSO = passo.titulo;
        this.modalService.open(content, { ariaLabelledBy: 'registrar-parada-modal' }).result.then((result) => {
            //this.closeResult = `Closed with: ${result}`;

            let parada = new Parada;
            parada.descricao = result;
            parada.incidenteCadastrado = false;
            parada.passoId = passo.id;

            this.processoService.registrarParada(parada).subscribe(result => {
                passo.parada = result as Parada;
            });
        });
    }
}
