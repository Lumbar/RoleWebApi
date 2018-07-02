"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var security_guard_service_1 = require("./services/security-guard.service");
exports.routes = [
    { path: '', redirectTo: '/policy', pathMatch: 'full' },
    {
        path: 'policy',
        loadChildren: './modules/policy/policy.module#PolicyModule',
        canActivate: [security_guard_service_1.SecurityGuardService],
        runGuardsAndResolvers: 'always'
    },
    {
        path: 'security',
        loadChildren: './modules/security/security.module#SecurityModule',
        canActivateChild: [security_guard_service_1.SecurityGuardService],
        runGuardsAndResolvers: 'always'
    }
];
//# sourceMappingURL=routes.js.map