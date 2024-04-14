using Microsoft.AspNetCore.Components;

namespace Web.Components.Components.Labels
{
    public partial class PageHeader
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public string SubTitle { get; set; } = string.Empty;
    }
}
