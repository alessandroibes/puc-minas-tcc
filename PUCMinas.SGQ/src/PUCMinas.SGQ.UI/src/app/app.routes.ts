import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from './navegacao/home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { ListarRNCComponent } from './modulos/rnc/listar-rnc/listar-rnc.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';

import { AuthenticatedGuard } from './identity/services/authenticated.guard';
import { AdminGuard } from './identity/services/admin.guard';

const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, canActivate: [AuthenticatedGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'listar-rnc', component: ListarRNCComponent, canActivate: [AuthenticatedGuard, AdminGuard] },

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
