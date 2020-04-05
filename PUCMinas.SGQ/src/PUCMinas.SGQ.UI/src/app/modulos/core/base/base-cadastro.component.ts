import { ElementRef, ViewChildren, OnInit, AfterViewInit } from "@angular/core";
import { FormControlName, FormGroup } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";

import { Observable, fromEvent, merge } from "rxjs";

import { Alert } from "../models/alert";
import { ValidationMessages, GenericValidator, DisplayMessage } from "../generic-form-validation";

export class BaseCadastroComponent implements OnInit, AfterViewInit {
    mudancasNaoSalvas: boolean;
    alerts: Alert[];
    loading = false;
    id: string;

    formulario: FormGroup;
    validationMessages: ValidationMessages;
    genericValidator: GenericValidator;
    displayMessage: DisplayMessage = {};

    constructor(protected route: ActivatedRoute) { }

    get f() { return this.formulario.controls; }

    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

    ngOnInit(): void {
        this.id = this.route.snapshot.paramMap.get("id");
    }

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
