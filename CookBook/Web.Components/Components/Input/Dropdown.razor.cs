using Data.Models.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace Web.Components.Components.Input
{
    public partial class Dropdown
    {
        [Inject]
        protected IJSRuntime Js { get; set; }
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string DefaultItem { get; set; } = string.Empty;
        [Parameter]
        public string ErrorMsg { get; set; } = string.Empty;
        [Parameter]
        public int SelectedValue { get; set; }
        [Parameter]
        public List<DropDownItem> Items { get; set; } = new List<DropDownItem>();
        [Parameter]
        public bool Validate { get; set; }
        [Parameter]
        public EventCallback<int> OnChange { get; set; }

        private string _errorFieldId => $"{Id}-error";
        private async Task HandleChange(ChangeEventArgs e)
        {
            var value = e.Value as string;

            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out var result))
            {
                if (Validate)
                {
                    await Js.InvokeVoidAsync("handleValidateDropdownInput", [value, Id, ErrorMsg]);
                }

                await OnChange.InvokeAsync(result);
            }
        }
    }
}
