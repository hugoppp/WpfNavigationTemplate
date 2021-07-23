using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace WpfApp1.Products
{

/// <summary>
///     Interaction logic for ProductsView.xaml
/// </summary>
public partial class ProductsView : UserControl
{
    private static int _ctorCallCount;

    public ProductsView()
    {
        InitializeComponent();
        if (++_ctorCallCount > 1) throw new Exception($"Ctor of {nameof(ProductsView)} called {_ctorCallCount} times");
    }
}

}