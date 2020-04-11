import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from '../../core/services/config.services';
import { BaseService } from '../../core/services/base.service';

import { Observable } from 'rxjs';
import { WorkflowDefinicao } from '../models/workflowdefinicao';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ProcessoService extends BaseService {
    constructor(private http: HttpClient, private config: ConfigService) {
        super();
    }

    // WorflowDefinicao
    getWorflowDefinicao(): Observable<WorkflowDefinicao[]> {
        return this.http.get<WorkflowDefinicao[]>(this.config.apiProcessosAddress + "v1/workflowdefinicao").pipe(catchError(this.handleError));
    }

    getWorflowDefinicaoPorId(id: string): Observable<WorkflowDefinicao> {
        return this.http.get<WorkflowDefinicao>(this.config.apiProcessosAddress + "v1/workflowdefinicao/" + id).pipe(catchError(this.handleError));
    }

    addWorflowDefinicao(wd: WorkflowDefinicao): Observable<any> {
        return this.http.post<any>(this.config.apiProcessosAddress + "v1/workflowdefinicao", wd).pipe(catchError(this.handleError));
    }

    updateWorflowDefinicao(wd: WorkflowDefinicao, id: string): Observable<any> {
        return this.http.put<any>(this.config.apiProcessosAddress + "v1/workflowdefinicao/" + id, wd).pipe(catchError(this.handleError));
    }
}
