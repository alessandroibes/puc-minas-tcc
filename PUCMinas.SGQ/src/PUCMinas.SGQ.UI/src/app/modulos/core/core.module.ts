import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';

import { AlertComponent } from './alerts/alert.component';

import { AlertService } from './services/alert.service';
import { ConfigService } from './services/config.services';

@NgModule({
    declarations: [
        AlertComponent
    ],
    imports: [
        CommonModule
    ],
    providers: [
        AlertService,
        ConfigService
    ],
    exports: [
        AlertComponent
    ]
})
export class CoreModule { }
