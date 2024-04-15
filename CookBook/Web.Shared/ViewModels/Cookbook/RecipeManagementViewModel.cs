using Microsoft.Extensions.Configuration;

namespace Web.Shared.ViewModels.Cookbook
{
    public class RecipeManagementViewModel: ViewModelBase
    {
        public RecipeManagementViewModel(IConfiguration config)
        {
            InitializeHttpClient(config);
        }
    }
}
