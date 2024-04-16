using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data.Models.ImportModels.CookBook;
using Data.Models.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using Web.Shared.HttpClients;

namespace Web.Shared.ViewModels.Cookbook
{
    public partial class AddRecipePageViewModel : ViewModelBase
    {
        private Data.Models.ExportModels.CookBook.AddRecipePageViewModel? _pageModel;
        private const string ImgSrcBase = "data:image/png;base64,";

        [ObservableProperty]
        private RecipeImportModel _importModel = new RecipeImportModel();
        [ObservableProperty]
        private string _imgSrc = ImgSrcBase;
        [ObservableProperty]
        private bool _ingredientDialogOpen;
        [ObservableProperty]
        private bool _saveDisabled = true;

        public List<DropDownItem> RecipeCategoryItems { get; set; } = new List<DropDownItem>();
        public List<DropDownItem> IngredientCategoryItems { get; set; } = new List<DropDownItem>();
        public List<DropDownItem> UnitItems { get; set; } = new List<DropDownItem>();
        public List<string> RecipeNames { get; set; } = new List<string>();

        public AddRecipePageViewModel(IConfiguration config)
        {
            InitializeHttpClient(config);
        }

        [RelayCommand]
        public async Task HandleImageChanged(IBrowserFile file)
        {
            await using var ms = new MemoryStream();
            await file.OpenReadStream(file.Size).CopyToAsync(ms);
            byte[] imgBytes = GetBytes(ms);

            var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);

            ImgSrc = $"data:image/png;base64,{base64String}";

            CanSaveRecipe();
        }

        [RelayCommand]
        public void HandleRecipeTitleChanged(string value)
        {
            ImportModel.Title = value;

            CanSaveRecipe();
        }

        [RelayCommand]
        public void HandleRecipeShortDescriptionChanged(string value)
        {
            ImportModel.ShortDescription = value;

            CanSaveRecipe();
        }

        [RelayCommand]
        public void HandleDescriptionChanged(ChangeEventArgs args)
        {
            var value = args.Value as string;

            if (value != null)
            {
                ImportModel.Description = value;
            }

            CanSaveRecipe();
        }

        [RelayCommand]
        public void HandleRecipeCategoryChanged(int value)
        {
            var category = _pageModel.RecipeCategories.FirstOrDefault(x => x.Id == value);

            if (category != null)
            {
                ImportModel.RecipeCategory = new RecipeCategoryImportModel
                {
                    CategoryId = category.Id,
                    CategoryName = category.Value,
                };
            }

            CanSaveRecipe();
        }

        [RelayCommand]
        public void ToggleIngredientDialogOpen()
        {
            IngredientDialogOpen = !IngredientDialogOpen;
        }

        [RelayCommand]
        public void HandleCloseDialog(bool open)
        {
            IngredientDialogOpen = open;
        }

        [RelayCommand]
        public void HandleAddIngredient(RecipeIngredientImportModel ingredient)
        {
            var existingIngredients = new List<RecipeIngredientImportModel>(ImportModel.Ingredients);
            existingIngredients.Add(ingredient);

            ImportModel.Ingredients = existingIngredients;

            CanSaveRecipe();
        }

        [RelayCommand]
        public void HandleRemoveIngredient(int index)
        {
            var item = ImportModel.Ingredients[index];

            if (item != null)
            {
                ImportModel.Ingredients.Remove(item);
            }

            CanSaveRecipe();
        }

        [RelayCommand]
        public async Task HandleSaveRecipe()
        {
            ImportModel.Image = ImgSrc;

            if (await InternalApiClient.SendPostRequest("RecipeImport/ImportRecipe", ImportModel))
            {
                ImportModel = new RecipeImportModel();
                ImgSrc = ImgSrcBase;
                SaveDisabled = true;
            }
        }

        public async Task InitializeAsync()
        {
            IsLoading = true;

            if (InternalApiClient != null)
            {
                _pageModel = await InternalApiClient.SendGetRequest<Data.Models.ExportModels.CookBook.AddRecipePageViewModel>("CookBook/GetAddRecipePageViewModel") ?? new Data.Models.ExportModels.CookBook.AddRecipePageViewModel();

                RecipeCategoryItems = _pageModel.RecipeCategories;
                IngredientCategoryItems = _pageModel.IngredientCategories;
                UnitItems = _pageModel.Units;
                RecipeNames = _pageModel.RecipeNames;
            }

            IsLoading = false;
            IsInitialized = true;
        }

        private void CanSaveRecipe()
        {
            SaveDisabled = !ImportModel.IsValidModel();
        }

        private byte[] GetBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.ReadAsync(bytes, 0, bytes.Length);
            stream.Dispose();
            return bytes;
        }
    }


}
