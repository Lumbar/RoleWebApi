import { Injectable } from "@angular/core";
import { ClientDTO } from "../dtos/index";
import { ClientListCollectionViewModel } from "../../modules/policy/viewmodels";

@Injectable()
export class ClientAdapter {
  constructor() {
  }

  ClientToListCollectionViewModel(client: ClientDTO): ClientListCollectionViewModel {

    let clientListCollectionVM: ClientListCollectionViewModel = new ClientListCollectionViewModel();

    clientListCollectionVM.Id = client.Id;
    clientListCollectionVM.Name = client.Name;
    clientListCollectionVM.Email = client.Email;
    clientListCollectionVM.Role = client.Role;

    return clientListCollectionVM;
  }

  ClientsToListCollectionsViewModel(clients: ClientDTO[]): ClientListCollectionViewModel[] {

    let _self = this;
    let clientListCollectionsVM: ClientListCollectionViewModel[] = new Array<ClientListCollectionViewModel>();

    clients.forEach(function (client) {
      clientListCollectionsVM.push(_self.ClientToListCollectionViewModel(client));
    });

    return clientListCollectionsVM;
  }
}
