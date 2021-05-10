import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Vagas',  icon: 'dashboard', class: '' },
    { path: '/candidate/user-profile', title: 'Meu Perfil',  icon:'person', class: '' },
    { path: '/table-list', title: 'Entrevistas',  icon:'content_paste', class: '' },
    { path: '/typography', title: 'Meetups',  icon:'play_circle_outline', class: '' },
    { path: '/icons', title: 'Propostas',  icon:'library_books', class: '' },
    { path: '/notifications', title: 'Notificações',  icon:'notifications', class: '' },
    { path: '/version', title: 'Versão: 1.0.0',  icon:'unarchive', class: 'active-pro' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
