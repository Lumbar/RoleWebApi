import { Routes } from '@angular/router';
import { SecurityGuardService } from './services/security-guard.service';
import { LoginComponent } from './modules/security/components/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: '/policy', pathMatch: 'full' },
  {
    path: 'policy',
    loadChildren: './modules/policy/policy.module#PolicyModule',
    canActivate: [SecurityGuardService],
    runGuardsAndResolvers: 'always'
  },
  {
    path: 'security',
    loadChildren: './modules/security/security.module#SecurityModule',
    canActivateChild: [SecurityGuardService],
    runGuardsAndResolvers: 'always'
  }
];
