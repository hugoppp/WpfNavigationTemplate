using WpfApp1.Helper_Classes;

namespace WpfApp1.Products
{

public class ProductModel : NotifyPropertyChanged
{
    private int _productId;
    private string _productName;
    private decimal _unitPrice;

    public int ProductId
    {
        get => _productId;
        set => SetProperty(ref _productId, value);
    }

    public string ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set => SetProperty(ref _unitPrice, value);
    }
}

}