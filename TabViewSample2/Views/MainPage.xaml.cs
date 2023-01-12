using Microsoft.UI.Xaml.Controls;

using TabViewSample2.ViewModels;

namespace TabViewSample2.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
