import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { AccountAppComponent } from './account.app.component';
import { AccountRoutingModule } from './account.routes';
import { AccountService } from './services/account.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';
import { AccountGuard } from './services/account.guard';


@NgModule({
  declarations: [
    AccountAppComponent,
    RegisterComponent,
    LoginComponent
    ],
  imports: [
    CommonModule,
    RouterModule,
    AccountRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    TextMaskModule,
    NgBrazil
  ],
  providers:[
    AccountService,
    AccountGuard
  ]
})
export class AccountModule { }
