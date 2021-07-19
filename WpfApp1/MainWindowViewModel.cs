using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Helper_Classes;
using WpfApp1.Home;
using WpfApp1.Products;

namespace WpfApp1
{

public class MainWindowViewModel : NotifyPropertyChanged
{
    private ICommand? _changePageCommand;
    private IPageViewModel _currentPageViewModel = null!;

    public MainWindowViewModel()
    {
        // Add available pages
        PageViewModels.Add(new HomeViewModel());
        PageViewModels.Add(new ProductsViewModel());

        // Set starting page
        CurrentPageViewModel = PageViewModels[0];
    }


    public ICommand ChangePageCommand =>
        _changePageCommand ??= new RelayCommand(
            p => ChangeViewModel((IPageViewModel) p),
            p => p is IPageViewModel);

    public List<IPageViewModel> PageViewModels { get; } = new();

    public IPageViewModel CurrentPageViewModel
    {
        get => _currentPageViewModel;
        set => SetProperty(ref _currentPageViewModel, value);
    }

    private void ChangeViewModel(IPageViewModel viewModel)
    {
        if (!PageViewModels.Contains(viewModel))
            PageViewModels.Add(viewModel);

        CurrentPageViewModel = PageViewModels.First(vm => vm == viewModel);
    }
}

}