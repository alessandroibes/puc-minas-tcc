import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { IdentityService } from './identity.service';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private identityService: IdentityService) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let can: boolean = false;
        switch (state.url.split('/')[1]) {
            case "listar-rnc":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        (claim.value == "gerente"
                            || claim.value == "engenheiro"));
                break;
            case "criar-rnc":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        claim.value == "gerente");
                break;
            case "atualizar-rnc":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        (claim.value == "gerente"
                            || claim.value == "engenheiro"));
                break;
            case "listar-workflow-definicao":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        (claim.value == "operador"
                            || claim.value == "gerente"
                            || claim.value == "engenheiro"));
                break;
            case "criar-workflow-definicao":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        claim.value == "engenheiro");
                break;
            case "atualizar-workflow-definicao":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        claim.value == "engenheiro");
                break;
            case "listar-workflow-andamento":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        (claim.value == "operador"
                            || claim.value == "gerente"
                            || claim.value == "engenheiro"));
                break;
            case "run-workflow":
                can = this.identityService.currentUserValue.loginUser.userToken.claims.some(
                    claim => claim.type == "role" &&
                        claim.value == "operador");
                break;
        }
        return can;
    }
}
