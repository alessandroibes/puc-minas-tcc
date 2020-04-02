import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from './navegacao/home/home.component';
import { LoginComponent } from './identity/login/login.component';
import { AuthenticatedGuard } from './identity/services/authenticated.guard';
import { AdminGuard } from './identity/services/admin.guard';
import { ListarIncidentesComponent } from './modulos/incidentes/listar-incidentes/listar-incidentes.component';

const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'listar-incidentes', component: ListarIncidentesComponent, canActivate: [AuthenticatedGuard, AdminGuard] }
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
