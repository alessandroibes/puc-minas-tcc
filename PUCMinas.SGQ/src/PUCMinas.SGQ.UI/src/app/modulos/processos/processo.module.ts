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
import { PassosNaoIniciadosComponent } from './run-workflow/passos-nao-iniciados/passos-nao-iniciados.component';
import { PassosIniciadosComponent } from './run-workflow/passos-iniciados/passos-iniciados.component';
import { PassosFinalizadosComponent } from './run-workflow/passos-finalizados/passos-finalizados.component';
import { ToDoListComponent } from './run-workflow/todo-list/todo-list.component';
import { RunWorkflowComponent } from './run-workflow/run-workflow.component';

import { ProcessoService } from './services/processo.service';
import { Store } from './workflow.store';

@NgModule({
    declarations: [
        ListarWorkflowDefinicaoComponent,
        DetalharWorkflowDefinicaoComponent,
        ManterWorkflowDefinicaoComponent,
        PassosNaoIniciadosComponent,
        PassosIniciadosComponent,
        PassosFinalizadosComponent,
        ToDoListComponent,
        RunWorkflowComponent
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
        ProcessoService,
        Store
    ],
    exports: [
        ListarWorkflowDefinicaoComponent,
        DetalharWorkflowDefinicaoComponent,
        ManterWorkflowDefinicaoComponent,
        PassosNaoIniciadosComponent,
        PassosIniciadosComponent,
        PassosFinalizadosComponent,
        ToDoListComponent,
        RunWorkflowComponent
    ]
})
export class ProcessoModule { }
