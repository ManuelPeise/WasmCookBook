using Data.Models.ExportModels.CookBook;
using Microsoft.AspNetCore.Components;

namespace Web.BlazorCore.Client.Pages.CookBook.Components
{
    public partial class RecipeListItem
    {
        [Parameter]
        public RecipeInfoModel Model { get; set; } = new RecipeInfoModel();
        [Parameter]
        public EventCallback<int> OnDelete { get; set; }

        private async Task HandleDelete()
        {
            await OnDelete.InvokeAsync(Model.Id);
        }
    }
}
