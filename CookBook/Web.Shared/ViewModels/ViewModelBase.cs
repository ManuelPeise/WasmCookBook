using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Web.Shared.HttpClients;
using Web.Shared.ViewModels.Interfaces;

namespace Web.Shared.ViewModels
{
    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        [ObservableProperty]
        private InternalApiClient? _internalApiClient;
        [ObservableProperty]
        protected bool _isLoading;
        [ObservableProperty]
        protected bool _isInitialized = false;

        public virtual async Task OnInitializedAsync()
        {
            await Loaded().ConfigureAwait(true);
        }

        protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

        [RelayCommand]
        public virtual async Task Loaded()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public virtual void InitializeHttpClient(IConfiguration config)
        {
            var baseAddress = config.GetRequiredSection("apiBaseUrl").Value;

            if (baseAddress == null)
            {
                throw new Exception("Could not get api base address!");
            }

            _internalApiClient = new InternalApiClient(new HttpClient { BaseAddress = new Uri(baseAddress) });
        }
    }
}
