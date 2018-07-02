import { Injectable } from "@angular/core";
import { CanActivate, Router, CanActivateChild, Route, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "./authentication.service";
import { AuthUserService } from "./auth-user.service";

@Injectable()
export class SecurityGuardService implements CanActivate, CanActivateChild {

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private authUserService: AuthUserService
  ) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let url: string = state.url;

    if (!this.authUserService.isUserLoggedIn()) {
      this.authenticationService.setRedirectUrl(url);
      this.router.navigate(["/security/login"]);
      return false;
    }

    return true;
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let url: string = state.url;

    if (this.checkLoginURL(state.url)) {
      return true;
    }

    if (!this.authUserService.isUserLoggedIn()) {
      this.authenticationService.setRedirectUrl(url);
      this.router.navigate(["/security/login"]);
      return false;
    }

    return true;
  }

  private checkLoginURL(url) {
    return ("/security/login" == url) ? true : false;
  }
}
