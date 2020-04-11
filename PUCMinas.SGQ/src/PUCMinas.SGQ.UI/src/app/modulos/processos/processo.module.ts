import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { CoreModule } from '../core/core.module';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

import { ListarWorkflowDefinicaoComponent } from './listar-workflow-definicao/listar-workflow-definicao.component';
import { DetalharWorkflowDefinicaoComponent } from './detalhar-workflow-definicao/detalhar-workflow-definicao.component';
import { ManterWorkflowDefinicaoComponent } from './manter-workflow-definicao/manter-workflow-definicao.component';

import { ProcessoService } from './services/processo.service';

@NgModule({
    declarations: [
        ListarWorkflowDefinicaoComponent,
        DetalharWorkflowDefinicaoComponent,
        ManterWorkflowDefinicaoComponent
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
        ProcessoService
    ],
    exports: []
})
export class ProcessoModule { }
