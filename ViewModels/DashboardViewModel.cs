using CommunityToolkit.Mvvm.ComponentModel;

namespace DataVisualizationApp.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
   // private object graph;
  
    [ObservableProperty]
    public MainWindowViewModel mwvc;
    public DashboardViewModel(MainWindowViewModel _mwvc){

      Mwvc = _mwvc;


    }



    
}

