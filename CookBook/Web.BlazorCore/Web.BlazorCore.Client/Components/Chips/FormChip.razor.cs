using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Web.BlazorCore.Client.Components.Chips
{
    public partial class FormChip
    {
        [Parameter]
        public int Index { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public string AdditionalClasses { get; set; }

        [Parameter]
        public EventCallback<int> OnClick { get; set; }

        private async Task HandleClick(MouseEventArgs e)
        {
            await OnClick.InvokeAsync(Index);
        }
    }
}
