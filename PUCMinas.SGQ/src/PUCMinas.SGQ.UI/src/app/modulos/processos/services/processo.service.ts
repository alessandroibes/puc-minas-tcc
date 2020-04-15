import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from '../../core/services/config.services';
import { BaseService } from '../../core/services/base.service';

import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { WorkflowDefinicao } from '../models/workflowdefinicao';
import { Store } from '../workflow.store';
import { Workflow } from '../models/workflow';
import { Passo } from '../models/passo';
import { Parada } from '../models/parada';

@Injectable()
export class ProcessoService extends BaseService {
    constructor(private http: HttpClient,
        private config: ConfigService,
        private store: Store) {
        super();
    }

    // WorflowDefinicao
    getWorflowDefinicao(): Observable<WorkflowDefinicao[]> {
        return this.http.get<WorkflowDefinicao[]>(this.config.apiProcessosAddress + "api/v1/workflowdefinicao").pipe(catchError(this.handleError));
    }

    getWorflowDefinicaoPorId(id: string): Observable<WorkflowDefinicao> {
        return this.http.get<WorkflowDefinicao>(this.config.apiProcessosAddress + "api/v1/workflowdefinicao/" + id).pipe(catchError(this.handleError));
    }

    addWorflowDefinicao(wd: WorkflowDefinicao): Observable<any> {
        return this.http.post<any>(this.config.apiProcessosAddress + "api/v1/workflowdefinicao", wd).pipe(catchError(this.handleError));
    }

    updateWorflowDefinicao(wd: WorkflowDefinicao, id: string): Observable<any> {
        return this.http.put<any>(this.config.apiProcessosAddress + "api/v1/workflowdefinicao/" + id, wd).pipe(catchError(this.handleError));
    }

    // workflow
    getWorflowEmAndamento(): Observable<Workflow[]> {
        return this.http.get<Workflow[]>(this.config.apiProcessosAddress + "api/v1/workflow/todolist").pipe(catchError(this.handleError));
    }

    getPassos(workflowId: string): Observable<Passo[]> {
        return this.http.get<Passo[]>(this.config.apiProcessosAddress + 'api/v1/workflow/todolist/' + workflowId)
            .pipe(tap(next => this.store.set('todolist', next)))
            .pipe(catchError(this.handleError));
    }

    criarWorkflow(workflowDefinicaoId: string): Observable<Workflow> {
        return this.http.get<Workflow>(this.config.apiProcessosAddress + 'api/v1/workflow/criar-workflow/' + workflowDefinicaoId).pipe(catchError(this.handleError));
    }

    registrarParada(parada: Parada): Observable<any> {
        return this.http.post<any>(this.config.apiProcessosAddress + 'api/v1/workflow/registrar-parada', parada).pipe(catchError(this.handleError));
    }

    toggle(event: any) {
        this.http
            .put(this.config.apiProcessosAddress + `api/v1/workflow/todolist/${event.passo.id}`, event.passo)
            .subscribe(() => {
                const value = this.store.value.todolist;

                const todolist = value.map((passo: Passo) => {
                    if (event.passo.id === passo.id) {
                        return { ...passo, ...event.passo }
                    } else {
                        return passo;
                    }
                });

                this.store.set('todolist', todolist);
            });
    }
}
