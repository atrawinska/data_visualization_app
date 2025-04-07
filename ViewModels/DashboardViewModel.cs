using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DataVisualizationApp.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
   // private object graph;
  
    [ObservableProperty]
     public MainWindowViewModel mwvm;

    public ObservableCollection<GraphViewModel> Graphs { get; }


    public DashboardViewModel(MainWindowViewModel _mwvm){

      mwvm = _mwvm;
      Graphs = _mwvm.Graphs;
      Debug.WriteLine("DashboardViewModel received " + Graphs.Count + " graphs");
   



    }

    
 


    
}

