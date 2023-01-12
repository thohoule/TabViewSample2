using System;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using TabViewSample2.Core.Models;
using TabViewSample2.Views.Controls;

namespace TabViewSample2.Proxies;
public abstract class ProxyTab : ObservableObject
{
    /// <summary>
    /// A debug reference, to fix the tab header not updating; one heavy handed way would be to "close"
    /// and "reopen" the tab.
    /// </summary>
    public EmployeeTabView TabView { get; set; }
    /// <summary>
    /// Displayed Header for the tabview.
    /// </summary>
    public abstract string Header { get; }
    /// <summary>
    /// The tab item's content to be drawn by tab view
    /// </summary>
    public abstract UserControl Content { get; }
    /// <summary>
    /// Temporary open persistence, for the runtime and on tabview build, this will be shown if true. If
    /// open state is needed between sessions, then it should be set to data.
    /// </summary>
    public abstract bool IsOpen { get; set; }
    /// <summary>
    /// Changes the closable state of the tab item, Home shouldn't be closable in this sample.
    /// </summary>
    public abstract bool IsClosable { get; }
    /// <summary>
    /// A way to expose the employee for matching, this wan't needed in this sample but I keep in the match us example in EmployeeTabView under 
    /// SelectOrOpen(Employee employee)
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public abstract bool IsMatch(Employee employee);
}
