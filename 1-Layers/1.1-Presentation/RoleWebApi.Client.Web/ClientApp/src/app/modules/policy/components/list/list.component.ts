import { Component, OnInit, ViewChild } from '@angular/core';
import { ClientListViewModel, ClientListCollectionViewModel, PolicyListViewModel } from '../../viewmodels/index';
import { StorageService, PolicyService } from '../../../../services/index';
import { UserModel } from '../../../../models/models/user.model';
import { PolicyListDetailComponent } from './list-detail/list-detail.component';
import { PolicyAdapter } from '../../../../models/adapters/policy-adapter';
import { MatDialog } from '@angular/material';
import { PolicyListDialogComponent } from '../shared/policy-list-dialog/policy-list-dialog.component';

@Component({
  selector: 'pol-client-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ClientListComponent implements OnInit {

  public ClientListVM: ClientListViewModel;

  public policyListDialog: MatDialog;

  constructor(
    private policyService: PolicyService,
    private policyAdapter: PolicyAdapter,
    policyListDialog: MatDialog
  ) {
    this.policyListDialog = policyListDialog;
  }

  ngOnInit() {
    this.ClientListVM = new ClientListViewModel();

    this.ClientListVM.ClientListPaginationVM.PageIndex = 0;
    this.ClientListVM.ClientListPaginationVM.PageSize = 5;
    this.ClientListVM.ClientListPaginationVM.TotalCount = 0;
  }

  visualize(ClientListCollectionVM: ClientListCollectionViewModel) {

    this.policyService.ListPoliciesByClientId(ClientListCollectionVM.Id).subscribe(policies => {

      let policiesListVM = this.policyAdapter.PoliciesToPoliciesListViewModel(policies);

      this.openPolicyListDialog(policiesListVM);
    });
    
  }

  openPolicyListDialog(policiesListVM: PolicyListViewModel[]): void {
    let policyListDialog = this.policyListDialog.open(PolicyListDialogComponent, {
      disableClose: true,
      width: '950px',
      height: '625px',
      data: {
        policiesListVM: policiesListVM
      }
    });
  }
}
