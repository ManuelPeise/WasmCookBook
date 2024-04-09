using System.ComponentModel;

namespace Web.Shared.ViewModels.Interfaces
{
    public interface IViewModelBase: INotifyPropertyChanged
    {
        Task OnInitializedAsync();
        Task Loaded();
    }
}
