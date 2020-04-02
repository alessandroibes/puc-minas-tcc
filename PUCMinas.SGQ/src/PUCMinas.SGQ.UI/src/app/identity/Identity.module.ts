import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login/login.component';

import { IdentityService } from './services/identity.service';
import { AdminGuard } from './services/admin.guard';
import { AuthenticatedGuard } from './services/authenticated.guard';

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        IdentityService,
        AdminGuard,
        AuthenticatedGuard
    ],
    exports: [
    ]

})
export class IdentityModule { }
