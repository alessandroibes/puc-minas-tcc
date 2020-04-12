import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Passo } from '../../models/passo';

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
}
