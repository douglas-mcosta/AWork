import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "app/services/base.service";
import { ToastrService } from "ngx-toastr";

import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Address, CepConsulta } from "../models/address";
import { JobTitleInterested } from "../models/job-interesteds";
import { Language } from "../models/language";
import { Person } from "../models/person";
import { PersonEdit } from "../models/person-edit";
import { Phone } from "../models/phone";



@Injectable({
  providedIn: "root",
})
export class PersonService extends BaseService {

  errors: any[] = [];
  constructor(private http: HttpClient,
             private toast: ToastrService) {
    super();
  }

  getUserProfile(userId: string): Observable<Person> {

    return this.http
      .get<Person>(
        `${this.urlServiceV1}candidate`,
        this.getHeadersAuth()
      )
      .pipe(
        map(this.extractData),
        catchError(this.serviceError)
        );
  }

  updatePersonData(person: PersonEdit): Observable<Person>{
   return this.http.put(`${this.urlServiceV1}candidate/${person.id}`,person,this.getHeadersAuth())
    .pipe(
      map(this.extractData),
      catchError(this.serviceError)
    );
  }

  // Phone
  AddPersonPhone(phone: Phone): Observable<Phone>{
    return  this.http.post(`${this.urlServiceV1}candidate/phone`,phone,this.getHeadersAuth())
   .pipe(
     map(this.extractData),
     catchError(this.serviceError)
   )
  }
  updatePhonePerson(phone: Phone): Observable<Phone>{
    return  this.http.put(`${this.urlServiceV1}candidate/phone/${phone.id}`,phone,this.getHeadersAuth())
   .pipe(
     map(this.extractData),
     catchError(this.serviceError)
   )
  }
  deletePhonePerson(phoneId: string): Observable<Phone>{
    return  this.http.delete(`${this.urlServiceV1}candidate/phone/${phoneId}`,this.getHeadersAuth())
   .pipe(
     map(this.extractData),
     catchError(this.serviceError)
   )
  }
  updatePhoneFavorite(phone: Phone): Observable<Phone[]>{
    return  this.http.put(`${this.urlServiceV1}candidate/phone/change-favorite-phone/${phone.id}`,phone,this.getHeadersAuth())
   .pipe(
     map(this.extractData),
     catchError(this.serviceError)
   )
  }

  //JobTitleInterested
  addJobTitleInterested(jobTitleInterested: JobTitleInterested){
    return this.http.post(`${this.urlServiceV1}candidate/jobtitle-interested`,jobTitleInterested,this.getHeadersAuth())
    .pipe(
      map(this.extractData),
      catchError(this.serviceError)
    )
  }

  updateJobTitleInterestedFavorite(jobTitleInterested: JobTitleInterested): Observable<JobTitleInterested[]>{
    return  this.http.put(`${this.urlServiceV1}candidate/jobtitle-interested/change-favorite-jobtitle-interested/${jobTitleInterested.id}`,jobTitleInterested,this.getHeadersAuth())
   .pipe(
     map(this.extractData),
     catchError(this.serviceError)
   )
  }

  deleteJobTitleInterested(jobTitleInterestedId: string){
    return this.http.delete(`${this.urlServiceV1}candidate/jobtitle-interested/${jobTitleInterestedId}`,this.getHeadersAuth())
    .pipe(
      catchError(this.serviceError)
    )
  }

//CEP
  searchCep(cep: string): Observable<CepConsulta> {
    return this.http
        .get<CepConsulta>(`https://viacep.com.br/ws/${cep}/json/`)
        .pipe(catchError(super.serviceError))
}

//Address
addPersonAddress(personId: string, address: Address){
  return this.http.post(`${this.urlServiceV1}candidate/address/`,address,this.getHeadersAuth())
  .pipe(
    map(this.extractData),
    catchError(this.serviceError)
  )
}

updatePersonAddress(personId: string, address: Address){
  return this.http.put(`${this.urlServiceV1}candidate/address/`,address,this.getHeadersAuth())
  .pipe(
    map(this.extractData),
    catchError(this.serviceError)
  )
}

//Language

addPersonLanguage(languagePerson: Language){
  return this.http.post(`${this.urlServiceV1}candidate/language/`, languagePerson,this.getHeadersAuth())
  .pipe(
    map(this.extractData),
    catchError(this.serviceError)
  )
}
updateLanguageLevel(languagePersonId: string, languageLevel: number){
  return this.http.put(`${this.urlServiceV1}candidate/language/${languagePersonId}`, languageLevel,this.getHeadersAuth())
  .pipe(
    map(this.extractData),
    catchError(this.serviceError)
  )
}

successDefault(message: string, title:string){
  this.toast.success(message, title);
}
failDefault(fail: any) {
  let erros = fail.error?.errors;
  if(erros){
    erros.forEach((erro) => this.toast.error(erro, "Opa :("));
  }
}

}
