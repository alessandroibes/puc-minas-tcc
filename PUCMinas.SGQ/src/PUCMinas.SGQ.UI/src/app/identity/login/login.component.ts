import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IdentityService } from '../services/identity.service';
import { first } from 'rxjs/operators';

@Component({
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    returnUrl: string;
    submitted = false;
    loading = false;

    constructor(private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private identityService: IdentityService,
        private router: Router) {
        if (this.identityService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });

        // obtem a URL de retorno do parâmetro de rota ou usa '/' como padrão
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // para por aqui caso o formulário esteja inválido
        if (this.loginForm.invalid) {
            return;
        }

        this.loading = true;
        this.identityService.login(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    //this.alertService.error(error);
                    console.log(error);
                    this.loading = false;
                });
    }
}
