import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IdentityService } from './identity.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private identityService: IdentityService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let currentUser = this.identityService.currentUserValue;
        if (currentUser && currentUser.loginUser && currentUser.loginUser.acessToken) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.loginUser.acessToken}`
                }
            });
        }

        return next.handle(request);
    }
}
