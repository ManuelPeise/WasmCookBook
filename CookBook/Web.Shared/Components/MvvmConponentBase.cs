using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using Web.Shared.ViewModels.Interfaces;

namespace Web.Shared.Components
{
    public abstract class MvvmConponentBase<TViewModel>: ComponentBase where TViewModel : IViewModelBase
    {
        [Inject]
        [NotNull]
        protected TViewModel ViewModel { get; set; }

        protected override void OnInitialized()
        {
            ViewModel.PropertyChanged += (_, _) => StateHasChanged();
            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            return ViewModel.OnInitializedAsync();
        }
    }
}
