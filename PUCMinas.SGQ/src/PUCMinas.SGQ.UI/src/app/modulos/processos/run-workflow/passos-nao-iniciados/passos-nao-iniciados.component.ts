import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ProcessoService } from '../../services/processo.service';
import { Store } from '../../workflow.store';
import { map } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'passos-nao-iniciados',
    templateUrl: './passos-nao-iniciados.component.html'
})
export class PassosNaoIniciadosComponent implements OnInit, OnDestroy {
    id: string;

    todolist$: Observable<any[]>
    subscription: Subscription;

    constructor(private processoService: ProcessoService, private store: Store, private route: ActivatedRoute) {
        this.id = this.route.snapshot.paramMap.get("id");
    }

    ngOnInit() {
        this.todolist$ = this.store.getTodoList()
            .pipe(
                map(todolist => todolist.filter(passo => !passo.iniciado && !passo.finalizado))
            );

        this.subscription = this.processoService.getPassos(this.id).subscribe(result => {
            console.log(result);
        }, error => {
            console.log(error);
        });
    }

    onToggle(event) {
        this.processoService.toggle(event);
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
