using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Web.Shared.HttpClients;
using Web.Shared.ViewModels.Interfaces;

namespace Web.Shared.ViewModels
{
    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        private readonly IConfiguration _configuration;
        [ObservableProperty]
        private InternalApiClient? _internalApiClient;
        [ObservableProperty]
        protected bool _isLoading;

        protected ViewModelBase(IConfiguration config)
        {
            _configuration = config;
            InitializeHttpClient();
        }

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

        private void InitializeHttpClient()
        {
            var baseAddress = _configuration.GetRequiredSection("apiBaseUrl").Value;

            if (baseAddress == null)
            {
                throw new Exception("Could not get api base address!");
            }

            _internalApiClient = new InternalApiClient(new HttpClient { BaseAddress = new Uri(baseAddress) });
        }
    }
}
