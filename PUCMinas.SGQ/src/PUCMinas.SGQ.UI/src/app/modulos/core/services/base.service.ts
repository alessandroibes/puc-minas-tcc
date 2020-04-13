import { throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

export abstract class BaseService {

    protected extractData(response: any) {
        return response.data || {};
    }

    protected handleError(response: Response | any) {
        let customError: string[] = [];

        if (response instanceof HttpErrorResponse) {
            if (response.statusText === "Unknown error") {
                customError.push('Ocorreu um erro desconhecido.');
                response.error.errors = customError;
            } else if ("Bad Request") {
                customError.push('Requisição mal formada.');
                response.error.errors = customError;
            } else if ('Not Found') {
                customError.push('Recurso não encontrado.');
                response.error.errors = customError;
            }
        }

        console.log(response);
        return throwError(response);
    }
}
