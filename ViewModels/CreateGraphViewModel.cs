using CommunityToolkit.Mvvm.ComponentModel;

namespace DataVisualizationApp.ViewModels;

public partial class CreateGraphViewModel : ObservableObject
{
    private readonly MainWindowViewModel _mainWindow;

    public CreateGraphViewModel(MainWindowViewModel mainWindow)
    {
        _mainWindow = mainWindow;

    }


    // Later, you could add AddPieChart(), AddPopulationGraph(), etc.
}
