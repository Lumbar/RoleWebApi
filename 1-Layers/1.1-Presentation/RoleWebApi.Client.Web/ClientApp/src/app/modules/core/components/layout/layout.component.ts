import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'pol-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon('arrow-up-bold-circle', sanitizer.bypassSecurityTrustResourceUrl('./../../../assets/img/arrow-up-bold-circle.svg'));
    iconRegistry.addSvgIcon('arrow-down-bold-circle', sanitizer.bypassSecurityTrustResourceUrl('./../../../assets/img/arrow-down-bold-circle.svg'));
    iconRegistry.addSvgIcon('edit', sanitizer.bypassSecurityTrustResourceUrl('../../../../assets/img/edit.svg'));
  }

  ngOnInit() {
  }

}
