import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pol-app',
  template: `<pol-viewport></pol-viewport>`,
  styles: []
})
export class AppComponent implements OnInit {

  Authenticated: boolean = false;
  subscription: Subscription;

  constructor() {

  }

  ngOnInit() {
  }

}
