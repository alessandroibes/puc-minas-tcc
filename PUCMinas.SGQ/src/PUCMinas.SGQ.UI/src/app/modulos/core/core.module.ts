import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';

import { ConfigService } from './services/config.services';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule
    ],
    providers: [
        ConfigService
    ],
    exports: [
    ]
})
export class CoreModule { }
