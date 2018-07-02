import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SecurityService } from './security.service';
import { StorageService } from './storage.service';
import { AuthUserService } from './auth-user.service';
import { UserModel } from '../models/models/user.model';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {

  private redirectUrl: string = '/';

  constructor(
    private router: Router,
    private securityService: SecurityService,
    private storageService: StorageService,
    private authUserService: AuthUserService
  ) {
  }

  login(username: string, password: string): Observable<string> {

    return new Observable<string>(observer => {
      this.securityService.ConnectToken(username, password).subscribe(token => {
        if (token) {
          this.authUserService.setUserToken(token);

          let loggedInUser = new UserModel();
          loggedInUser.Username = username;
          this.authUserService.setLoggedInUser(loggedInUser);

          observer.next("");

        } else {
          observer.next("Invalid username or password");
        }
      }, error => {
        observer.next(error);
      });
    });
  }

  getRedirectUrl(): string {
    return this.redirectUrl;
  }

  setRedirectUrl(url: string): void {
    this.redirectUrl = url;
  }

  logout(): void {
    this.authUserService.LogOutUser();
    this.router.navigate(["/security/login"]);
  }
}
