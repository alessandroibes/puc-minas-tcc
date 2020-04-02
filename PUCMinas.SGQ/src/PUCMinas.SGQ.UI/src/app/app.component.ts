import { Component } from '@angular/core';
import { IdentityService } from './identity/services/identity.service';
import { User } from './identity/models/user';
import { Router } from '@angular/router';

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

    if (!this.currentUser) {
      this.router.navigate(['/login']);
    }
  }
}
