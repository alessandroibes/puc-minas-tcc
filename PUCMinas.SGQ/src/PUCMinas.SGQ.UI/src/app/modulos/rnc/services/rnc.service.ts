import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from '../../core/services/config.services';
import { BaseService } from '../../core/services/base.service';

import { RNC } from '../models/rnc';
import { Observable } from 'rxjs';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';
import { catchError } from 'rxjs/operators';


@Injectable()
export class RNCService extends BaseService {
    constructor(private http: HttpClient, private config: ConfigService) {
        super();
    }

    // Gravidade
    getGravidade(): Observable<Gravidade[]> {
        return this.http.get<Gravidade[]>(this.config.apiIncidentesAddress + "v1/gravidade");
    }

    // Causa
    getCausa(): Observable<Causa[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "v1/causas");
    }

    // Acao
    getAcao(): Observable<Acao[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "v1/acoes");
    }

    // RNC
    getRNC(): Observable<RNC[]> {
        return this.http.get<RNC[]>(this.config.apiIncidentesAddress + "v1/rncs");
    }

    getRNCPorId(id: string): Observable<RNC> {
        return this.http.get<RNC>(this.config.apiIncidentesAddress + "v1/rncs/" + id);
    }

    addRNC(rnc: RNC): Observable<any> {
        return this.http.post<any>(this.config.apiIncidentesAddress + "v1/rncs", rnc).pipe(catchError(this.handleError));
    }

    updateRNC(rnc: RNC, id: string): Observable<any> {
        return this.http.put<any>(this.config.apiIncidentesAddress + "v1/rncs/" + id, rnc).pipe(catchError(this.handleError));
    }
}
