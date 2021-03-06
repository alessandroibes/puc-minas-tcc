import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from '../../core/services/config.services';
import { BaseService } from '../../core/services/base.service';

import { RNC } from '../models/rnc';
import { Observable } from 'rxjs';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';
import { catchError, map } from 'rxjs/operators';


@Injectable()
export class RNCService extends BaseService {
    constructor(private http: HttpClient, private config: ConfigService) {
        super();
    }

    // Gravidade
    getGravidade(): Observable<Gravidade[]> {
        return this.http.get<Gravidade[]>(this.config.apiIncidentesAddress + "api/v1/gravidade").pipe(catchError(this.handleError));
    }

    // Causa
    getCausa(): Observable<Causa[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "api/v1/causas").pipe(catchError(this.handleError));
    }

    // Acao
    getAcao(): Observable<Acao[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "api/v1/acoes").pipe(catchError(this.handleError));
    }

    // RNC
    getRNC(): Observable<RNC[]> {
        return this.http.get<RNC[]>(this.config.apiIncidentesAddress + "api/v1/rncs").pipe(catchError(this.handleError));
    }

    getRNCPorId(id: string): Observable<RNC> {
        return this.http.get<RNC>(this.config.apiIncidentesAddress + "api/v1/rncs/" + id).pipe(catchError(this.handleError));
    }

    addRNC(rnc: RNC): Observable<RNC> {
        let response = this.http
            .post(this.config.apiIncidentesAddress + "api/v1/rncs", rnc)
            .pipe(
                map(this.extractData), catchError(this.handleError));

        return response;
    }

    updateRNC(rnc: RNC, id: string): Observable<any> {
        return this.http.put<any>(this.config.apiIncidentesAddress + "api/v1/rncs/" + id, rnc).pipe(catchError(this.handleError));
    }
}
