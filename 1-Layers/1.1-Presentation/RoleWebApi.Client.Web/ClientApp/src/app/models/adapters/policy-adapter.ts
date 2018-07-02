import { Injectable } from "@angular/core";
import { PolicyDTO } from "../dtos/index";
import { PolicyListViewModel } from "../../modules/policy/viewmodels";

@Injectable()
export class PolicyAdapter {
  constructor() {
  }

  PolicyToPolicyListViewModel(policy: PolicyDTO): PolicyListViewModel {

    let policyListVM: PolicyListViewModel = new PolicyListViewModel();

    policyListVM.Id = policy.Id;
    policyListVM.AmountInsured = policy.AmountInsured;
    policyListVM.Email = policy.Email;
    policyListVM.InceptionDate = policy.InceptionDate.toString().substring(0, 10);

    return policyListVM;
  }

  PoliciesToPoliciesListViewModel(policies: PolicyDTO[]): PolicyListViewModel[] {

    let _self = this;
    let policiesListVM: PolicyListViewModel[] = new Array<PolicyListViewModel>();

    policies.forEach(function (policy) {
      policiesListVM.push(_self.PolicyToPolicyListViewModel(policy));
    });

    return policiesListVM;
  }
}
