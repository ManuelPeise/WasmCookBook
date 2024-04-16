using Data.Models.ExportModels.CookBook;
using Microsoft.AspNetCore.Components;

namespace Web.BlazorCore.Client.Pages.CookBook.Components
{
    public partial class RecipeRequestListItem
    {
        [Parameter]
        public RecipeRequestExportModel Model { get; set; } = new RecipeRequestExportModel();
        [Parameter]
        public EventCallback<int> OnApprove { get; set; }
        [Parameter]
        public EventCallback<int> OnReject { get; set; }

        private async Task HandleApprove()
        {
            await OnApprove.InvokeAsync(Model.Id);
        }

        private async Task HandleReject()
        {
            await OnReject.InvokeAsync(Model.Id);
        }
    }
}
