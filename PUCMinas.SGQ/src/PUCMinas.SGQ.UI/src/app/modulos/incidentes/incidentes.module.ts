import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { IncidenteService } from './incidentes.service';
import { ConfigService } from '../core/config.services';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    providers: [
        ConfigService,
        IncidenteService
    ],
    declarations: [
    ],
    exports: [
    ]
})
export class IncidenteModule { }
