import { Component } from '@angular/core';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html'
})
export class MenuComponent {
    navbarOpen = false;

    nav: Nav[] = [
        {
            link: '/home',
            name: 'Home',
            exact: true,
            admin: false,
            gerente: false
        },
        {
            link: '/listar-incidentes',
            name: 'Incidentes',
            exact: true,
            admin: false,
            gerente: false
        },
        {
            link: '/login',
            name: 'Login',
            exact: true,
            admin: false,
            gerente: false
        }
    ]

    toggleNavbar() {
        this.navbarOpen = !this.navbarOpen;
    }
}

interface Nav {
    link: string,
    name: string,
    exact: boolean,
    admin: boolean,
    gerente: boolean
}
