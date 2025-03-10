import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { ValidatePasswordlessLoginRoutingModule } from './validate-passwordless-login-routing.module';
import { AccountSharedModule } from '@account/shared/account-shared.module';
import { ValidatePasswordlessLoginComponent } from './validate-passwordless-login.component';

@NgModule({
    declarations: [ValidatePasswordlessLoginComponent],
    imports: [AppSharedModule, AccountSharedModule, ValidatePasswordlessLoginRoutingModule],
})
export class ValidatePasswordlessLoginModule {}
