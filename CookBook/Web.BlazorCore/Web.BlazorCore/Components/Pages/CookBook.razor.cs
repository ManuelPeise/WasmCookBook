using Data.Models.ExportModels.CookBook;
using Microsoft.AspNetCore.Components;
using Web.Shared.HttpClients;


namespace Web.BlazorCore.Components.Pages
{
    public partial class CookBook
    {
        //[Inject] public InternalApiClient _client { get; set; }
        private List<RecipeModel>? _recipes { get; set; } = null;

        public CookBook()
        {
           
        }

        protected override async Task OnInitializedAsync()
        {
            // _recipes = await _client.SendGetRequest<List<RecipeModel>>("CookBook/GetRecipes");
            
        }
    }
}
