import { Injectable, NgModule } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LoginService } from '../main/pages/login/login.service';
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: LoginService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let currentUser = this.authenticationService.usuarioLogadoDados;
        if (currentUser && currentUser.token) {
            request = request.clone({
                headers: request.headers.set('Authorization', `Bearer ${currentUser.token}`)
            });
        }
        return next.handle(request);
    }
}

@NgModule({
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true,
        },
    ],
})


export class TokenInterceptor { }