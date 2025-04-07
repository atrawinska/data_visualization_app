using System;
using CommunityToolkit.Mvvm.Input;

public class SelectableButtonViewModel
{
    public string Label { get; set; }

    public IRelayCommand SelectCommand { get; }

    public SelectableButtonViewModel(string label, Action<string> onSelect)
    {
        Label = label;
        SelectCommand = new RelayCommand(() => onSelect(Label));
    }

}
