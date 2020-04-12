import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProcessoService } from '../../services/processo.service';
import { Store } from '../../workflow.store';
import { map } from 'rxjs/operators';

@Component({
    selector: 'passos-iniciados',
    templateUrl: './passos-iniciados.component.html'
})
export class PassosIniciadosComponent implements OnInit {

    iniciados$: Observable<any[]>

    constructor(private processoService: ProcessoService, private store: Store) { }

    ngOnInit() {
        this.iniciados$ = this.store.getTodoList()
            .pipe(
                map(todolist => todolist.filter(passo => passo.iniciado && !passo.finalizado))
            );
    }

    onToggle(event) {
        this.processoService.toggle(event);
    }
}
