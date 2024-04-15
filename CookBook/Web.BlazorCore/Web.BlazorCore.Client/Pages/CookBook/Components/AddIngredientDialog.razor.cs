using Data.Models.ImportModels.CookBook;
using Data.Models.UI;
using Microsoft.AspNetCore.Components;

namespace Web.BlazorCore.Client.Pages.CookBook.Components
{
    public partial class AddIngredientDialog
    {
        [Parameter]
        public string DialogTitle { get; set; } = string.Empty;

        [Parameter]
        public List<DropDownItem> IngredientCategories { get; set; } = new List<DropDownItem>();
        [Parameter]
        public List<DropDownItem> Units { get; set; } = new List<DropDownItem>();

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        [Parameter]
        public EventCallback<RecipeIngredientImportModel> OnAddIngredient { get; set; }

        private RecipeIngredientImportModel _ingredient = new RecipeIngredientImportModel();

        private void HandleCloseDialog()
        {
            OnClose.InvokeAsync(false);
        }

        private void HandleIngredient()
        {
            OnAddIngredient.InvokeAsync(_ingredient);
            _ingredient = new RecipeIngredientImportModel();
        }

        private void OnAmountChanged(decimal value)
        {
            _ingredient.Amount = value;
        }

        private void OnUnitChanged(int value)
        {
            var unit = Units.FirstOrDefault(x => x.Id == value);

            if(unit != null)
            {
                _ingredient.UnitId = unit.Id;
                _ingredient.Unit = unit.Value;
            }
           
        }

        private void OnNameChanged(string value)
        {
            _ingredient.Name = value;
        }

        private void OnCategoryChanged(int value)
        {
            var category = IngredientCategories.FirstOrDefault(x => x.Id == value);

            _ingredient.CategoryId = category != null ? category.Id : -1;
        }
    }
}
