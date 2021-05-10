import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Dropdown } from "app/models/drop-down";
import { LocalStorageUtils } from "app/utils/local-storage";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: "root",
})
export class DropdownService extends BaseService {

  localStorageUtils = new LocalStorageUtils(); 
  constructor(private http: HttpClient) {
    super();
  }

  MaritalStatusDropdown$ = this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/marital-status`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));

  NationalityDropdown$ = this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/nationality`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));

  CountriesDropdown$ = this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/countries`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));


  ReligionDropdown$ = this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/religion`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));

  OccupationAreaDropdown$ = this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/occupation-area`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));

    languageDropdown$ = (personId: string) => this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/languages/${personId}`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));

  OccupationDropdown(occupationArea: string): Observable<Dropdown[]> {
    return this.http
    .get<Dropdown[]>(
      `${this.urlServiceV1}dropdown/occupation/${occupationArea}`,
      this.getHeadersAuth()
    )
    .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
