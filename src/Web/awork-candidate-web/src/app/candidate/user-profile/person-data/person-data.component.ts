import {
  Component,
  EventEmitter,
  OnInit,
  Output,
} from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { PersonEdit } from "app/candidate/models/person-edit";
import { Dropdown } from "app/models/drop-down";
import { DropdownService } from "app/services/dropdown.service";
import { LocalStorageUtils } from "app/utils/local-storage";
import { MASKS } from "ng-brazil";
import { CustomValidators } from "ng2-validation";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { merge, Observable } from "rxjs";
import {
  debounceTime,
  distinctUntilChanged,
  map,
} from "rxjs/operators";
import { Person } from "../../models/person";
import { PersonService } from "../../services/person.service";

@Component({
  selector: "app-person-data",
  templateUrl: "./person-data.component.html",
  styleUrls: ["./person-data.component.css"],
})
export class PersonDataComponent implements OnInit {
  @Output()
  personEvent: EventEmitter<Person> = new EventEmitter();

  public MASKS = MASKS;
  private localStorageUtils: LocalStorageUtils = new LocalStorageUtils();
  errors: any[] = [];
  selectedNationality = new Dropdown();

  myProfileForm: FormGroup;
  personProfile: Person;
  personData: PersonEdit = new PersonEdit();
  isSaving: boolean = false;
  personId: string = "";
  maritalStatus: Observable<Dropdown[]>;
  nationality: Observable<Dropdown[]>;
  religion: Observable<Dropdown[]>;
  jobTitleInteresteds: any;
  nacionalidade: Dropdown[] = [];
  genders: Dropdown[] = [
    {
      value: 0,
      description: "Feminino",
    },
    {
      value: 1,
      description: "Masculino",
    },
  ];
  constructor(
    private personService: PersonService,
    private fb: FormBuilder,
    private dropdownService: DropdownService,
    private route: ActivatedRoute,
    private toast: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.personProfile = this.route.snapshot.data["candidate"];
    this.personId = this.route.snapshot.data["candidate"].id;
    this.myProfileForm = fb.group({});
  }

  ngOnInit() {
    this.spinner.show();

    this.maritalStatus = this.dropdownService.MaritalStatusDropdown$;
    this.nationality = this.dropdownService.NationalityDropdown$;
    this.religion = this.dropdownService.ReligionDropdown$;

    this.nationality
    .subscribe(s => {
      this.nacionalidade = s;
      console.log(this.personProfile)
      s.forEach(dropdown => {
        if(dropdown.value == this.personProfile.nationalityId) 
        this.selectedNationality = dropdown 
        // console.log(this.selectedNationality)
      })
    })

    this.myProfileForm = this.fb.group({
      id: [""],
      firstName: ["",[Validators.required, CustomValidators.rangeLength([3, 100])]],
      cpf: { value: null, disabled: true },
      email: { value: null, disabled: true },
      lastName: ["",[Validators.required, CustomValidators.rangeLength([3, 100])]],
      maritalStatusId: [""],
      gender: [""],
      nationalityId: [""],
      religionId: [""],
    });
    this.setValue(this.personProfile);
    this.spinner.hide();
  }

  setValue(person: Person) {

    this.myProfileForm.patchValue({
      id: person.id,
      firstName: person.firstName,
      lastName: person.lastName,
      maritalStatusId: person.maritalStatusId,
      cpf: person.cpf,
      gender: person.gender,
      nationalityId: this.selectedNationality,
      religionId: person.religionId,
      email: this.localStorageUtils.getEmailUser(),
    });
  }

  updateCandidate() {
    this.isSaving = true;
    if (this.myProfileForm.dirty && this.myProfileForm.valid) {
      this.personData = Object.assign(
        {},
        this.personData,
        this.myProfileForm.value
      );
      this.personData.nationalityId = this.selectedNationality.value.toString();
     console.log(this.personProfile.nationalityId);
     console.log(this.selectedNationality.value.toString());

      this.personService.updatePersonData(this.personData).subscribe(
        (success) => this.success(success),
        (fail) => this.fail(fail)
      );
    }
    setTimeout(() => {
      this.isSaving = false;
    }, 2000);
  }
  success(person: any) {
    if (person) {
      this.toast.success("Dados Pessoais atualizado.", "Sucesso");
      this.personProfile = person;
      this.emitterPersonProfile();
    }
  }

  fail(fail: any) {
    this.errors = fail.error?.errors;
    this.errors.forEach((erro) => this.toast.error(erro.mensagem, "Opa :("));
  }

  emitterPersonProfile() {
    this.personEvent.emit(this.personProfile);
  }

  formatter(nacionalidade: Dropdown) {
    return nacionalidade.description;
  } 
  resultFormatter = (nacionalidade: Dropdown) => nacionalidade.value;

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(200),
      distinctUntilChanged(),
      map((term) =>
        this.nacionalidade
          .filter((nacionalidade) => new RegExp(term, "mi").test(nacionalidade.description))
          .slice(0, 10)
      )
    );
}
