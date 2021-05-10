import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CandidateAppComponent } from './candidate.app.component';
import { CandidateRoutingModule } from './candidate.routes';
import { AdminLayoutModule } from 'app/layouts/admin-layout/admin-layout.module';
@NgModule({
  declarations: [
    CandidateAppComponent
 
  ],
  imports: [
    AdminLayoutModule,
    CommonModule,
    CandidateRoutingModule

  ],
  providers: [
 
]
})
export class CandidateModule { }
