using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using TabViewSample2.Core.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TabViewSample2.Proxies;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TabViewSample2.Views.Controls;
/// <summary>
/// Home Tab for selecting employees
/// </summary>
public sealed partial class HomeTabControl : UserControl
{
    private EmployeeTabView employeeTabView;

    public ObservableCollection<ProxyEmployee> Employees => MockDataSet.Employees;
    public HomeTabControl(EmployeeTabView tabView)
    {
        employeeTabView = tabView;

        this.InitializeComponent();
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        employeeTabView.SelectOrOpen(e.ClickedItem as ProxyEmployee);
    }
}
