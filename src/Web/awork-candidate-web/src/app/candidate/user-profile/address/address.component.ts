import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Address, CepConsulta } from 'app/candidate/models/address';
import { Dropdown } from 'app/models/drop-down';
import { DropdownService } from 'app/services/dropdown.service';
import { DisplayMessage, GenericValidation, ValidationMessages } from 'app/utils/generic-form-validation';
import { NgBrazilValidators } from 'ng-brazil';
import { CustomValidators } from 'ng2-validation';
import { utilsBr } from 'js-brasil';
import { StringUtils } from 'app/utils/string-utils';
import { PersonService } from 'app/candidate/services/person.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { environment } from 'environments/environment';


@Component({
  selector: 'app-address',
  templateUrl: './address.component.html'
})
export class AddressComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  personId: string;
  address: Address;
  addressForm: FormGroup;
  countries: Observable<Dropdown[]>
  validationMessages: ValidationMessages;
  genericValidator: GenericValidation;
  displayMessage: DisplayMessage = {};
  MASKS = utilsBr.MASKS;
  addressMap: any;


  constructor(private route: ActivatedRoute,
              private modalService: NgbModal,
              private fb: FormBuilder,
              private dropdownService: DropdownService,
              private personService: PersonService,
              private toast: ToastrService,
              private sanitizer: DomSanitizer) { 

    this.address = route.snapshot.data['candidate'].address !==  null ? route.snapshot.data['candidate'].address  : new Address() ;
    this.personId = route.snapshot.data['candidate'].id;
    this.countries = this.dropdownService.CountriesDropdown$;
    this.addressMap = this.sanitizer.bypassSecurityTrustResourceUrl(environment.googleMapAddress + this.CompletedAddress());

    this.validationMessages = {
      zipCode: {
        required: "Informe o CEP.",
        cep: "CEP invalido."
      },
      street: {
        required: "Informe o logradouro",
        rangeLength: "O Logradouro deve conter entre 2 e 100 caracteres."
      },
      number: {
        required: "Informe o número.",
        rangeLength: "O número deve conter entre 1 e 15 caracteres."
      },
      complement: {
        rangeLength: "O complemento deve conter entre 2 e 200 caracteres."
      },
      district: {
        required: "Informe o bairro.",
        rangeLength: "O bairro deve conter entre 2 e 200 caracteres."
      }, 
      city: {
        required: "Informe a cidade.",
        rangeLength: "A cidade deve conter entre 2 e 200 caracteres."
      },
      state: {
        required: "Informe o estado.",
        rangeLength: "O estado deve conter entre 2 e 70 caracteres."
      },
      countryId: {
        required: "Informe o país.",
      },
    }
    
    this.genericValidator = new GenericValidation(this.validationMessages);

  }

  ngOnInit(): void {

    this.addressForm = this.fb.group({
      zipCode: ["", [Validators.required, NgBrazilValidators.cep]],
      street: ["", [Validators.required, CustomValidators.rangeLength([2,100])]],
      number: ["", [Validators.required, CustomValidators.rangeLength([1,15])]],
      complement: ["", [CustomValidators.rangeLength([2,200])]],
      district: ["", [Validators.required, CustomValidators.rangeLength([2,100])]],
      city: ["", [Validators.required, CustomValidators.rangeLength([2,100])]],
      state: ["", [Validators.required, CustomValidators.rangeLength([2,70])]],
      countryId: ["", [Validators.required]],
    });

    this.setAddressForm();
    this.disableFieldsAddress();

  }

  validateForm(): void {

      this.displayMessage = this.genericValidator.processarMensagens(this.addressForm);
  }

  setAddressForm(){
    this.addressForm.patchValue({
      zipCode: this.address.zipCode,
      street: this.address.street,
      number: this.address.number,
      complement: this.address.complement,
      district: this.address.district,
      city: this.address.city,
      state: this.address.state,
      countryId: this.address.countryId
    }
      );
  }

  public CompletedAddress(): string {
    return this.address.street + ", " + this.address.number + " - " + this.address.district + ", " + this.address.city + " - " + this.address.state;
  }

  SearchCep(cep: string) {

    cep = StringUtils.onlyNumbers(cep);
    if (cep.length < 8) return;

    this.personService.searchCep(cep)
      .subscribe(
        cepRetorno => this.CepReturn(cepRetorno),
        erro => this.errors.push(erro));
  }

  CepReturn(cepConsulta: CepConsulta) {
    this.addressForm.controls.number.reset();
    this.addressForm.controls.complement.reset();
    this.addressForm.patchValue({
      street: cepConsulta.logradouro,
      district: cepConsulta.bairro,
      zipCode: cepConsulta.cep,
      city: cepConsulta.localidade,
      state: cepConsulta.uf
    });

    if(cepConsulta.logradouro)
    this.addressForm.controls.street.disable();
    else
    this.addressForm.controls.street.enable();

    if(cepConsulta.bairro)
    this.addressForm.controls.district.disable();
    else
    this.addressForm.controls.district.enable();

    if(cepConsulta.localidade)
    this.addressForm.controls.city.disable();
    else
    this.addressForm.controls.city.enable();

    if(cepConsulta.uf)
    this.addressForm.controls.state.disable();
    else
    this.addressForm.controls.state.enable();   
    
  }

  submitAddress(){

    if(!this.address.id){
      this.AddAddress();
    }else{
      this.editAddress();
    }

  }
  AddAddress(){

    if(!this.addressForm.dirty && !this.addressForm.valid) return;
    var address = Object.assign({}, address, this.addressForm.getRawValue());
    address.zipCode = StringUtils.onlyNumbers(address.zipCode);
    this.personService.addPersonAddress(this.personId,address)
    .subscribe(
      (success) => this.successAdd(success),
      (fail) => this.fail(fail)
    )
  }

  editAddress(){
    if(!this.addressForm.dirty && !this.addressForm.valid) return;
    var address= Object.assign({}, address, this.addressForm.getRawValue());
    address.zipCode = StringUtils.onlyNumbers(address.zipCode);
    address.id = this.address.id;
    this.personService.updatePersonAddress(this.personId,address)
    .subscribe(
      (success) => this.successEdit(success),
      (fail) => this.fail(fail)
    )
  }

  successAdd(address: Address){
    this.toast.success("Endereço Adicionado.","Sucesso");
    this.address = address;
    this.addressMap = this.sanitizer.bypassSecurityTrustResourceUrl(environment.googleMapAddress + this.CompletedAddress());
    this.modalService.dismissAll();
  }

  successEdit(address: Address){
    this.toast.success("Endereço atualizado.","Sucesso");
    this.address = address;
    this.addressMap = this.sanitizer.bypassSecurityTrustResourceUrl(environment.googleMapAddress + this.CompletedAddress());
    this.modalService.dismissAll();
  }

  openModalAdd(content) {
 
    this.addressForm.patchValue({countryId: 'c88ac7a5-2de6-4b2e-a9b2-dc4d3f654dfa'})
    this.modalService.open(content);
  }

  openModalEdit(content) {
 
    this.modalService.open(content);
  }
  
  disableFieldsAddress(){
    this.addressForm.controls.street.disable();
    this.addressForm.controls.district.disable();
    this.addressForm.controls.city.disable();
    this.addressForm.controls.state.disable();
  }
  fail(fail: any) {
    let erros = fail.error?.errors;
    if(erros){
      erros.forEach((erro) => this.toast.error(erro.mensagem, "Opa :("));
    }
  }

}
