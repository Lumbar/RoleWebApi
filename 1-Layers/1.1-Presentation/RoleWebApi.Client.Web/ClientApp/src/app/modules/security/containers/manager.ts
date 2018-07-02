import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'pol-security-manager',
  template: `    
    <router-outlet name="security-manager"></router-outlet>
  `,
  styles: []
})
export class SecurityManagerComponent implements OnInit {

  private _route: ActivatedRoute;
  isNew: boolean = false;

  constructor(route: ActivatedRoute) {
    this._route = route;
  }

  ngOnInit() {
  }



}
