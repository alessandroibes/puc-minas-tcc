import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {
    // 5001 IdentityService
    // 5003 Incidentes
    get apiAddress() {
        return 'https://localhost:5001/api/v1/';
    }
}
