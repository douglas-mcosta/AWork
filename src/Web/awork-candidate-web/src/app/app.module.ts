import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';

import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { NgxSpinnerModule } from "ngx-spinner";
import { ErrorInterceptor } from './services/error.handler.service';

export const httpInterceptorProviders = [
  {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
]

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    AppRoutingModule,
    ToastrModule.forRoot(), // ToastrModule added
    NgxMaskModule.forRoot(),
    NgbModule,
    SweetAlert2Module.forRoot(),
    NgxSpinnerModule
   
  ],
  declarations: [
    AppComponent,
  ],
  providers: [
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
