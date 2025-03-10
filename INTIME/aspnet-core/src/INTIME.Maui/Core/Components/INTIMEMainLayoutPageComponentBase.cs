﻿using INTIME.Maui.Services.UI;

namespace INTIME.Maui.Core.Components
{
    public class INTIMEMainLayoutPageComponentBase : INTIMEComponentBase
    {
        protected PageHeaderService PageHeaderService { get; set; }

        protected DomManipulatorService DomManipulatorService { get; set; }

        public INTIMEMainLayoutPageComponentBase()
        {
            PageHeaderService = Resolve<PageHeaderService>();
            DomManipulatorService = Resolve<DomManipulatorService>();
        }

        protected async Task SetPageHeader(string title)
        {
            PageHeaderService.Title = title;
            PageHeaderService.ClearButton();
            await DomManipulatorService.ClearModalBackdrop(JS);
        }

        protected async Task SetPageHeader(string title, List<PageHeaderButton> buttons)
        {
            PageHeaderService.Title = title;
            PageHeaderService.SetButtons(buttons);
            await DomManipulatorService.ClearModalBackdrop(JS);
        }
    }
}
