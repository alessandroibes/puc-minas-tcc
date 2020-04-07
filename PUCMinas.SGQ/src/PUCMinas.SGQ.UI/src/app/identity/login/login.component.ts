import { Component, OnInit, AfterViewInit, ElementRef } from "@angular/core";
import { Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Observable, fromEvent, merge } from 'rxjs';
import { first } from 'rxjs/operators';

import { BaseCadastroComponent } from "../../modulos/core/base/base-cadastro.component";

import { IdentityService } from '../services/identity.service';
import { GenericValidator } from "../../modulos/core/generic-form-validation";

import { User } from '../models/user';

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent extends BaseCadastroComponent implements OnInit, AfterViewInit {
    returnUrl: string;
    currentUser: User;

    constructor(private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private identityService: IdentityService,
        private router: Router) {
        super();

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
        this.formulario = this.formBuilder.group({
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
            this.displayMessage = this.genericValidator.processarMensagem(this.formulario);
            this.mudancasNaoSalvas = true;
        });
    }

    onSubmit() {
        try {
            if (this.formulario.dirty && this.formulario.valid) {
                this.loading = true;
                this.identityService.login(this.f.username.value, this.f.password.value)
                    .pipe(first())
                    .subscribe(
                        result => {
                            this.router.navigate([this.returnUrl]);
                        },
                        error => {
                            this.alerts = Array.from([{ type: 'danger', message: error }]);
                            this.loading = false;
                        });

                this.mudancasNaoSalvas = false;
            }
        } catch (e) {
            this.loading = false;
            this.alerts = Array.from([{ type: 'danger', message: 'Erro ao tentar logar na aplicação.' }]);
            console.log('Erro na aplicação: ' + e)
        }
    }
}
