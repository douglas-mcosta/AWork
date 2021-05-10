import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'app/services/base.service';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseService {

  constructor(private http: HttpClient) { 
    super();
  }

  registerUser(user: User): Observable<User>{
    let response = this.http.post(this.urlServiceV1+'Auth/Register',user, this.getHeaders())
    .pipe(
      map(this.extractData),
      catchError(this.serviceError)
    );

    return response;
  }

  login(user: User): Observable<User>{
    let response = this.http.post(this.urlServiceV1+'Auth/Login',user, this.getHeaders())
    .pipe(
      map(this.extractData),
      catchError(this.serviceError)
    );

    return response;
  }

}
