import { throwError } from 'rxjs';

export abstract class BaseService {

    constructor() { }

    protected handleError(error: any) {

        var applicationError = error.headers.get('Application-Error');

        // either application-error in header or model error in body
        if (applicationError) {
            return throwError(applicationError);
        }

        var modelStateErrors: string = '';

        if (error.error != null) {
            // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
            for (var key in error.error.errors) {
                if (error.error.errors[key][0]) modelStateErrors += error.error.errors[key][0] + '\n';
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return throwError(modelStateErrors || 'Erro no servidor, contacte um administrador.');
    }
}
