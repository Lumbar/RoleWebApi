import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PolicyManagerComponent } from './containers/manager';
import { MaterialModule } from '../../shared/material';
import { NetworkManager } from '../../agents/networkmanager';
import { PolicyService, FormService } from '../../services';
import { SecurityAgent } from '../../agents/security/security-agent';
import { CommonSharedModule } from '../../shared/common-shared/common-shared.module';
import { PolicyAdapter } from '../../models/adapters/policy-adapter';
import { PolicyAgent } from '../../agents/policy/policy-agent';
import { ClientListComponent } from './components/list/list.component';
import { PolicyListDetailComponent } from './components/list/list-detail/list-detail.component';
import { PolicyListFilterComponent } from './components/list/list-detail/list-filter/list-filter.component';
import { PolicyListCollectionComponent } from './components/list/list-detail';
import { ClientAdapter } from '../../models/adapters/client-adapter';
import { PolicyListComponent } from './components/shared/policy-list-dialog/policy-list/policy-list.component';
import { PolicyListDialogComponent } from './components/shared/policy-list-dialog/policy-list-dialog.component';

const routes: Routes = [
  { path: '', component: PolicyManagerComponent },
  {
    path: 'list', component: PolicyManagerComponent,
    children: [
      {
        outlet: 'policy-manager',
        path: '',
        component: ClientListComponent
      }
    ]
  },
];


@NgModule({
  imports: [
    MaterialModule,
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    CommonSharedModule
  ],
  providers: [
    NetworkManager,
    PolicyService,
    PolicyAdapter,
    ClientAdapter,
    PolicyAgent,
    SecurityAgent,
    FormService
  ],
  declarations: [
    PolicyManagerComponent,
    ClientListComponent,
    PolicyListDetailComponent,
    PolicyListFilterComponent,
    PolicyListCollectionComponent,
    PolicyListDialogComponent,
    PolicyListComponent,
  ],
  entryComponents: [
    PolicyListDialogComponent
  ]
})
export class PolicyModule implements OnInit {

  constructor() {

  }

  ngOnInit() {
  }

}

