using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data.Models.ExportModels.CookBook;
using Data.Models.ImportModels.CookBook;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using Web.Shared.HttpClients;

namespace Web.Shared.ViewModels
{
    public partial class AddRecipeViewModel : ViewModelBase
    {
        private InternalApiClient _internalApiClient;

        [ObservableProperty]
        private ObservableCollection<CategoryModel>? _recipeCategories;
        [ObservableProperty]
        private int _categoryId = 0;
        [ObservableProperty]
        private string _title = "Test";
        [ObservableProperty]
        private RecipeImportModel _model = new RecipeImportModel();
        [ObservableProperty]
        private string _imgSrc = "data:image/png;base64,";

        public AddRecipeViewModel(IConfiguration config)
        {
            var baseAddress = config.GetRequiredSection("apiBaseUrl").Value;

            _internalApiClient = new InternalApiClient(new HttpClient { BaseAddress = new Uri(baseAddress) });

        }

        [RelayCommand]
        public void SaveRecipe()
        {
            Debug.WriteLine($"Id: {CategoryId}");

            Model.RecipeCategory = new RecipeCategoryImportModel
            {
                CategoryId = CategoryId,
                CategoryName = RecipeCategories.First(x => x.CategoryId == CategoryId)?.Name,
            };

            Title = "Das ist ein Test";
        }

        [RelayCommand]
        public async Task LoadFile(IBrowserFile file)
        {
            await using var ms = new MemoryStream();
            await file.OpenReadStream(file.Size).CopyToAsync(ms);
            byte[] imgBytes = GetBytes(ms);

            var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);

            ImgSrc = $"data:image/png;base64,{base64String}";

        }
        public override async Task Loaded()
        {
            var model = await _internalApiClient.SendGetRequest<AddRecipePageViewModel>("CookBook/GetAddRecipePageViewModel");

            RecipeCategories = new ObservableCollection<CategoryModel>(model.RecipeCategories);

            Debug.WriteLine($"Id: {CategoryId}");
        }

        public override async Task OnInitializedAsync()
        {

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
