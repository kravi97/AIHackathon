import { Component, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    CreateUserDelegationDto,
    NameValueDto,
    FindUsersInput,
    CommonLookupServiceProxy,
    UserDelegationServiceProxy,
    FindUsersOutputDto,
} from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CommonLookupModalComponent } from '@app/shared/common/lookup/common-lookup-modal.component';
import { finalize } from 'rxjs/operators';
import { DateTime } from 'luxon';
import { DateTimeService } from '../common/timing/date-time.service';

@Component({
    selector: 'createNewUserDelegation',
    templateUrl: './create-new-user-delegation-modal.component.html',
})
export class CreateNewUserDelegationModalComponent extends AppComponentBase {
    @ViewChild('userDelegationModal', { static: true }) modal: ModalDirective;
    @ViewChild('userLookupModal', { static: true }) userLookupModal: CommonLookupModalComponent;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    selectedUsername = '';

    userDelegation: CreateUserDelegationDto = new CreateUserDelegationDto();

    constructor(
        injector: Injector,
        private _userDelegationService: UserDelegationServiceProxy,
        private _commonLookupService: CommonLookupServiceProxy,
        private _dateTimeService: DateTimeService,
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.userDelegation = new CreateUserDelegationDto();

        this.userLookupModal.configure({
            title: this.l('SelectAUser'),
            dataSource: (skipCount: number, maxResultCount: number, filter: string, tenantId?: number) => {
                let input = new FindUsersInput();
                input.filter = filter;
                input.excludeCurrentUser = true;
                input.maxResultCount = maxResultCount;
                input.skipCount = skipCount;
                input.tenantId = tenantId;
                return this._commonLookupService.findUsers(input);
            },
        });

        this.modal.show();
    }

    showCommonLookupModal(): void {
        this.userLookupModal.show();
    }

    userSelected(user: FindUsersOutputDto): void {
        this.userDelegation.targetUserId = user.id;
        this.selectedUsername = user.name;
    }

    setUserIdNull() {
        this.userDelegation.targetUserId = null;
        this.selectedUsername = null;
    }

    save(): void {
        this.saving = true;

        let input = new CreateUserDelegationDto();
        input.targetUserId = this.userDelegation.targetUserId;
        input.startTime = this._dateTimeService.getStartOfDayForDate(this.userDelegation.startTime);
        input.endTime = this._dateTimeService.getEndOfDayForDate(this.userDelegation.endTime);

        this._userDelegationService
            .delegateNewUser(input)
            .pipe(
                finalize(() => {
                    this.saving = false;
                }),
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.selectedUsername = '';
        this.modal.hide();
    }
}
