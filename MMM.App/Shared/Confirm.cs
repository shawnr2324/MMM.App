using Microsoft.AspNetCore.Components;

namespace MMM.App.Shared
{
    public partial class Confirm
    {
        protected bool ShowConfirmation { get; set; }
        [Parameter]
        public string ConfirmText { get; set; } = "Are you sure you want to delete";
        [Parameter]
        public string ConfirmTitle { get; set; } = "Confirm";
        [Parameter]
        public string ActionButton { get; set; } = "Delete";

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ShowConfirmationChanged { get; set; }

        protected async Task OnConfirmationChanged(bool confirmation)
        {
            ShowConfirmation = false;
            await ShowConfirmationChanged.InvokeAsync(confirmation);
        }
    }
}
