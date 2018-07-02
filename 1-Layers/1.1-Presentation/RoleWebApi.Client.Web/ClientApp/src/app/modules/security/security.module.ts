import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SecurityManagerComponent } from './containers/manager';
import { LoginComponent } from './components/login/login.component';
import { MaterialModule } from '../../shared/material';
import { NetworkManager } from '../../agents/networkmanager';
import { FormService } from '../../services';
import { SecurityAgent } from '../../agents/security/security-agent';
import { CommonSharedModule } from '../../shared/common-shared/common-shared.module';

const routes: Routes = [

  {
    path: 'login', component: SecurityManagerComponent,
    children: [
      {
        outlet: 'security-manager',
        path: '',
        component: LoginComponent
      }
    ]
  },
  { path: '**', redirectTo: '/policies', pathMatch: 'full' }
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
    SecurityAgent,
    FormService
  ],
  declarations: [
    LoginComponent,
    SecurityManagerComponent
  ],
  entryComponents: [
  ]
})
export class SecurityModule implements OnInit {

  constructor() {

  }

  ngOnInit() {
  }

}

