import { NgModule } from '@angular/core';
import { EntityChangesRoutingModule } from './entity-changes-routing.module';
import { EntityChangesComponent } from './entity-changes.component';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AppSharedModule } from '@app/shared/app-shared.module';

@NgModule({
    declarations: [EntityChangesComponent],
    imports: [AppSharedModule, AdminSharedModule, EntityChangesRoutingModule],
})
export class EntityChangesModule {}
