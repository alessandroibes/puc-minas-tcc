import { ElementRef, ViewChildren, OnInit, AfterViewInit } from "@angular/core";
import { FormControlName, FormGroup } from "@angular/forms";

import { Observable, fromEvent, merge } from "rxjs";

import { Alert } from "../models/alert";
import { ValidationMessages, GenericValidator, DisplayMessage } from "../generic-form-validation";
import { IsPristineAware } from '../alerts/ui-confirm.module';

export class BaseCadastroComponent implements AfterViewInit, IsPristineAware {
    mudancasNaoSalvas: boolean;
    alerts: Alert[];
    loading = false;

    public formulario: FormGroup;
    validationMessages: ValidationMessages;
    genericValidator: GenericValidator;
    displayMessage: DisplayMessage = {};

    isPristine(): boolean {
        return !this.mudancasNaoSalvas;
    }

    get f() { return this.formulario.controls; }

    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements
            .map((FormControl: ElementRef) => fromEvent(FormControl.nativeElement, 'blur'));

        merge(...controlBlurs).subscribe(() => {
            this.displayMessage = this.genericValidator.processarMensagem(this.formulario);
            this.mudancasNaoSalvas = true;
        });
    }

    closeAlert(alert: Alert) {
        this.alerts.splice(this.alerts.indexOf(alert), 1);
    }

    clearAlerts() {
        this.alerts = [];
    }
}
