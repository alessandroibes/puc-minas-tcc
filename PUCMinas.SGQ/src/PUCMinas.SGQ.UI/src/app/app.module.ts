import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';

import { NavegacaoModule } from './navegacao/navegacao.module';
import { AppRoutingModule } from './app.routes';
import { RNCModule } from './modulos/rnc/rnc.module';
import { IdentityModule } from './identity/Identity.module';

import { ConfigService } from './modulos/core/services/config.services';
import { AlertService } from './modulos/core/services/alert.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    NavegacaoModule,
    AppRoutingModule,
    IdentityModule,
    RNCModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ConfigService,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
