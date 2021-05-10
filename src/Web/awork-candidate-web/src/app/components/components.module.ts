import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CardDefaultComponent } from './card-default/card-default.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CardDefaultComponent,
    NotFoundComponent,
    UnauthorizedComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CardDefaultComponent

  ]
})
export class ComponentsModule { }
