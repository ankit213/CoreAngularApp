import { NgModule , ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { AuthenticationService } from "../shared/authentication.service";

const routes: Routes = [
  {
    path: '', component: DashboardComponent, data: { title: 'Dashboard' }, canActivate: [AuthenticationService]
  }
];
export const studentRouting: ModuleWithProviders = RouterModule.forChild(routes);
