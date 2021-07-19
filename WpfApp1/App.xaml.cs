using System.Windows;

namespace WpfApp1
{

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var app = new MainWindow();
        var context = new MainWindowViewModel();
        app.DataContext = context;
        app.Show();
    }
}

}