import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
} from "@angular/router";
import { BaseGuard } from "app/services/base.guard";

@Injectable()
export class UserProfileGuard extends BaseGuard implements CanActivate {

  constructor(protected router: Router) {super(router);}

  canActivate(routeAc: ActivatedRouteSnapshot) {
    
    return super.validateClaims(routeAc);
  }

}
