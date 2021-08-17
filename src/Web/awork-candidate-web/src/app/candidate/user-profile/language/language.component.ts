import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal, NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import { Language } from 'app/candidate/models/language';
import { PersonService } from 'app/candidate/services/person.service';
import { Dropdown } from 'app/models/drop-down';
import { DropdownService } from 'app/services/dropdown.service';
import { CurrencyUtils } from 'app/utils/currency-utils';
import { LocalStorageUtils } from 'app/utils/local-storage';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {
  personId: string = "";
  languages: Language[];
  language: Language = new Language();
  languagePersonForm: FormGroup;
  selected = 0;
  hovered = 0;
  readonly = false;
  languageDropdown$: Observable<Dropdown[]>;

  constructor(private route: ActivatedRoute,
    private config: NgbRatingConfig,
    private personService: PersonService,
    private modalService: NgbModal,
    private dropdown: DropdownService,
    private fb: FormBuilder) {

    this.config.max = 5;
}


  ngOnInit(): void {
    console.log(this.route.snapshot.data['candidate'].languages)
    this.personId = this.route.snapshot.data['candidate'].id;
    this.languageDropdown$ = this.dropdown.languageDropdown$(this.personId);
    this.languages = this.route.snapshot.data['candidate'].languages;

        this.languagePersonForm = this.fb.group({
          languageId: ["", Validators.required],
          languageLevel: ["", Validators.required]
        })  
  }

  ratingLanguageLevel(languagePerson: Language){

    console.log(languagePerson)
    if(!languagePerson) return;
    let languageLevel = CurrencyUtils.StringToInt(languagePerson.fluencyLevel);
    console.log(languageLevel);
    this.personService.updateLanguageLevel(languagePerson.id, languagePerson.fluencyLevel)
    .subscribe(
      () => this.personService.successDefault("Nível de fluência atualizado.","Sucesso"),
      (fail) => this.personService.failDefault(fail)
    );
  }

  addLanguagePerson(){
    this.language = Object.assign({},this.language,this.languagePersonForm.value);
    this.language.candidateId = this.personId;
    console.log(this.language)
    this.personService.addPersonLanguage(this.language)
    .subscribe(
      (success) => this.successAddLanguage(success),
      (fail) => this.personService.failDefault(fail)
    );
  }
  successAddLanguage(languagePerson: Language){
    this.personService.successDefault('Idioma adicionado.','Sucesso');
    this.languages.push(languagePerson);
    this.language = new Language();
   this.modalService.dismissAll();
   this.languageDropdown$ = this.dropdown.languageDropdown$(this.personId);
  }

  openModal(context){
    this.modalService.open(context);
  }
}
