import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { Person } from "app/candidate/models/person";
import { PersonService } from "app/candidate/services/person.service";
import { LocalStorageUtils } from "app/utils/local-storage";
import { Observable } from "rxjs";


@Injectable()
export class CandidateResolve implements Resolve<Person>{

    localStorageUtils = new LocalStorageUtils();
    constructor(private personService: PersonService
       ){}

    resolve(): Observable<Person> {
          return this.personService.getUserProfile(this.localStorageUtils.getUserId());
    }

    
}