import { ClientListFilterViewModel } from "./client-list-filter-view-model";
import { ClientListCollectionViewModel } from "./client-list-collection-view-model";
import { ClientListPaginationViewModel } from "./client-list-pagination-view-model";
import { ClientListDetailViewModel } from "./client-list-detail-view-model";

export class ClientListViewModel {
  ClientListFilterVM: ClientListFilterViewModel;
  ClientListCollectionsVM: ClientListCollectionViewModel[];
  ClientListPaginationVM: ClientListPaginationViewModel;
  ClientListDetailVM: ClientListDetailViewModel;

  constructor() {
    this.ClientListFilterVM = new ClientListFilterViewModel();
    this.ClientListCollectionsVM = new Array<ClientListCollectionViewModel>();
    this.ClientListPaginationVM = new ClientListPaginationViewModel();
    this.ClientListDetailVM = new ClientListDetailViewModel();
  }
}

