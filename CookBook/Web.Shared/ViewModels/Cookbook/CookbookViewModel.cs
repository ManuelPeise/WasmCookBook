using Microsoft.Extensions.Configuration;

namespace Web.Shared.ViewModels.Cookbook
{
    public class CookbookViewModel : ViewModelBase
    {
        public CookbookViewModel(IConfiguration config)
        {
            InitializeHttpClient(config);
        }
    }
}
