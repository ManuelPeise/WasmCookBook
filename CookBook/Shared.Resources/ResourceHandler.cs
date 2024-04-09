using Shared.Resources.Models;
using System.Globalization;
using System.Resources;

namespace Shared.Resources
{
    public class ResourceHandler
    {
        private readonly string _nameSpace;

        public const string ResxCookBook = "CookBook";

        public string GetResource(string nameSpace, string key)
        {
            var manager = GetRecourceManager(nameSpace);

            return manager.GetString(key, CultureInfo.InvariantCulture) ?? key;
        }

        public T? GetRecourceData<T>()
        {
            var type = typeof(T);

            if (type == typeof(CookBookResources))
            {
                var model = GetCookBookResourceModel();

                return (T)Convert.ChangeType(model, type);
            }

            return default(T);
        }

        private CookBookResources GetCookBookResourceModel()
        {
            return new CookBookResources
            {
                LabelAddRecipePageTitle = Resx.CookBook.LabelAddRecipePageTitle
            };
        }

        private ResourceManager GetRecourceManager(string nameSpace)
        {
            switch (nameSpace)
            {
                case ResxCookBook:
                    return Resx.CookBook.ResourceManager;
                default: throw new ArgumentOutOfRangeException(nameof(nameSpace));
            }
        }
    }
}
