import { NgModule } from '@angular/core';
import { NavtoolbarComponent } from '../../modules/core/components/navtoolbar/navtoolbar.component';
import { MaterialModule } from '../material/material.module';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    MaterialModule,
    RouterModule,
    CommonModule
  ],
  declarations: [
    NavtoolbarComponent
  ],
  exports: [
    NavtoolbarComponent
  ]
})
export class CommonSharedModule {

}
