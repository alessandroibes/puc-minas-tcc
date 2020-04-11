import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app.routes';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { UiConfirmModule } from './modulos/core/alerts/ui-confirm.module';

import { IdentityModule } from './identity/Identity.module';
import { RNCModule } from './modulos/rnc/rnc.module';
import { ProcessoModule } from './modulos/processos/processo.module';

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
    ProcessoModule,
    FormsModule,
    ReactiveFormsModule,
    UiConfirmModule
  ],
  providers: [

  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }