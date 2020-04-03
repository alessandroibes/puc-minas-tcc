import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ListarRNCComponent } from './listar-rnc/listar-rnc.component';

import { RNCService } from './services/rnc.service';

@NgModule({
    declarations: [
        ListarRNCComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    providers: [
        RNCService
    ],
    exports: [

    ]
})
export class RNCModule { }
