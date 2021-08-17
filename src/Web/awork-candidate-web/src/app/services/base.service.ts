import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LocalStorageUtils } from "app/utils/local-storage";
import { environment } from "environments/environment";
import { throwError } from "rxjs";

@Injectable({
  providedIn: "root",
})
export abstract class BaseService {

  protected urlServiceV1: string = environment.urlCandidateV1;
  protected urlIdentityV1: string = environment.urlIdentity;
  public localStorage = new LocalStorageUtils();
  constructor() {}

  protected getHeadersAuth() {
    return {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Authorization': `Bearer ${this.localStorage.getTokenUser()}`
      }),
    };
  }

  protected getHeaders() {
    return {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
    };
  }

  protected extractData(response: any){
    return response.data || {};
  }

  protected serviceError(response: Response | any){
    let customError: string[] = [];
        let customResponse = { error: { errors: [] }}

        if (response instanceof HttpErrorResponse) {

            if (response.statusText === "Unknown Error") {
                customError.push("Ocorreu um erro desconhecido");
                response.error.errors = customError;
            }
        }
        if (response.status === 500) {
            customError.push("Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.");
            
            // Erros do tipo 500 não possuem uma lista de erros
            // A lista de erros do HttpErrorResponse é readonly                
            customResponse.error.errors = customError;
            return throwError(customResponse);
        }

        console.error(response);
        return throwError(response);
    }

  
}
