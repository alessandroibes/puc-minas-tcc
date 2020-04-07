import { throwError } from 'rxjs';

export abstract class BaseService {

    constructor() { }

    protected handleError(error: any) {

        var applicationError = error.headers.get('Application-Error');

        // Teste
        switch (error.status) {
            case 401:
                console.log('401 - Usuário Não autorizado.')
                break;
            case 403:
                console.log('403 - Acesso proibido.')
                break;
            case 404:
                console.log('404 - Página não encontrada.')
                break;
        }

        // either application-error in header or model error in body
        if (applicationError) {
            return throwError(applicationError);
        }

        var modelStateErrors: string = '';

        if (error.error != null) {
            // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
            for (var key in error.error.errors) {
                if (error.error.errors[key]) modelStateErrors += error.error.errors[key] + '\n';
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
        return throwError(modelStateErrors || 'Erro no servidor, contacte um administrador.');
    }
}
