import { Component, ElementRef, OnInit, ViewChildren } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormControlName,
  FormGroup,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import {
  DisplayMessage,
  GenericValidation,
  ValidationMessages,
} from "app/utils/generic-form-validation";
import { CustomValidators } from "ng2-validation";
import { fromEvent, merge, Observable } from "rxjs";
import { User } from "../models/user";
import { AccountService } from "../services/account.service";
import { ToastrService } from "ngx-toastr";
import { MASKS, NgBrazilValidators } from "ng-brazil";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html"
})
export class RegisterComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  registerForm: FormGroup;
  erros: any[] = [];
  user: any;

  validationMessages: ValidationMessages;
  genericValidator: GenericValidation;
  displayMessage: DisplayMessage = {};
  public MASKS = MASKS;

  constructor(
    private accountService: AccountService,
    private router: Router,
    private fb: FormBuilder,
    private toastrService: ToastrService
  ) {
    this.validationMessages = {
      cpf: {
        required: "O CPF é obrigatório.",
        cpf: "O CPF informado é invalido.",
      },
      firstName: {
        required: "O Primeiro Nome é obrigatório.",
        rangeLength: "O Primeiro nome deve ter ente 3 e 100",
      },
      lastName: {
        required: "O Primeiro Nome é obrigatório.",
        rangeLength: "O Primeiro nome deve ter ente 3 e 200",
      },
      birthDate: {
        required: "A Data de Nascimento é obrigatória.",
      },
      gender: {
        required: "O Gênero é obrigatório.",
      },
      email: {
        required: "o E-mail é obrigatório.",
      },
      password: {
        required: "A senha é obrigatória.",
        rangeLength: "A senha deve conter entre 6 e 15 caracteres.",
      },
      confirmPassword: {
        required: "A confirmação de senha é obrigatória.",
        rangeLength: "A senha deve conter entre 6 e 15 caracteres.",
        equalTo: "As senhas não correspondem.",
      },
    };

    this.genericValidator = new GenericValidation(this.validationMessages);
  }
  ngAfterViewInit(): void {
    let controlBlurs: Observable<any>[] = this.formInputElements.map(
      (formControl: ElementRef) => fromEvent(formControl.nativeElement, "blur")
    );

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.processarMensagens(
        this.registerForm
      );
    });
  }

  ngOnInit(): void {
    let pass = new FormControl("", [
      Validators.required,
      CustomValidators.rangeLength([6, 15]),
    ]);
    let confirmPass = new FormControl("", [
      Validators.required,
      CustomValidators.rangeLength([6, 15]),
      CustomValidators.equalTo(pass),
    ]);

    this.registerForm = this.fb.group({
      cpf: ["", [Validators.required, NgBrazilValidators.cpf]],
      email: ["", [Validators.required, Validators.email]],
      password: pass,
      confirmPassword: confirmPass,
      firstName: ["", [Validators.required, CustomValidators.rangeLength([3,100])]],
      lastName: ["", [Validators.required, CustomValidators.rangeLength([3,200])]],
      birthDate: ["", [Validators.required]],
      gender: ["", [Validators.required]],
    });
  }

  registerAccount() {
    if (this.registerForm.dirty && this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);

      let userPerson: User = {
        id: this.user.id,
        email: this.user.email,
        password: this.user.password,
        confirmPassword: this.user.confirmPassword,
        Person: {
          cpf: this.user.cpf,
          birthDate: this.user.birthDate,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          gender: this.user.gender

        }
      }
      this.accountService.registerUser(userPerson).subscribe(
        (success) => this.success(success),
        (fail) => this.fail(fail)
      );
    }
  }

  success(response: any) {
    this.registerForm.reset();
    this.erros = [];

    this.accountService.localStorage.saveLocalDataUser(response);
    let toast = this.toastrService.success(
      "Registro realizado com sucesso",
      "Bem vindo"
    );

    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(["home"]);
      });
    }
  }

  fail(fail: any) {
    this.erros = fail.error.erros;
    this.toastrService.error("Ocorreu um erro.", "Opa :(");
  }
}
