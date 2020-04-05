import { Component, OnInit, AfterViewInit, ElementRef, ViewChildren } from "@angular/core";
import { FormGroup, Validators, FormBuilder, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';
import { first } from 'rxjs/operators';
import { ValidationMessages, GenericValidator, DisplayMessage } from 'src/app/modulos/core/generic-form-validation';
import { Observable, fromEvent, merge } from 'rxjs';
import { AlertService } from 'src/app/modulos/core/services/alert.service';
import { User } from '../models/user';

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit, AfterViewInit {
    loginForm: FormGroup;
    returnUrl: string;
    loading = false;

    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
    validationMessages: ValidationMessages;
    genericValidator: GenericValidator;
    displayMessage: DisplayMessage = {};
    mudancasNaoSalvas: boolean;
    currentUser: User;

    constructor(private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private identityService: IdentityService,
        private router: Router,
        private alertService: AlertService) {

        this.identityService.currentUser.subscribe(x => this.currentUser = x);

        if (this.currentUser) {
            this.router.navigate(['/']);
        }

        this.validationMessages = {
            username: {
                required: 'O preenchimento do campo Username é obrigatório',
                email: 'O Username deve ser um email válido'
            },
            password: {
                required: 'O preenchimento do campo Password é obrigatório'
            }
        };

        this.genericValidator = new GenericValidator(this.validationMessages);
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', [Validators.required, Validators.email]],
            password: ['', Validators.required]
        });

        // obtem a URL de retorno do parâmetro de rota ou usa '/' como padrão
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    ngAfterViewInit(): void {
        let controlBlurs: Observable<any>[] = this.formInputElements
            .map((FormControl: ElementRef) => fromEvent(FormControl.nativeElement, 'blur'));

        merge(...controlBlurs).subscribe(() => {
            this.displayMessage = this.genericValidator.processarMensagem(this.loginForm);
            this.mudancasNaoSalvas = true;
        });
    }

    get f() { return this.loginForm.controls; }

    onSubmit() {
        if (this.loginForm.dirty && this.loginForm.valid) {
            this.loading = true;
            this.identityService.login(this.f.username.value, this.f.password.value)
                .pipe(first())
                .subscribe(
                    result => {
                        this.router.navigate([this.returnUrl]);
                    },
                    data => {
                        this.alertService.error(data.error.errors[0]);
                        this.loading = false;
                    });

            this.mudancasNaoSalvas = false;
        }
    }
}
