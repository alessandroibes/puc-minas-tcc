import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from './navegacao/home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { ListarRNCComponent } from './modulos/rnc/listar-rnc/listar-rnc.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { ManterRNCComponent } from './modulos/rnc/manter-rnc/manter-rnc.component';

import { AuthenticatedGuard } from './identity/services/authenticated.guard';
import { AdminGuard } from './identity/services/admin.guard';
import { CadastroGuard } from './modulos/core/services/cadastro.guard';

const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, canActivate: [AuthenticatedGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'listar-rnc', component: ListarRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard] },
    { path: 'criar-rnc', component: ManterRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [CadastroGuard] },
    { path: 'atualizar-rnc/:id', component: ManterRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard], canDeactivate: [CadastroGuard] },

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
