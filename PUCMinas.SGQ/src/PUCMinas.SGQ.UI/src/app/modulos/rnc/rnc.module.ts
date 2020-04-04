import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { CoreModule } from '../core/core.module';

import { ListarRNCComponent } from './listar-rnc/listar-rnc.component';
import { ManterRNCComponent } from './manter-rnc/manter-rnc.component';

import { RNCService } from './services/rnc.service';

@NgModule({
    declarations: [
        ListarRNCComponent,
        ManterRNCComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        CoreModule
    ],
    providers: [
        RNCService
    ],
    exports: [

    ]
})
export class RNCModule { }
