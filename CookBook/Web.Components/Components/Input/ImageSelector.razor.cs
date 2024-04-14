using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Web.Components.Components.Input
{
    public partial class ImageSelector
    {
        [Inject]
        protected IJSRuntime Js { get; set; }
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string ImgSource { get; set; } = string.Empty;
        [Parameter]
        public EventCallback<IBrowserFile> OnChange { get; set; }
        [Parameter]
        public string Label { get; set; }

        private async Task OnFileSelect(InputFileChangeEventArgs e)
        {
            var file = e.File;

            await OnChange.InvokeAsync(file);
        }

        private async Task HandleImgClicked()
        {
            await Js.InvokeVoidAsync("handleImgClicked", Id);
        }
    }
}
