import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ClientListViewModel } from '../../../viewmodels/index';
import { PolicyService } from '../../../../../services/index';
import { ClientAdapter } from '../../../../../models/adapters/client-adapter';
import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'pol-policy-list-detail',
  templateUrl: './list-detail.component.html',
  styleUrls: ['./list-detail.component.scss']
})
export class PolicyListDetailComponent implements OnInit {

  @Input() ClientListVM: ClientListViewModel;

  @Output() visualize = new EventEmitter<Event>();

  constructor(
    private policyService: PolicyService,
    private clientAdapter: ClientAdapter
  ) {
  }

  ngOnInit() {
    this.listClients();
  }

  keyUp(event: KeyboardEvent) {
    if (event.keyCode === 13) {
      this.applyFilter();
    }
  }

  applyFilter() {
    this.ClientListVM.ClientListPaginationVM.PageIndex = 0;
    this.listClients();
  }

  listClients() {

    let id = this.ClientListVM.ClientListFilterVM.Id;
    let name = this.ClientListVM.ClientListFilterVM.Name;
    let email = this.ClientListVM.ClientListFilterVM.Email;
    let role = this.ClientListVM.ClientListFilterVM.Role;
    let pageIndex = this.ClientListVM.ClientListPaginationVM.PageIndex;
    let pageSize = this.ClientListVM.ClientListPaginationVM.PageSize;

    this.ClientListVM.ClientListDetailVM.isLoadingResults = true;

    this.policyService.ListClients(id, name, email, role, pageIndex, pageSize).subscribe(clients => {

      this.ClientListVM.ClientListCollectionsVM = this.clientAdapter.ClientsToListCollectionsViewModel(clients.Items);
      this.ClientListVM.ClientListPaginationVM.TotalCount = clients.TotalCount;
      this.ClientListVM.ClientListDetailVM.isLoadingResults = false;
    });
  }

  paginateTable() {
    this.listClients();
  }
}
