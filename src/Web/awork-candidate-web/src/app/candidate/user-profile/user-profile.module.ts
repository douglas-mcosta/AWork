import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatRippleModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatTooltipModule } from "@angular/material/tooltip";
import { RouterModule } from "@angular/router";


import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { SweetAlert2Module } from "@sweetalert2/ngx-sweetalert2";
import { NgBrazil } from "ng-brazil";
import { NgxMaskModule } from "ngx-mask";
import { NgxSpinnerModule } from "ngx-spinner";

import { ComponentsModule } from "app/components/components.module";
import { AdminLayoutModule } from "app/layouts/admin-layout/admin-layout.module";
import { PhoneTypePipe } from "app/pipes/phone.pipe";

import { CandidateResolve } from "./services/candidate.resolve";
import { AcademicEducationComponent } from "./academic-education/academic-education.component";
import { CardPhotoComponent } from "./card-photo/card-photo.component";
import { ContactComponent } from "./contact/contact.component";
import { JobtitleInterestedComponent } from "./jobtitle-interested/jobtitle-interested.component";
import { LanguageComponent } from "./language/language.component";
import { PersonDataComponent } from "./person-data/person-data.component";
import { ProfileComponent } from "./profile/profile.component";
import { UserProfileAppComponent } from "./user-profile.app.component";
import { UserProfileRoutingModule } from "./user-profile.routes";
import { UserProfileGuard } from "./services/user-profile.guard";
import { PersonService } from "../services/person.service";
import { TextMaskModule } from "angular2-text-mask";
import { AddressComponent } from './address/address.component';

@NgModule({
  declarations: [
    UserProfileAppComponent,
    ProfileComponent,
    ContactComponent,
    PersonDataComponent,
    PhoneTypePipe,
    CardPhotoComponent,
    JobtitleInterestedComponent,
    AcademicEducationComponent,
    LanguageComponent,
    AddressComponent,
  ],
  imports: [
    AdminLayoutModule,
    CommonModule,
    UserProfileRoutingModule,
    ComponentsModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    NgBrazil,
    ComponentsModule,
    TextMaskModule,
    NgxMaskModule.forRoot(),
    NgbModule,
    SweetAlert2Module,
    NgxSpinnerModule,
    
  ],
  providers: [
      PersonService, 
      CandidateResolve,
      UserProfileGuard
    ],
  exports: [],
})
export class UserProfileModule {}
