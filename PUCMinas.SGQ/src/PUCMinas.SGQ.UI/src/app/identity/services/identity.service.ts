import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/app/modulos/core/services/config.services';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user'

@Injectable({
    providedIn: 'root'
})
export class IdentityService {
    private loggedUser: User;
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient, private config: ConfigService) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        const now = Date.now();
        if (this.currentUserSubject && this.currentUserSubject.value && this.currentUserSubject.value.expiresIn < now) {
            this.logout();
        }

        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<any>(this.config.apiIdentityServiceAddress + "v1/entrar", { email, password })
            .pipe(map(response => {
                if (response && response.success) {
                    this.loggedUser = new User;
                    this.loggedUser.email = email;
                    this.loggedUser.password = password;
                    this.loggedUser.expiresIn = (response.data.expiresIn * 1000) + Date.now();
                    this.loggedUser.loginUser = response.data;

                    response.data.userToken.claims.filter(x => x.type = "role").map(role => {
                        switch (role.value) {
                            case "admin":
                                this.loggedUser.admin = true;
                                break;
                            case "gerente":
                                this.loggedUser.gerente = true;
                                break;
                            case "operador":
                                this.loggedUser.operador = true;
                                break;
                            case "engenheiro":
                                this.loggedUser.engenheiro = true;
                                break;
                            case "gestor":
                                this.loggedUser.gestor = true;
                                break;
                        }
                    });

                    localStorage.setItem('currentUser', JSON.stringify(this.loggedUser));
                    this.currentUserSubject.next(this.loggedUser);
                }

                return this.loggedUser;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
