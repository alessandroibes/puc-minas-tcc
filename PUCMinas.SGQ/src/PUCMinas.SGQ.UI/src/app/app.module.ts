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

import { CadastroGuard } from './modulos/core/services/cadastro.guard';

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
    CadastroGuard
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
