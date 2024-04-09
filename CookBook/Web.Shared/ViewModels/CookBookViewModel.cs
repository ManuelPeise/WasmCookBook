using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Web.Shared.Models.CookBook;

namespace Web.Shared.ViewModels
{
    public partial class CookBookViewModel: ViewModelBase
    {
        [Inject]
        public HttpClient _httpClient { get; set; }

        [ObservableProperty]
        string _CookBookTitle = "Test Title";

        [ObservableProperty]
        private RecipeImportModel _recipeImportModel = new();

        public CookBookViewModel()
        {
            
        }

        public override async Task Loaded()
        {

        }
       
    }
}
