import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { CoreModule } from '../core/core.module';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

import { ListarRNCComponent } from './listar-rnc/listar-rnc.component';
import { ManterRNCComponent } from './manter-rnc/manter-rnc.component';
import { DetalharRNCModalComponent } from './detalhar-rnc/detalhar-rnc-modal.component';

import { RNCService } from './services/rnc.service';



@NgModule({
    declarations: [
        ListarRNCComponent,
        ManterRNCComponent,
        DetalharRNCModalComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        CoreModule,
        NgbAlertModule
    ],
    providers: [
        RNCService
    ],
    exports: [

    ]
})
export class RNCModule { }
