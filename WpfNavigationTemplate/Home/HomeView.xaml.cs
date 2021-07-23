using System;
using System.Windows.Controls;
using WpfApp1.Products;

namespace WpfApp1.Home
{

/// <summary>
///     Interaction logic for HomeView.xaml
/// </summary>
public partial class HomeView : UserControl
{
    private static int _ctorCallCount;

    public HomeView()
    {
        InitializeComponent();
        if (++_ctorCallCount > 1) throw new Exception($"Ctor of {nameof(HomeView)} called {_ctorCallCount} times");
    }
}

}