using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Web.Shared.ViewModels;

namespace Web.BlazorCore.Client.Pages.CookBook.Components
{
    public partial class AddNewRecipe
    {
        [Inject]
        protected IJSRuntime Js { get; set; }
        [Inject]
        public IConfiguration? Config { get; set; }
        private CookBookViewModel? _vm;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
           
        }

        protected override async Task OnInitializedAsync()
        {
            if (Config != null && _vm == null)
            {
                _vm = new CookBookViewModel(Config);
            }

            if(_vm != null && _vm.IsInitialized == false)
            {
                await _vm.InitializeAsync();
            }

           
        }
    }
}
