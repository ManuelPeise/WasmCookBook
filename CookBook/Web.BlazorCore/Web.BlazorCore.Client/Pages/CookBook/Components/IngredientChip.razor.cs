using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace Web.BlazorCore.Client.Pages.CookBook.Components
{
    public partial class IngredientChip
    {
        [Parameter]
        public int Index { get; set; }
        [Parameter]
        public decimal Amount { get; set; }
        [Parameter]
        public string Unit { get; set; }
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public string AdditionalClasses { get; set; }

        [Parameter]
        public EventCallback<int> OnClick { get; set; }

        private async Task HandleDelete(MouseEventArgs e)
        {
            await OnClick.InvokeAsync(Index);
        }
    }
}
