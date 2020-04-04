import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/services/config.services';
import { RNC } from '../models/rnc';
import { Observable } from 'rxjs';
import { Gravidade } from '../models/gravidade';
import { Causa } from '../models/causa';
import { Acao } from '../models/acao';

@Injectable()
export class RNCService {
    constructor(private http: HttpClient, private config: ConfigService) { }

    getRNC(): Observable<RNC[]> {
        return this.http.get<RNC[]>(this.config.apiIncidentesAddress + "v1/rncs");
    }

    getRNCPorId(id: string): Observable<RNC> {
        return this.http.get<RNC>(this.config.apiIncidentesAddress + "v1/rncs/" + id);
    }

    getGravidade(): Observable<Gravidade[]> {
        return this.http.get<Gravidade[]>(this.config.apiIncidentesAddress + "v1/gravidade");
    }

    getCausa(): Observable<Causa[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "v1/causas");
    }

    getAcao(): Observable<Acao[]> {
        return this.http.get<Causa[]>(this.config.apiIncidentesAddress + "v1/acoes");
    }
}
