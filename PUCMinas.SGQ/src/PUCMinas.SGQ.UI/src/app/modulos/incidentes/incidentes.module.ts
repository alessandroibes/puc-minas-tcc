import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ListarIncidentesComponent } from './listar-incidentes/listar-incidentes.component';

import { IncidenteService } from './services/incidentes.service';
import { ConfigService } from '../core/services/config.services';

@NgModule({
    declarations: [
        ListarIncidentesComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        ConfigService,
        IncidenteService
    ],
    exports: [

    ]
})
export class IncidenteModule { }
