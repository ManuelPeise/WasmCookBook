using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Web.Components.Components.Input
{
    public partial class TextField
    {
        [Inject]
        protected IJSRuntime Js { get; set; }

        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string TextValue { get; set; } = string.Empty;
        [Parameter]
        public string Placeholder { get; set; } = string.Empty;
        [Parameter]
        public bool Validate { get; set; }
        [Parameter]
        public string ErrorMsg { get; set; } = string.Empty;
        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        private string _errorFieldId => $"{Id}-error";
        private async Task OnTextChanged(ChangeEventArgs e)
        {
            var value = e.Value as string;

            if (Validate)
            {
                await Js.InvokeVoidAsync("handleValidateTextFieldInput", [value.Trim(), Id, ErrorMsg]);
            }

            await OnChange.InvokeAsync(value);
        }
    }
}
