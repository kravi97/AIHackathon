import { Component, Injector, OnInit, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppUiCustomizationService } from '@shared/common/ui/app-ui-customization.service';
import { filter as _filter } from 'lodash-es';
import { LoginService } from './login/login.service';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { AppPreBootstrap } from 'AppPreBootstrap';

@Component({
    templateUrl: './account.component.html',
    styleUrls: ['./account.component.less'],
    encapsulation: ViewEncapsulation.None,
})
export class AccountComponent extends AppComponentBase implements OnInit {
    currentYear: number = this._dateTimeService.getYear();
    remoteServiceBaseUrl: string = AppConsts.remoteServiceBaseUrl;
    skin = this.appSession.theme.baseSettings.layout.darkMode ? 'dark' : 'light';
    defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/app-logo-on-' + this.skin + '.svg';
    backgroundImageName = this.appSession.theme.baseSettings.layout.darkMode ? 'login-dark' : 'login';

    tenantChangeDisabledRoutes: string[] = [
        'select-edition',
        'gateway-selection',
        'register-tenant',
        'stripe-pre-payment',
        'stripe-post-payment',
        'paypal-pre-payment',
        'paypal-post-payment',
        'stripe-cancel-payment',
        'buy-succeed',
        'extend-succeed',
        'upgrade-succeed',
        'payment-failed',
        'session-locked',
    ];

    private viewContainerRef: ViewContainerRef;

    public constructor(
        injector: Injector,
        private _router: Router,
        private _loginService: LoginService,
        private _uiCustomizationService: AppUiCustomizationService,
        private _dateTimeService: DateTimeService,
        viewContainerRef: ViewContainerRef
    ) {
        super(injector);

        // We need this small hack in order to catch application root view container ref for modals
        this.viewContainerRef = viewContainerRef;
    }

    showTenantChange(): boolean {
        if (!this._router.url) {
            return false;
        }

        if (
            _filter(this.tenantChangeDisabledRoutes, (route) => this._router.url.indexOf('/account/' + route) >= 0)
                .length
        ) {
            return false;
        }

        return abp.multiTenancy.isEnabled && !this.supportsTenancyNameInUrl();
    }

    isSelectEditionPage(): boolean {
        return this._router.url.indexOf('/account/select-edition') >= 0;
    }

    ngOnInit(): void {
        this._loginService.init();
        document.body.className = this._uiCustomizationService.getAccountModuleBodyClass();
    }

    goToHome(): void {
        (window as any).location.href = '/';
    }

    getBgUrl(): string {
        return 'url(./assets/metronic/themes/' + this.currentTheme.baseSettings.theme + '/images/bg/bg-4.jpg)';
    }

    getLogoSkin(): string {
        return this.currentTheme.baseSettings.layout.darkMode ? 'light' : 'dark';
    }

    private supportsTenancyNameInUrl() {
        return AppPreBootstrap.resolveTenancyName(AppConsts.appBaseUrlFormat) != null;
    }
}
