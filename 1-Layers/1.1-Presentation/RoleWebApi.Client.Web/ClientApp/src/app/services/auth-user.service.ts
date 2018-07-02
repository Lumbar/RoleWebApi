import { Injectable } from '@angular/core';
import { UserModel } from '../models/models/user.model';
import { StorageService } from './storage.service';

@Injectable()
export class AuthUserService {

  constructor(private storageService: StorageService) {
  }
  
  isUserLoggedIn(): boolean {
    return (this.storageService.retrieve("user")) ? true : false;
  }

  isSuperAdmin(): boolean {
    return this.storageService.retrieve("user") && this.storageService.retrieve("user").isSuperAdmin;
  }

  getLoggedInUser(): UserModel {
    return this.storageService.retrieve("user");
  }

  setLoggedInUser(userModel: UserModel) {
    this.storageService.store('user', userModel);
  }

  getUserToken(): string {
    return this.storageService.retrieve("usertoken");
  }

  setUserToken(token: string) {
    this.storageService.store('usertoken', token);
  }

  LogOutUser() {
    this.storageService.remove('user');
    this.storageService.remove("usertoken");
  }
}
