/*
Credit to: https://gist.github.com/jnizet/15c7a0ab4188c9ce6c79ca9840c71c4e
Credit to: Giuseppe Luca Lo Re 
*/

import { NgModule, Component, Injectable } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CanDeactivate } from '@angular/router';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

/**
 * The guarded Component should implement this interface
 */
export interface IsPristineAware {
    isPristine(): boolean;
}

/**
* Guard to use with the guarded Component
* component: GuardedComponent,
* canActivate: [IsPristineGuard],
**/
@Injectable()
export class IsPristineGuard implements CanDeactivate<IsPristineAware> {
    constructor(private confirmService: ConfirmService) { }
    canDeactivate(component: IsPristineAware): Promise<boolean> {
        if (!component.isPristine()) {
            return this.confirmService.confirm({ title: 'Confirmação', message: 'Tem certeza que deseja sair do formulário e perder as alterações não salvas?' });
        }
        return Promise.resolve(true);
    }
}

/**
 * Options passed when opening a confirmation modal
 */
interface ConfirmOptions {
    /**
     * The title of the confirmation modal
     */
    title: string,

    /**
     * The message in the confirmation modal
     */
    message: string
}

/**
 * An internal service allowing to access, from the confirm modal component, 
 * the options and the modal reference.
*/

@Injectable()
export class ConfirmState {
    /**
     * The last options passed ConfirmService.confirm()
     */
    options: ConfirmOptions;

    /**
     * The last opened confirmation modal
     */
    modal: NgbModalRef;
}

/**
 * A confirmation service, allowing to open a confirmation modal from anywhere and get back a promise.
 */
@Injectable()
export class ConfirmService {

    constructor(private modalService: NgbModal, private state: ConfirmState) { }

    /**
     * Opens a confirmation modal
     * @param options the options for the modal (title and message)
     * @returns {Promise<boolean>} a promise that is fulfilled when the user chooses to confirm
     * or closes the modal
     */
    confirm(options: ConfirmOptions): Promise<boolean> {
        this.state.options = options;
        this.state.modal = this.modalService.open(UIConfirmComponent, { size: 'dialog' });
        return this.state.modal.result;
    }
}

/**
 * The component displayed in the confirmation modal opened by the ConfirmService.
 */
@Component({
    selector: 'ui-confirm-modal',
    template: `<div class="modal-header">
    <h4 class="modal-title">
      {{ options.title}}
    </h4>
    <button type="button" class="close" aria-label="Close" (click)="no()">
        <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div class="modal-body">
    <p>{{ options.message }}</p>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-danger" (click)="yes()">Sim</button>
    <button type="button" class="btn btn-secondary" (click)="no()">Não</button>
  </div>`
})
export class UIConfirmComponent {

    options: ConfirmOptions;

    constructor(private state: ConfirmState) {
        this.options = state.options;
    }

    yes() {
        this.state.modal.close(true);
    }

    no() {
        this.state.modal.close(false);
    }
}

// MODULE
const UI_CONFIRM_COMPONENTS = [UIConfirmComponent];
const UI_CONFIRM_PROVIDERS = [ConfirmState, ConfirmService, IsPristineGuard];

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: UI_CONFIRM_COMPONENTS,
    providers: UI_CONFIRM_PROVIDERS,
    exports: UI_CONFIRM_COMPONENTS,
    entryComponents: [
        UIConfirmComponent
    ]
})
export class UiConfirmModule { }
