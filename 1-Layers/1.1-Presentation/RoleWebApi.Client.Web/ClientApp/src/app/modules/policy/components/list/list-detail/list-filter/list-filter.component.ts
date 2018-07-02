import { Component, OnInit, Input, ElementRef, ViewChild, Output, EventEmitter, ViewChildren } from '@angular/core';
import { ClientListFilterViewModel } from '../../../../viewmodels/index';

@Component({
  selector: 'pol-policy-list-filter',
  templateUrl: './list-filter.component.html',
  styleUrls: ['./list-filter.component.scss']
})
export class PolicyListFilterComponent implements OnInit {

  @Input() ClientListFilterVM: ClientListFilterViewModel;

  @Output() keyUp = new EventEmitter<Event>();

  @ViewChild("rowFilter") rowFilter: ElementRef;
  @ViewChildren('autofocus') fc;

  constructor() { }

  ngOnInit() {

    this.rowFilter.nativeElement.querySelectorAll(".mat-form-field-infix").forEach((cellFilter) => {
      cellFilter.style.width = "100%";
    });
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.fc.first.nativeElement.focus();
    });
  }

}
