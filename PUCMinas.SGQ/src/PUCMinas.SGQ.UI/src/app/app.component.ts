import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { IdentityService } from './identity/services/identity.service';
import { User } from './identity/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'PUC Minas - SGQ';
  currentUser: User;

  constructor(private router: Router,
    private identityService: IdentityService) {
    this.identityService.currentUser.subscribe(x => this.currentUser = x);
  }

  logout() {
    this.identityService.logout();
    this.router.navigate(['login']);
  }
}
