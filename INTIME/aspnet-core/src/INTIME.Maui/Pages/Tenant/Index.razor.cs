﻿using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using INTIME.Maui.Core.Components;
using INTIME.Maui.Core.Threading;
using INTIME.MultiTenancy;
using INTIME.MultiTenancy.Dto;

namespace INTIME.Maui.Pages.Tenant
{
    public partial class Index : INTIMEMainLayoutPageComponentBase
    {
        protected ITenantAppService tenantAppService { get; set; }

        private ItemsProviderResult<TenantListDto> tenants;

        private TenantListDto editTenant;

        private EditTenantModal editTenantModal { get; set; }

        private CreateTenantModal createTenantModal { get; set; }

        private GetTenantsInput _filter = new GetTenantsInput();

        private Virtualize<TenantListDto> TenantListContainer { get; set; }

        public Index()
        {
            tenantAppService = Resolve<ITenantAppService>();
        }

        private async Task OpenCreateModal()
        {
            await createTenantModal.Open();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPageHeader(L("Tenants"), new List<Services.UI.PageHeaderButton>()
            {
                new Services.UI.PageHeaderButton(L("CreateNewTenant"), OpenCreateModal)
            });
        }

        private async Task EditTenant(TenantListDto tenant)
        {
            editTenant = tenant;
            await editTenantModal.OpenFor(tenant);
        }

        private async Task RefreshList()
        {
            await TenantListContainer.RefreshDataAsync();
            StateHasChanged();
        }

        private async ValueTask<ItemsProviderResult<TenantListDto>> LoadTenants(ItemsProviderRequest request)
        {
            _filter.MaxResultCount = request.Count;
            _filter.SkipCount = request.StartIndex;

            await UserDialogsService.Block();

            await WebRequestExecuter.Execute(
                 async () => await tenantAppService.GetTenants(_filter),
                 async (result) =>
                 {
                     tenants = new ItemsProviderResult<TenantListDto>(result.Items, result.TotalCount);
                     await UserDialogsService.UnBlock();
                 }
             );

            return tenants;
        }

        private async Task DeleteTenant(TenantListDto tenant)
        {
            var isConfirmed = await UserDialogsService.Confirm(L("TenantDeleteWarningMessage", "\"" + tenant.TenancyName + "\""), L("AreYouSure"));
            if (isConfirmed)
            {
                await SetBusyAsync(async () =>
                {
                    await tenantAppService.DeleteTenant(new EntityDto {Id = tenant.Id});
                    await RefreshList();
                });
            }
        }
    }
}
