import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProcessoService } from '../../services/processo.service';
import { Store } from '../../workflow.store';
import { map } from 'rxjs/operators';

@Component({
    selector: 'passos-finalizados',
    templateUrl: './passos-finalizados.component.html'
})
export class PassosFinalizadosComponent implements OnInit {

    finalizados$: Observable<any[]>

    constructor(private processoService: ProcessoService, private store: Store) { }

    ngOnInit() {
        this.finalizados$ = this.store.getTodoList()
            .pipe(
                map(todolist => todolist.filter(passo => passo.finalizado))
            );
    }

    onToggle(event) {
        this.processoService.toggle(event);
    }
}
