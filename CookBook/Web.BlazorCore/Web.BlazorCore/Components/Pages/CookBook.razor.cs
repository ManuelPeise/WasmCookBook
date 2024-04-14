using Data.Models.ExportModels.CookBook;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Web.Shared.ViewModels.Cookbook;

namespace Web.BlazorCore.Components.Pages
{
    public partial class CookBook
    {
        [Inject]
        protected IJSRuntime Js { get; set; }
        [Inject]
        public IConfiguration? Config { get; set; }
        private CookbookViewModel? _vm;

        public CookBook()
        {
           
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }

        protected override async Task OnInitializedAsync()
        {
            if (Config != null && _vm == null)
            {
                _vm = new CookbookViewModel(Config);
            }

            if (_vm != null && _vm.IsInitialized == false)
            {
               //  await _vm.InitializeAsync();
            }


        }
    }
}
