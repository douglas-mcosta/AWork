import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { DisplayMessage, GenericValidation, ValidationMessages } from 'app/utils/generic-form-validation';
import { CustomValidators } from 'ng2-validation';
import { fromEvent, merge, Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { MASKS, NgBrazilValidators } from 'ng-brazil';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[] = [];
  
  loginForm: FormGroup;
  erros: any[] = [];
  user: User = new User();;

  validationMessages: ValidationMessages;
  genericValidator: GenericValidation;
  displayMessage: DisplayMessage = {};
  public MASKS = MASKS;
  returnUrl: string;

  constructor(
    private accountService: AccountService,
    private router: Router,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private route: ActivatedRoute
  ) {

      this.validationMessages = {
        cpf: {
          required: 'o usuário(CPF) é requerido.',
          cpf: 'O CPF informado é invalido.'
        },
        password: {
            required: 'A senha é requerida.',
            rangeLength: 'A senha deve conter entre 6 e 15 caracteres.'
        }        
      }

      this.genericValidator = new GenericValidation(this.validationMessages);
      this.returnUrl = this.route.snapshot.data['returnUrl'];

  }
  ngAfterViewInit(): void {
    
    let controlBlurs: Observable<any>[] = this.formInputElements.map(
      (formControl: ElementRef) => fromEvent(formControl.nativeElement, "blur")
    );

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.processarMensagens(
        this.loginForm
      );
    });

  }

  ngOnInit(): void {

    this.loginForm = this.fb.group({
      cpf: ['', [Validators.required, NgBrazilValidators.cpf]],
      password: ['',  [Validators.required, CustomValidators.rangeLength([6,15])]]
    });
  }

  login(){
    if(this.loginForm.dirty && this.loginForm.valid){
      this.user = Object.assign({},this.loginForm.value);

      this.accountService.login(this.user)
      .subscribe(
        success => this.success(success),
        fail => this.fail(fail)
      );
    }
  }

  success(response: any){
    this.loginForm.reset();
    this.erros = [];

    this.accountService.localStorage.saveLocalDataUser(response);
    let toast = this.toastrService.success("Login realizado com sucesso","Bem vindo",{ timeOut: 500});

    if(toast){
      toast.onHidden.subscribe(() => {
        this.returnUrl
        ? this.router.navigate([this.returnUrl])
        : this.router.navigate(['/home']);
      });
    }
  }

  fail(fail: any){
    this.erros = fail.error.erros;
    this.toastrService.error("Ocorreu um erro.", "Opa :(");
  }
}
