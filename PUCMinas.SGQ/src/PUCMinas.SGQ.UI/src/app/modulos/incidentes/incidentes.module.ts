import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ListarIncidentesComponent } from './listar-incidentes/listar-incidentes.component';

import { IncidenteService } from './services/incidentes.service';

@NgModule({
    declarations: [
        ListarIncidentesComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    providers: [
        IncidenteService
    ],
    exports: [

    ]
})
export class IncidenteModule { }
