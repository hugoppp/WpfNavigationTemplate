using System.Windows.Input;
using WpfApp1.WpfUtils;

namespace WpfApp1.Products
{

public class ProductsViewModel : NotifyPropertyChanged, IPageViewModel
{
    private ProductModel _currentProduct;
    private ICommand? _getProductCommand;
    private int _productId;
    private ICommand? _saveProductCommand;

    public int ProductId
    {
        get => _productId;
        set => SetProperty(ref _productId, value);
    }

    public ProductModel? CurrentProduct
    {
        get => _currentProduct;
        set => SetProperty(ref _currentProduct, value);
    }

    public ICommand GetProductCommand
    {
        get
        {
            if (_getProductCommand == null)
                _getProductCommand = new RelayCommand(
                    _ => GetProduct(),
                    _ => ProductId > 0
                );
            return _getProductCommand;
        }
    }

    public ICommand SaveProductCommand
    {
        get
        {
            _saveProductCommand ??= new RelayCommand(
                _ => SaveProduct(),
                _ => CurrentProduct != null
            );
            return _saveProductCommand;
        }
    }

    public string Name => "Products";

    private void GetProduct()
    {
        // Usually you'd get your Product from your datastore,
        // but for now we'll just return a new object
        var p = new ProductModel();
        p.ProductId = ProductId;
        p.ProductName = "Test Product";
        p.UnitPrice = 10;
        CurrentProduct = p;
    }

    private void SaveProduct()
    {
        // You would implement your Product save here
    }
}

}