using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data.Models.ExportModels.CookBook;
using Microsoft.Extensions.Configuration;

namespace Web.Shared.ViewModels.Cookbook
{
    public partial class RecipeManagementViewModel : ViewModelBase
    {
        [ObservableProperty]
        private List<RecipeRequestExportModel> _recipeRequests = new List<RecipeRequestExportModel>();
        [ObservableProperty]
        private List<RecipeInfoModel> _existingRecipes = new List<RecipeInfoModel>();

        [RelayCommand]
        public async Task HandleApproveRecipeRequest(int id)
        {
            if (InternalApiClient != null)
            {
                RecipeRequests = await InternalApiClient.SendGetRequest<List<RecipeRequestExportModel>>($"CookBookAdministration/ApproveRecipeRequest/{id}") ??
                    new List<RecipeRequestExportModel>();
            }

            await LoadExistingRecipes();
        }

        [RelayCommand]
        public async Task HandleRejectRecipeRequest(int id)
        {
            if (InternalApiClient != null)
            {
                RecipeRequests = await InternalApiClient.SendGetRequest<List<RecipeRequestExportModel>>($"CookBookAdministration/RejectRecipeRequest/{id}") ??
                    new List<RecipeRequestExportModel>(); ;
            }
        }

        [RelayCommand]
        public async Task HandleDeleteRecipe(int id)
        {
            if (InternalApiClient != null)
            {
                ExistingRecipes = await InternalApiClient.SendGetRequest<List<RecipeInfoModel>>($"CookBookAdministration/DeleteRecipe/{id}") ??
                    new List<RecipeInfoModel>(); ;
            }
        }

        public RecipeManagementViewModel(IConfiguration config): base(config) 
        {
        }

        public override async Task OnInitializedAsync()
        {
            IsLoading = true;

            await LoadRecipeRequests();
            await LoadExistingRecipes();

            IsLoading = false;
        }

        private async Task LoadRecipeRequests()
        {
            if (InternalApiClient != null)
            {
                RecipeRequests = await InternalApiClient.SendGetRequest<List<RecipeRequestExportModel>>($"CookBookAdministration/GetRecipeRequests/false") ?? new List<RecipeRequestExportModel>();
            }
        }

        private async Task LoadExistingRecipes()
        {
            if (InternalApiClient != null)
            {
                ExistingRecipes = await InternalApiClient.SendGetRequest<List<RecipeInfoModel>>($"CookBookAdministration/GetExistingRecipes") ?? new List<RecipeInfoModel>();
            }
        }
    }
}
