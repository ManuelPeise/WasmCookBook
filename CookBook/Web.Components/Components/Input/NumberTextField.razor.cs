using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Web.Components.Components.Input
{
    public partial class NumberTextField
    {
        [Inject]
        protected IJSRuntime Js { get; set; }

        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string NumberValue { get; set; } = string.Empty;

        [Parameter]
        public string Placeholder { get; set; } = string.Empty;
        [Parameter]
        public string ErrorMsg { get; set; } = string.Empty;
        [Parameter]
        public EventCallback<decimal> OnChange { get; set; }

        private string _errorFieldId => $"{Id}-error";
        private string _value => NumberValue == "0" ? string.Empty : NumberValue;
        private async Task OnNumberChanged(ChangeEventArgs e)
        {
            var value = e.Value as string;

            if (value == null)
            {
                return;
            }

            if (value.Contains(','))
            {
                value = value.Replace(',', '.');
            }

            await Js.InvokeVoidAsync("handleNumberInputValidation", [value, Id, ErrorMsg]);

            if (decimal.TryParse(value, out var decimalValue))
            {
                await OnChange.InvokeAsync(decimalValue);
            }
        }
    }
}
