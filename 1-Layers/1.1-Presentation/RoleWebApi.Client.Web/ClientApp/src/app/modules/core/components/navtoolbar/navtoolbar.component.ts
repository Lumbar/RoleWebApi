import { Component, OnInit } from '@angular/core';
import { AuthenticationService, AuthUserService } from '../../../../services/index';
import { FormControl } from '@angular/forms';
import { UserModel } from '../../../../models/models/user.model';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { TooltipPosition } from '@angular/material';

@Component({
  selector: 'pol-navtoolbar',
  templateUrl: './navtoolbar.component.html',
  styleUrls: ['./navtoolbar.component.scss']
})
export class NavtoolbarComponent implements OnInit {

  public username: string;

  positionOptions: TooltipPosition[] = ['after', 'before', 'above', 'below', 'left', 'right'];
  position = new FormControl(this.positionOptions[3]);

  constructor(
    private authenticationService: AuthenticationService,
    private authUserService: AuthUserService
  ) {

    this.username = authUserService.getLoggedInUser().Username;
  }

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
  }
  
}
