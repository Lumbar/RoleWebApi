import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'pol-viewport',
  template: `<div class="viewport"><pol-layout><router-outlet></router-outlet></pol-layout><div>`,
  styles: [`
    .viewport {
      min-width:800px;
    }`
  ]
})
export class ViewportComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
