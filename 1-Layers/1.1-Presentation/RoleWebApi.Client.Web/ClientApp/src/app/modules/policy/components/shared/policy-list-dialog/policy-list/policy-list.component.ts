import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { PolicyListViewModel } from '../../../../viewmodels/index';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'pol-policy-list',
  templateUrl: './policy-list.component.html',
  styleUrls: ['./policy-list.component.scss']
})

export class PolicyListComponent implements OnInit {

  @Input() PolicyListVM: PolicyListViewModel[];
  
  [x: string]: any;
  @Input() Height: number;
  @Input() Width: number;

  @ViewChild("card") card: ElementRef;
  @ViewChild("container") container: ElementRef;

  dataSource: MatTableDataSource<PolicyListViewModel>;

  public displayedColumns = ['id', 'amountInsured', 'email', 'inceptionDate'];

  constructor(

  ) {
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource<PolicyListViewModel>(this.PolicyListVM);
  }

  ngAfterViewInit() {
    this.assignHeight();
  }

  assignHeight() {
    this.container.nativeElement.style.width = (this.Width - 76) + "px";
  }
}
