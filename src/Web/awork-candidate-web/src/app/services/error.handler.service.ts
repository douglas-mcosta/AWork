import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { LocalStorageUtils } from "app/utils/local-storage";
import { ToastrService } from "ngx-toastr";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private localStoreUtils: LocalStorageUtils = new LocalStorageUtils();

  constructor(private router: Router, private toast: ToastrService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {


    return next.handle(req).pipe(catchError((error) => {

        if(error instanceof HttpErrorResponse){

            if(error.status === 401){
                this.localStoreUtils.clearLocalDataUser();
                let toast = this.toast.warning("Sessão expirada","Atenção!",{timeOut: 1000});
                if(toast){
                    toast.onHidden
                    .subscribe(()=> { this.router.navigate(['/account/login'])})
                }
            }

            if(error.status === 403){
                this.localStoreUtils.clearLocalDataUser();
                let toast = this.toast.warning("Acesso negado!","Atenção!",{timeOut: 1000});
                if(toast){
                    toast.onHidden
                    .subscribe(()=> this.router.navigate(['/unauthorized']))
                }
            }
        }

        return throwError(error);
    }));
  }
}
