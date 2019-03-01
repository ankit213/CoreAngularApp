import { NgModule } from '@angular/core';
import { accountRouting } from '../account/account-routing.module';
import { AccountComponent } from '../account/account.component';
import { LoginComponent } from '../account/login/login.component';
import { RegisterComponent } from '../account/register/register.component';
import { AccountService } from '../account/account.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AccountComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    accountRouting,
    FormsModule
  ],
  providers: [AccountService]
})
export class AccountModule { }
