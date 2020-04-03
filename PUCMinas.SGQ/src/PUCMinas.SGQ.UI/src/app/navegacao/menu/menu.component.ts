import { Component } from '@angular/core';
import { IdentityService } from 'src/app/identity/services/identity.service';
import { User } from 'src/app/identity/models/user';
import { Router } from '@angular/router';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html'
})
export class MenuComponent {
    navbarOpen = false;
    currentUser: User;

    constructor(private router: Router,
        private identityService: IdentityService) {
        this.identityService.currentUser.subscribe(x => this.currentUser = x);
    }

    toggleNavbar() {
        this.navbarOpen = !this.navbarOpen;
    }

    logout() {
        this.identityService.logout();
        this.router.navigate(['login']);
    }
}
