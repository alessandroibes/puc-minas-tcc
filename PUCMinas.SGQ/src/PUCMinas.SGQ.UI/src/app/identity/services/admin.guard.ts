import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { IdentityService } from './identity.service';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private identityService: IdentityService) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.identityService.currentUserValue.loginUser.userToken.claims.some(claim => claim.type == "role" && claim.value == "gerente");
    }
}
