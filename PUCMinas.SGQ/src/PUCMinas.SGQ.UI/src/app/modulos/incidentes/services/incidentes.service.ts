import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../core/services/config.services';
import { RNC } from '../models/rnc';
import { Observable } from 'rxjs';

@Injectable()
export class IncidenteService {
    constructor(private http: HttpClient, private config: ConfigService) { }

    getRNC(): Observable<RNC[]> {
        return this.http.get<RNC[]>(this.config.apiIncidentesAddress + "v1/RNCs");
    }
}
