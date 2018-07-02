import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AppComponent } from './containers/app';
import { MaterialModule } from '../../shared/material';
import { ViewportComponent } from './components/viewport';
import { LayoutComponent } from './components/layout/layout.component';
import { AuthenticationService, AuthUserService, SecurityGuardService, StorageService } from '../../services/index';
//import { NavtoolbarComponent } from './components/navtoolbar/navtoolbar.component';

export const COMPONENTS = [
  AppComponent,
  ViewportComponent,
  LayoutComponent,
  // NavtoolbarComponent
];

@NgModule({
  imports: [CommonModule, RouterModule, MaterialModule],
  declarations: COMPONENTS,
  exports: COMPONENTS,
  providers: [
    AuthenticationService,
    AuthUserService,
    SecurityGuardService,
    StorageService
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error('CoreModule is already loaded. Import it in the AppModule only');
    }
  }

  static forRoot() {
    return {
      ngModule: CoreModule
    };
  }
}
