using CommunityToolkit.Mvvm.ComponentModel;

namespace Web.Shared.Models.CookBook
{
    public partial class RecipeImportModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private string _shortDescription;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private string _image;
        [ObservableProperty]
        private RecipeCategoryImportModel _recipeCategory = new();
        [ObservableProperty]
        private List<RecipeIngredientImportModel> _ingredients = new();

    }

    public partial class RecipeCategoryImportModel : ObservableObject
    {
        [ObservableProperty]
        private int? _categoryId;
        [ObservableProperty]
        private string _categoryName;
    }

    public partial class RecipeIngredientImportModel: ObservableObject
    {
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private int _categoryId;
        [ObservableProperty]
        private decimal _amount;
        [ObservableProperty]
        private string _unit;
    }
}
