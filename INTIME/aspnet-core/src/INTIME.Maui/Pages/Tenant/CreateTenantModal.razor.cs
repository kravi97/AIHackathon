using Abp.ObjectMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using INTIME.Common;
using INTIME.Editions.Dto;
using INTIME.Maui.Core;
using INTIME.Maui.Core.Components;
using INTIME.Maui.Core.Extensions;
using INTIME.Maui.Core.Threading;
using INTIME.Maui.Core.Validations;
using INTIME.Maui.Models.Tenants;
using INTIME.MultiTenancy;
using INTIME.MultiTenancy.Dto;

namespace INTIME.Maui.Pages.Tenant
{
    public partial class CreateTenantModal : ModalBase
    {
        [Parameter] public EventCallback OnSaveCompleted { get; set; }

        public override string ModalId => "create-tenant-modal";
        
        private ITenantAppService _tenantAppService = Resolve<ITenantAppService>();

        private readonly ICommonLookupAppService _commonLookupAppService = Resolve<ICommonLookupAppService>();

        private CreateTenantModel CreateTenantModel { get; set; } = new()
        {
            IsActive = true
        };
        
        public async Task Open()
        {
            await PopulateEditionsCombobox();
            await Show();
        }

        private async Task PopulateEditionsCombobox()
        {
            var editions = await _commonLookupAppService.GetEditionsForCombobox();
            CreateTenantModel.Editions = editions.Items.ToList();

            CreateTenantModel.Editions.Insert(0, new SubscribableEditionComboboxItemDto(CreateTenantModel.NotAssignedValue,
                $"- {L("NotAssigned")} -", null));
        }

        private async Task CreateTenantAsync()
        {
            await SetBusyAsync(async () =>
            {
                await WebRequestExecuter.Execute(async () =>
                {
                    CreateTenantModel.NormalizeCreateTenantInputModel();

                    await _tenantAppService.CreateTenant(CreateTenantModel);
                }, async () =>
                {
                    await UserDialogsService.AlertSuccess(L("SuccessfullySaved"));
                    await Hide();
                    await OnSaveCompleted.InvokeAsync();
                });
            });
        }

        public override Task Hide()
        {
            CreateTenantModel = new CreateTenantModel()
            {
                IsActive = true,
                Editions = []
            };
            
            return base.Hide();
        }
    }
}