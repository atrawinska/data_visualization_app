using Avalonia.Controls;
using charts_app.ViewModels;
using charts_app.Services;
namespace charts_app.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(new ChartService());
    }
}