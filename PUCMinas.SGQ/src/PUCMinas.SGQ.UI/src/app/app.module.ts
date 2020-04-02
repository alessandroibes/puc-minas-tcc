import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app.routes';
import { IncidenteModule } from './modulos/incidentes/incidentes.module';
import { LoginComponent } from './identity/login/login.component';

import { AdminGuard } from './identity/services/admin.guard';
import { AuthenticatedGuard } from './identity/services/authenticated.guard';
import { IdentityService } from './identity/services/identity.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    NavegacaoModule,
    AppRoutingModule,
    IncidenteModule,
    ReactiveFormsModule
  ],
  providers: [
    AdminGuard,
    AuthenticatedGuard,
    IdentityService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
