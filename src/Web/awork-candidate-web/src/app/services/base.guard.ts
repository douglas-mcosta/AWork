import { ActivatedRouteSnapshot, Router } from "@angular/router";
import { LocalStorageUtils } from "app/utils/local-storage";

export abstract class BaseGuard {

  private localStorageUtils = new LocalStorageUtils();

  constructor(protected router: Router) {}

  validateClaims(routeAc: ActivatedRouteSnapshot) {
    if (!this.localStorageUtils.getTokenUser()) {
      this.router.navigate(["/account/login"], {queryParams: {returnUrl: this.router.url}}
      );
    }
    let user = this.localStorageUtils.getUser();
    let claim: any = routeAc.data[0];

    if (claim !== undefined) {
      let claim = routeAc.data[0]["claim"];

      if (claim) {
        if (!user.claims) {
          this.unauthorized();
        }
        let userClaims = user.claims.find((x) => x.type === claim.type);
        if (!userClaims) {
          this.unauthorized();
        }
        let valueClaim = userClaims.value as string;

        if (!valueClaim.includes(claim.value)) {
          this.unauthorized();
        }
      }
    }
    return true;
  }

  private unauthorized() {
    this.router.navigate(["/unauthorized"]);
  }
}
