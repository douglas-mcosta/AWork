import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Phone } from "app/candidate/models/phone";
import { PersonService } from "app/candidate/services/person.service";
import { Dropdown } from "app/models/drop-down";
import {
  DisplayMessage,
  GenericValidation,
  ValidationMessages,
} from "app/utils/generic-form-validation";
import { StringUtils } from "app/utils/string-utils";
import { MASKS, NgBrazilValidators } from "ng-brazil";
import { ToastrService } from "ngx-toastr";
import Swal from "sweetalert2";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.css"],
})
export class ContactComponent implements OnInit {
  public MASKS = MASKS;
  phones: Phone[] = [];
  personId: string = "";
  selectedPhone: Phone = new Phone();
  phoneForm: FormGroup;
  erros: any[] = [];

  validationMessages: ValidationMessages;
  genericValidator: GenericValidation;
  displayMessage: DisplayMessage = {};

  constructor(
    private modalService: NgbModal,
    private fb: FormBuilder,
    private personService: PersonService,
    private route: ActivatedRoute,
    private toast: ToastrService
  ) {
    this.phones = this.route.snapshot.data["candidate"].phones;
    this.personId = this.route.snapshot.data["candidate"].id;
  }

  phoneTypes: Dropdown[] = [
    {
      value: 0,
      description: "Celular",
    },
    {
      value: 1,
      description: "Residencial",
    },
  ];

  ngOnInit(): void {
    this.phoneForm = this.fb.group({
      phoneType: ["", [Validators.required]],
      phoneNumber: ["", [Validators.required, NgBrazilValidators.telefone]],
    });
  }

  setPhoneFormData(phone) {
    this.phoneForm.patchValue({
      phoneType: phone.phoneType,
      phoneNumber: phone.phoneNumber,
    });
  }

  addPhone() {
    if (this.phoneForm.dirty && this.phoneForm.valid) {
      var phone: Phone = Object.assign({}, phone, this.phoneForm.value);
      phone.personId = this.personId;
      phone.phoneNumber = StringUtils.onlyNumbers(phone.phoneNumber);

      this.personService.AddPersonPhone(phone).subscribe(
        (success) => this.successAddPhone(success),
        (fail) => this.fail(fail)
      );
    }
  }

  updatePhone() {
    
    if (this.phoneForm.dirty && this.phoneForm.valid) {
      this.selectedPhone = Object.assign(
        {},
        this.selectedPhone,
        this.phoneForm.value
      );
      this.selectedPhone.phoneNumber = StringUtils.onlyNumbers(
        this.selectedPhone.phoneNumber
      );
      this.personService.updatePhonePerson(this.selectedPhone).subscribe(
        (success) => this.success(success),
        (fail) => this.fail(fail)
      );
    }
  }

  deletePhone(phoneId: string) {
    Swal.fire({
      title: "Tem certeza?",
      text: "O numero será excluído permanentemente.",
      icon: "error",
      confirmButtonColor: "#d33",
      showCancelButton: true,
      showConfirmButton: true,
    }).then((result) => {
      if (result.isConfirmed) {
        this.confirmDeletePhone(phoneId);
      }
    });
  }

  confirmDeletePhone(phoneId: string) {
  
    this.personService.deletePhonePerson(phoneId)
    .subscribe(
      (success) => this.successDeletePhone(success),
      (fail) => this.fail(fail)
    )

  }
  changeFavoritePhone(phone: Phone) {
    phone.isDefault = true;
    this.personService.updatePhoneFavorite(phone).subscribe(
      (success) => this.successFavoritePhone(success),
      (fail) => this.fail(fail)
    );
  }

  successAddPhone(phone: Phone) {
    this.toast.success("Telefone adicionado.", "Sucesso");
    this.phones.push(phone);
    this.modalService.dismissAll();
  }
  successFavoritePhone(phoneList: Phone[]) {
    this.toast.success("Telefone favorito atualizado.", "Sucesso");
    this.phones = phoneList;
  }

  successDeletePhone(phone: Phone) {
    let index = this.phones.indexOf(phone);
      this.phones.splice(index,1); 

    Swal.fire({
      title: "Deletado!",
      text: "Seu número de telefone foi excluído com sucesso",
      icon: "success",
      timer: 1500,
      showConfirmButton: false,
    });
  }

  //Auxiliares
  success(phone: Phone) {
    this.toast.success("Telefone atualizado.", "Sucesso");
    const phones = this.phones.map((item) => {
      if (item.id == phone.id) {
        return {
          ...item,
          ...phone,
        };
      } else {
        return item;
      }
    });

    this.phones = phones;
    this.modalService.dismissAll();
  }

  fail(fail: any) {
    let erros = fail.error?.errors;
    if(erros){
      erros.forEach((erro) => this.toast.error(erro.mensagem, "Opa :("));
    }
  }

  openModal(content, phone) {
    if (phone) {
      this.setPhoneFormData(phone);
      this.selectedPhone = phone;
    }else{

      this.setPhoneFormData(new Phone());
    }
    this.modalService.open(content, { size: "sm" });
  }
}
