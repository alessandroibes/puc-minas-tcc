import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../modulos/core/core.module';

import { LoginComponent } from './login/login.component';

import { IdentityService } from './services/identity.service';
import { AdminGuard } from './services/admin.guard';
import { AuthenticatedGuard } from './services/authenticated.guard';
import { JwtInterceptor } from './services/jwt.interceptor';

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        CoreModule
    ],
    providers: [
        IdentityService,
        AdminGuard,
        AuthenticatedGuard,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
    ],
    exports: [
    ]

})
export class IdentityModule { }
