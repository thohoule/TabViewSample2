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
using System.ComponentModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TabViewSample2.Views.Controls;
public sealed partial class EmployeeTabView : UserControl
{
    public Employee SelectedEmployee { get; set; }
    public ObservableCollection<ProxyTab> ActiveTabs { get; set; } = new ObservableCollection<ProxyTab>();

    public EmployeeTabView()
    {
        this.InitializeComponent();

        buildTabs();
    }

    /// <summary>
    /// From home tab the user can click on a user and if that user's tab is already open switch to it, otherwise open it as a tab
    /// </summary>
    /// <param name="employee"></param>
    public void SelectOrOpen(ProxyEmployee employee)
    {
        var index = ActiveTabs.IndexOf(employee);

        if (index == -1)
        {
            ActiveTabs.Add(employee);
            employee.IsOpen = true;
            //Set the tabviews select to the newly opened tab
            TabControl.SelectedIndex = ActiveTabs.Count - 1;
        }
        else
        {
            TabControl.SelectedIndex = index;
        }
    }

    [Obsolete]
    public void SelectOrOpen(Employee employee)
    {
        var match = ActiveTabs.First(tab => tab.IsMatch(employee));

        if (match == null)
        {
            var newTab = MockDataSet.Employees.First(tab => tab.IsMatch(employee));
            newTab.IsOpen = true;
            ActiveTabs.Add(newTab);
            TabControl.SelectedIndex = ActiveTabs.Count - 1;
        }
        else
        {
            var index = ActiveTabs.IndexOf(match);
            TabControl.SelectedIndex = index;
        }
    }

    /// <summary>
    /// builds the tabs on page load, this is mostly done like this to incorporate the home tab.
    /// </summary>
    private void buildTabs()
    {
        ActiveTabs = new ObservableCollection<ProxyTab>();

        ActiveTabs.Add(homeTab());

        foreach (var empoyee in MockDataSet.Employees)
        {
            if (empoyee.IsOpen)
                ActiveTabs.Add(empoyee);
        }
    }

    private HomeTabProxy homeTab()
    {
        return new HomeTabProxy(this);
    }

    /// <summary>
    /// Tab item's close request event handler, just removes it from active tags.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void TabControl_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        if (args.Item is ProxyEmployee tab)
        {
            ActiveTabs.Remove(tab);
            tab.IsOpen = false;
        }
    }

    /// <summary>
    /// Makes a request to MockDataSet to add a new employee.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void TabControl_AddTabButtonClick(TabView sender, object args)
    {
        ActiveTabs.Add(MockDataSet.AddNewEmpoyee());
        TabControl.SelectedIndex = ActiveTabs.Count - 1;
    }
}
