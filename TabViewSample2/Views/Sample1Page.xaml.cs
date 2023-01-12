using Microsoft.UI.Xaml.Controls;

using TabViewSample2.ViewModels;

namespace TabViewSample2.Views;

public sealed partial class Sample1Page : Page
{
    public Sample1ViewModel ViewModel
    {
        get;
    }

    public Sample1Page()
    {
        ViewModel = App.GetService<Sample1ViewModel>();
        InitializeComponent();
    }
}
