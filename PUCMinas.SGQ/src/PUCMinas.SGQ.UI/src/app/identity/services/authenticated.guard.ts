import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { IdentityService } from './identity.service';

@Injectable()
export class AuthenticatedGuard implements CanActivate {
    constructor(private identityService: IdentityService, private router: Router) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (!this.identityService.currentUserValue) {
            this.router.navigate(["/login"]);
            return false;
        } else {
            return true;
        }
    }
}
