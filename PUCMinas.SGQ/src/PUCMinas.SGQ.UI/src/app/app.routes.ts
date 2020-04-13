import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from './navegacao/home/home.component';
import { LoginComponent } from './identity/login/login.component';

import { ListarRNCComponent } from './modulos/rnc/listar-rnc/listar-rnc.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { ManterRNCComponent } from './modulos/rnc/manter-rnc/manter-rnc.component';

import { ListarWorkflowDefinicaoComponent } from './modulos/processos/listar-workflow-definicao/listar-workflow-definicao.component';

import { AuthenticatedGuard } from './identity/services/authenticated.guard';
import { AdminGuard } from './identity/services/admin.guard';
import { IsPristineGuard } from './modulos/core/alerts/ui-confirm.module';
import { ManterWorkflowDefinicaoComponent } from './modulos/processos/manter-workflow-definicao/manter-workflow-definicao.component';
import { RunWorkflowComponent } from './modulos/processos/run-workflow/run-workflow.component';
import { ListarWorkflowAndamentoComponent } from './modulos/processos/listar-workflow-andamento/listar-workflow-andamento.component';

const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, canActivate: [AuthenticatedGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'listar-rnc', component: ListarRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard] },
    { path: 'criar-rnc', component: ManterRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [IsPristineGuard] },
    { path: 'atualizar-rnc/:id', component: ManterRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [IsPristineGuard] },
    { path: 'listar-workflow-definicao', component: ListarWorkflowDefinicaoComponent, canActivate: [AuthenticatedGuard, AdminGuard] },
    { path: 'criar-workflow-definicao', component: ManterWorkflowDefinicaoComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [IsPristineGuard] },
    { path: 'atualizar-workflow-definicao/:id', component: ManterWorkflowDefinicaoComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [IsPristineGuard] },
    { path: 'listar-workflow-andamento', component: ListarWorkflowAndamentoComponent, canActivate: [AuthenticatedGuard, AdminGuard] },
    { path: 'run-workflow/:id', component: RunWorkflowComponent, canActivate: [AuthenticatedGuard, AdminGuard] },

    // otherwise redirect to 404 page
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    declarations: [
    ],
    imports: [
        RouterModule.forRoot(rootRouterConfig, { enableTracing: false })
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }
