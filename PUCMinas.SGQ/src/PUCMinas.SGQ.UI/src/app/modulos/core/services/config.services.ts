import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {
    // 5001 IdentityService
    // 5003 Incidentes
    // 5005 Processos
    // 5007 API Getway
    get apiIdentityServiceAddress() {
        return 'https://localhost:5001/api/';
    }

    get apiIncidentesAddress() {
        return 'https://localhost:5003/api/';
    }

    get apiProcessosAddress() {
        return 'https://localhost:5005/api/';
    }

    get apiGetwayAddress() {
        return 'https://localhost:5007/api/';
    }
}
