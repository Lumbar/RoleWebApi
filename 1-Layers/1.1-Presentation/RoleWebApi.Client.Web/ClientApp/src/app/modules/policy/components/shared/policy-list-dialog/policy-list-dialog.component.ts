import { Component, OnInit, ViewChild, ElementRef, HostListener, Inject } from '@angular/core';
import { MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { Overlay } from '@angular/cdk/overlay';
import { PolicyListViewModel } from '../../../viewmodels/index';

@Component({
  selector: 'pol-policy-list-dialog',
  templateUrl: './policy-list-dialog.component.html',
  styleUrls: ['./policy-list-dialog.component.scss']
})

export class PolicyListDialogComponent implements OnInit {

  public policyListDialogRef: MatDialogRef<PolicyListDialogComponent>;
  public PolicyListVM: PolicyListViewModel;

  @ViewChild("content") content: ElementRef;
  @ViewChild("container") container: ElementRef;

  constructor(
    policyListDialogRef: MatDialogRef<PolicyListDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.policyListDialogRef = policyListDialogRef;
  }

  ngOnInit() {

    this.PolicyListVM = this.data.policiesListVM;
    this.content.nativeElement.style.maxHeight = (480 - 76) + "px";
  }

  @HostListener('document:keyup', ['$event'])
  onKeyup(event: KeyboardEvent) {
    if (event.keyCode == 27) {
      this.policyListDialogRef.close();
    }
  }

  CancelViewList() {
    this.policyListDialogRef.close();
  }
}
