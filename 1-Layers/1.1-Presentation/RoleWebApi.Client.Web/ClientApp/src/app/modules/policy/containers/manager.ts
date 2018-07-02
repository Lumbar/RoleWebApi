import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'pol-policy-manager',
  template: `
    <div>
       <pol-navtoolbar></pol-navtoolbar>
    </div>
    <router-outlet name="policy-manager"></router-outlet>
  `,
  styles: []
})
export class PolicyManagerComponent implements OnInit {

  private _route: ActivatedRoute;
  isNew: boolean = false;

  constructor(route: ActivatedRoute) {
    this._route = route;
  }

  ngOnInit() {
  }



}
