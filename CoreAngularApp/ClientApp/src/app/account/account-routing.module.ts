import { NgModule , ModuleWithProviders } from '@angular/core';
import { Routes , RouterModule } from '@angular/router';
import { LoginComponent } from '../account/login/login.component';
import { RegisterComponent } from '../account/register/register.component';
import { AccountComponent } from '../account/account.component';

const routes: Routes = [
    { path: '', component: AccountComponent
     ,children : [
         { path:'login' , component :  LoginComponent  },
         { path:'register' , component :  RegisterComponent  }
      ]
    }
];

export const accountRouting: ModuleWithProviders = RouterModule.forChild(routes);
