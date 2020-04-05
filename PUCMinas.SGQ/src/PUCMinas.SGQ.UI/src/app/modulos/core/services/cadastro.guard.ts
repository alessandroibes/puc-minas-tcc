import { Injectable } from "@angular/core";
import { CanDeactivate } from '@angular/router';
import { BaseCadastroComponent } from "../base/base-cadastro.component";

@Injectable()
export class CadastroGuard implements CanDeactivate<BaseCadastroComponent> {

    canDeactivate(component: BaseCadastroComponent) {
        if (component.mudancasNaoSalvas) {
            return window.confirm('Há alterações não salvas. Tem certeza que deseja abandonar o preenchimento do formulário?');
        }

        return true;
    }
}
